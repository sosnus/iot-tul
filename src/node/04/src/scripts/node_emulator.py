import urllib.request
# if err run in cmd: pip3 install urllib3
from random import randint
import json    
import time
_login = 20 # Your SensorId
_password = "password_there!!!!!!"
for x in range(100):
    print("############################################")
    temp = 10 + (randint(0, 200)/10)
    body =  { "SensorId": _login, "Value":temp, "SensorPassword":_password}
    myurl = "https://lorastore20181206101456.azurewebsites.net/api/Measurements"
    req = urllib.request.Request(myurl)
    req.add_header('Content-Type', 'application/json; charset=utf-8')
    jsondata = json.dumps(body)
    jsondataasbytes = jsondata.encode('utf-8')   # needs to be bytes
    req.add_header('Content-Length', len(jsondataasbytes))
    print (jsondataasbytes)
    response = urllib.request.urlopen(req, jsondataasbytes)
    print(response.msg)
    print(response.status)
    print(response.read() )
    print("WAIT...")
    time.sleep(10)   
