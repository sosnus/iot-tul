import urllib.request
import json    
_login = 30 # Your SensorId
_password = "aaa"
temp = 2
body =  { "SensorId": _login, "Value":temp, "SensorPassword":_password}
myurl = "https://lorastore20181206101456.azurewebsites.net/api/Measurements"
req = urllib.request.Request(myurl)
req.add_header('Content-Type', 'application/json; charset=utf-8')
jsondata = json.dumps(body)
jsondataasbytes = jsondata.encode('utf-8')   # needs to be bytes
req.add_header('Content-Length', len(jsondataasbytes))
response = urllib.request.urlopen(req, jsondataasbytes)
print(response.msg)
print(response.status)
print(response.read() )
