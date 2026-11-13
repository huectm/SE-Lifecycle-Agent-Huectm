import csv,json,time
from pathlib import Path
from robot.libraries.BuiltIn import BuiltIn
from robot.api.deco import keyword
ROOT=Path(__file__).resolve().parents[2]
class RegistrationData:
    ROBOT_LIBRARY_SCOPE='SUITE'
    def __init__(self):
        with (ROOT/'tests/data/tutorialsninja_register.csv').open(encoding='utf-8') as f:self.rows={r['id']:r for r in csv.DictReader(f)}
        self.run=str(time.time_ns());self.current=None
    @keyword
    def get_registration_dataset(self,case_id):
        c=self.rows[case_id].copy()
        c.update(firstname='Robot',lastname='Tester',email=f'rf{self.run}{case_id.lower()}@example.com',telephone='0812345678',password='Valid123!',confirm='Valid123!',newsletter='0',agree='1')
        if c['field'] in ['firstname','lastname','email','telephone','password','confirm','newsletter','agree']:c[c['field']]=c['value']
        if c['field']=='password':c['confirm']=c['password']
        self.current=c
        BuiltIn().log(json.dumps(c,ensure_ascii=False))
        return c
    @keyword
    def check_registration_outcome(self,row):
        sl=BuiltIn().get_library_instance('SeleniumLibrary');d=sl.driver
        from selenium.webdriver.support.ui import WebDriverWait
        WebDriverWait(d,15).until(lambda b: 'route=account/success' in b.current_url or bool(b.find_elements('css selector','.text-danger,.alert-danger')) or b.execute_script("var e=document.getElementById('input-email');return e && !e.validity.valid"))
        success='route=account/success' in d.current_url
        warnings='\n'.join(x.text for x in d.find_elements('css selector','.text-danger,.alert-danger'))
        validity=d.execute_script("var e=document.getElementById('input-email');return e?{valid:e.validity.valid,message:e.validationMessage}:null")
        expected=row['expected']
        self.actual=dict(url=d.current_url,success=success,warnings=warnings,email_validity=validity)
        if expected=='success':
            assert success, f'Expected registration success; actual={self.actual}'
            assert 'Your Account Has Been Created!' in d.find_element('id','content').text
            d.get('https://tutorialsninja.com/demo/index.php?route=account/newsletter')
            chosen=d.find_element('css selector',f'input[name="newsletter"][value="{row["newsletter"]}"]')
            assert chosen.is_selected(),'Saved newsletter preference differs from submitted value'
            d.get('https://tutorialsninja.com/demo/index.php?route=account/edit')
            for field in ['firstname','lastname','email','telephone']:
                assert d.find_element('id',f'input-{field}').get_attribute('value')==row[field],f'Saved {field} differs'
        elif expected=='email-invalid':
            assert not success,'Invalid email unexpectedly accepted'
            assert ('E-Mail Address does not appear to be valid' in warnings) or (validity and not validity['valid']),f'No email rejection evidence: {self.actual}'
        elif expected=='reject':
            assert not success,f'Proposed UC rule violated: registration accepted; clarification required. {self.actual}'
            assert warnings or (validity and not validity['valid']),f'No rejection evidence: {self.actual}'
        else:
            assert not success,f'Unexpected successful registration; expected {expected}'
            assert expected.lower() in warnings.lower(),f'Expected {expected!r}; actual={self.actual}'
    @keyword
    def save_registration_evidence(self,name,status):
        sl=BuiltIn().get_library_instance('SeleniumLibrary');out=Path(BuiltIn().get_variable_value('${OUTPUT DIR}'))/'evidence';out.mkdir(exist_ok=True)
        case_id=name.split()[0]
        try:
            sl.driver.save_screenshot(str(out/f'{case_id}.png'))
            (out/f'{case_id}.html').write_text(sl.driver.page_source,encoding='utf-8')
            record=dict(case=self.current,status=status,url=sl.driver.current_url,title=sl.driver.title,actual=getattr(self,'actual',None))
            (out/f'{case_id}.json').write_text(json.dumps(record,ensure_ascii=False,indent=2),encoding='utf-8')
        except Exception as e:BuiltIn().log(f'Evidence capture: {e}','WARN')

