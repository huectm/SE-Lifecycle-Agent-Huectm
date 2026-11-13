import re,json
from pathlib import Path

def refine_usage(classes,pages,ucs):
 dto={n for n,c in classes.items() if c['role']=='DTO'};entities={n for n,c in classes.items() if c['role']=='entity'}
 def refs(text,targets):return {n for n in targets if re.search(r'\b'+re.escape(n)+r'\b',text)}
 def typed_refs(n,targets):return refs(' '.join(classes[n]['attributes']+classes[n]['operations']),targets)
 def add_edge(edges,source,target,kind,label):
  if source==target:return
  if not any(e['source']==source and e['target']==target and e['kind']==kind for e in edges):edges.append({'source':source,'target':target,'kind':kind,'label':label})
 # Returning/using an entity is not an owned collaborator. Remove the earlier artificial retained-result fields.
 for c in classes.values():c['attributes']=[a for a in c['attributes'] if not a.startswith('- materialized')]
 for uc,info in ucs.items():
  for n in [info['service'],info['feature']+'Repository']:
   classes[n]['used_entity_types']=list(dict.fromkeys(classes[n].get('used_entity_types',[])+info['entities']))
 for p in pages:
  uc=p['owner'];names=list(p['classes']);is_overview=p.get('compact',False)
  if uc in ucs:
   f=ucs[uc]['feature'];roots=[ucs[uc]['controller'],'I'+f+'Service',ucs[uc]['service']]
   if is_overview:
    needed=set()
    for n in roots:needed |= typed_refs(n,dto)
    # Include the nested DTO graph so request/response contracts are not unexplained detached boxes.
    for _ in range(len(dto)):
     before=len(needed)
     for n in list(needed):needed |= typed_refs(n,dto)
     if len(needed)==before:break
    added=[n for n in classes if n in needed and n not in names]
    names+=added
    for start in range(0,len(added),7):p['lanes'].append(added[start:start+7])
    for n in added:p['origin_tags'][n]='design data contract';p['pattern_tags'][n]='DTO / API boundary data'
   elif p['title'].startswith('Request and Response Contracts'):
    names=roots+names
    # Add a containing DTO if this chunk contains only its nested line/detail DTO.
    direct=set().union(*(typed_refs(n,dto) for n in roots));wire=set(direct)
    for _ in range(len(dto)):
     before=len(wire)
     for n in list(wire):wire |= typed_refs(n,dto)
     if len(wire)==before:break
    for _ in range(len(dto)):
     orphan=[n for n in names if n in dto and n not in direct and not any(parent in dto and parent!=n and n in typed_refs(parent,dto) for parent in names)]
     parents={parent for parent in wire if any(child in typed_refs(parent,dto) for child in orphan)}
     extra=[n for n in classes if n in parents and n not in names]
     if not extra:break
     names+=extra
    p['title']=p['title'].replace('Request and Response Contracts','DTO Contracts and Usage')
  if uc in ['shared','transitions']:
   consumers=[n for n in names if classes[n]['role']!='DTO']
   extra_dto=set().union(*(typed_refs(n,dto) for n in consumers)) if consumers else set()
   names += [n for n in classes if n in extra_dto and n not in names]
  names=list(dict.fromkeys(names));p['classes']=names
  edges=[]
  for e in p['edges']:
   e=e.copy()
   if e['target'] in entities and classes[e['source']]['role']!='entity':e['kind']='dependency';e['label']='uses entity'
   add_edge(edges,e['source'],e['target'],e['kind'],e['label'])
  if uc in ucs and p['title'].startswith('DTO Contracts and Usage'):
   feature=ucs[uc]['feature'];contract='I'+feature+'Service'
   add_edge(edges,ucs[uc]['controller'],contract,'association','service')
   add_edge(edges,ucs[uc]['service'],contract,'realization','implements')
  for n in names:
   c=classes[n]
   if c['role']!='entity':
    used=typed_refs(n,entities)|set(c.get('used_entity_types',[]))
    for target in sorted(used&set(names)):add_edge(edges,n,target,'dependency','uses entity')
   used_dto=typed_refs(n,dto)&set(names)
   if c['role']=='DTO':
    owned=refs(' '.join(c['attributes']),dto)&set(names)
    for target in sorted(owned):add_edge(edges,n,target,'association','contains DTO')
    for target in sorted(used_dto-owned):add_edge(edges,n,target,'dependency','uses DTO')
   else:
    for target in sorted(used_dto):add_edge(edges,n,target,'dependency','uses wire DTO' if c['package'].startswith(('FreshFood-Customer-Web','FreshFood-App')) else 'uses DTO')
  p['edges']=edges
 # Give every use case a direct DTO usage summary for review and independently verifiable evidence.
 rows=[]
 for p in pages:
  for e in p['edges']:
   if e['kind']=='dependency' and (e['target'] in dto or e['target'] in entities):
    row={'UseCase':p['owner'],'View':p['title'],'Consumer':e['source'],'UsedType':e['target'],'UsedRole':classes[e['target']]['role'],'Relation':'dependency','Basis':'operation signature / local entity responsibility'}
    if row not in rows:rows.append(row)
 Path('artifacts/design/detailed/dto-entity-usage.json').write_text(json.dumps(rows,indent=2))
 return {'dto_usage':'dependency to data contract; DTO-owned nested DTOs retain structural association','entity_usage':'non-entity consumer to entity is dependency; domain entity associations retained','di':'stored backend collaborator references remain association; realization unchanged'}
