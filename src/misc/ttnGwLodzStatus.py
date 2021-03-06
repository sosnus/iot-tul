print(">>> SOSNUS SCRIPT ( ttnGwLodzStatus.py ): TTN GW in Lodz, owners and last seen <<<")
print("Create: 16:14 23-Jul-19 last modif: 18:30 07-Aug-19")
import requests
import json
r =  requests.get('https://www.thethingsnetwork.org/gateway-data/location?latitude=51.76873234&longitude=19.4569911&distance=50000')
r = r.json()

for x in r:
  print('NAME: ',x)
  print('     OWNER:',r[x].get('owner'))
#  print('     OWNERS:',r[x].get('owners'))
  print('     DESC:',r[x].get('description'))
  print('     LAST SEEN:',r[x].get('last_seen'))
  from datetime import datetime
  strTime = r[x].get('last_seen')
  #example strTime input: '2019-07-23T12:49:36Z'
  time = datetime.strptime(strTime, "%Y-%m-%dT%H:%M:%SZ")
  time2 = datetime.now()
  delta = time2 - time
  print('     LAST SEEN DELTA:',delta)


def ttnCheckCnt(gwId):
  import requests
  import json
  # gwId = 'eui-b827ebfffe3b5b2e'
  addr = 'http://noc.thethingsnetwork.org:8085/api/v2/gateways/'
  print('Check msg cnt for GwId:',gwId, '...')
  addr = addr + gwId
  r =  requests.get(addr)
  r = r.json()
  print('UPLINK=', r['uplink'])
  print('DOWNLINK=', r['downlink'])
  #print(r)

print("---------")
ttnCheckCnt('eui-b827ebfffeab5e51')
  
  # try this code online: https://repl.it/repls/SeparateScientificRoutine
  # repo: https://github.com/sosnus/iot-tul/blob/master/src/misc/ttnGwLodzStatus.py
  # REPL: https://repl.it/repls/SeparateScientificRoutine
