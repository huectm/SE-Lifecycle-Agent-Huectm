"""One-time source migration preserving typed helper return values and case IDs."""
from pathlib import Path
import re
root=Path('src/Tests/Backend/FreshFood.Backend.UnitTests')
def arguments(text,start):
 depth=1;quote=None;escape=False;pieces=[];last=start+1;i=last
 while i<len(text):
  c=text[i]
  if quote:
   if escape:escape=False
   elif c=='\\':escape=True
   elif c==quote:quote=None
  elif c in ['"',"'"]:quote=c
  elif c in '([{':depth+=1
  elif c in ')]}':
   depth-=1
   if depth==0:pieces.append(text[last:i]);return pieces,i
  elif c==',' and depth==1:pieces.append(text[last:i]);last=i+1
  i+=1
 raise ValueError('Unbalanced assertion')
def convert(text):
 pattern=re.compile(r'Assert\.(\w+)(<[^()\n]*>)?\(')
 out='';position=0
 while match:=pattern.search(text,position):
  args,end=arguments(text,match.end()-1);a=[convert(x.strip()) for x in args];name=match[1];generic=match[2] or ''
  if name in ['IsType','Single','ThrowsAsync']:new='TestChecks.'+name+generic+'('+', '.join(a)+')'
  elif name=='Throws':new='Assert.Throws'+generic+'('+', '.join(a)+')!'
  elif name in ['Equal','Same']:new='Assert.That('+a[1]+', Is.'+('EqualTo' if name=='Equal' else 'SameAs')+'('+a[0]+'))'
  elif name in ['True','False','Null','NotNull','Empty','NotEmpty']:
   constraint={'True':'Is.True','False':'Is.False','Null':'Is.Null','NotNull':'Is.Not.Null','Empty':'Is.Empty','NotEmpty':'Is.Not.Empty'}[name];new='Assert.That('+a[0]+', '+constraint+')'
  elif name=='DoesNotContain' and len(a)==2 and '=>' in a[1]:new='Assert.That('+a[0]+'.Any('+a[1]+'), Is.False)'
  elif name in ['Contains','DoesNotContain']:
   constraint='Does.'+('Not.' if name=='DoesNotContain' else '')+'Contain('+a[0]+')'+('.IgnoreCase' if len(a)>2 and 'IgnoreCase' in a[2] else '')
   new='Assert.That('+a[1]+', '+constraint+')'
  else:raise ValueError(name)
  out+=text[position:match.start()]+new;position=end+1
 return out+text[position:]
for p in root.glob('*.cs'):
 if 'using Xunit;' not in p.read_text(encoding='utf-8'):continue
 s=p.read_text(encoding='utf-8').replace('using Xunit;','using NUnit.Framework;').replace('[assembly: CollectionBehavior(DisableTestParallelization = true)]','[assembly: LevelOfParallelism(1)]\n[assembly: NonParallelizable]')
 p.write_text(convert(s),encoding='utf-8')
p=root/'FreshFood.Backend.UnitTests.csproj';s=p.read_text(encoding='utf-8');s=re.sub(r'<PackageReference Include="xunit"[^>]*/>','<PackageReference Include="NUnit" Version="4.3.2"/>',s);s=re.sub(r'<PackageReference Include="xunit.runner.visualstudio"[^>]*>.*?</PackageReference>','<PackageReference Include="NUnit3TestAdapter" Version="5.0.0"><PrivateAssets>all</PrivateAssets></PackageReference>',s);p.write_text(s,encoding='utf-8')
print('Assertion helpers migrated to NUnit constraints.')
