# LoRaStore Backend <Name>

Documentation for LoRaStore Backend

# Database schematic
![Logo](./LoRaStore/img/5.png)

Browse DB Schema at dbdiagram.io: [LoRaStore Diagram](https://dbdiagram.io/d/5c3eb118dbc87000142e6d5f)<br>

```sql
Table sensors {
SensorId  int
SensorName  varchar
SensorPassword  varchar
SensorDescription  varchar
}

Table Measurement {
MeasurementId  int
MeasurementDate  datetime
Value  double
SensorId  int
}

Ref: "sensors"."SensorId" < "Measurement"."SensorId"
```

# API

## Add measurement record to DB

Prepare and send `HTTP POST application/json` request to addres: `https://lorastore20181206101456.azurewebsites.net/api/Measurements` <br>

```json
{ 
    "SensorId": 1,  //Int
    "Value": 124.23, // Double
    "SensorPassword": "Password" //String
}
```

Try Python script for interval POST requests:

```python
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
```


## Get list of each records for one sensor
Request `HTTP GET`: `https://lorastore20181206101456.azurewebsites.net/api/Measurements?id=<ID>` <br>
(Replace ID)
Example`HTTP GET`: `https://lorastore20181206101456.azurewebsites.net/api/Measurements?id=36` <br>
Test: [Get list of measurements from SensorID=36](https://lorastore20181206101456.azurewebsites.net/api/Measurements?id=36)<br>

#### an example of an answer to the query
![Logo](./LoRaStore/img/4.png)


## Sensors management

### (only for application administrator)

#### Login

![Logo](./LoRaStore/img/1.png)

#### Sensors management

![Logo](./LoRaStore/img/2.png)


#### Sensors editor

![Logo](./LoRaStore/img/3.png)

# Deploy LoRaStore at Your server

You can deploy LoRaStore solution and database at Your server (hosted on azure (or other cloud) or at home). <br>
For this, You need: <br>
LoraStore Solution: [LoRaStore Repositorium](https://github.com/sosnus/LoRaStore)  <br>
Instruction: [Host and deploy ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core/host-and-deploy/?view=aspnetcore-2.2)   <br>


# Deploy Dashboard at Your server

You can deploy LoRaStore solution and database at Your server (hosted on azure (or other cloud) or at home). <br>
For this, You need: <br>
Dashboard Repositorium: [LoRaStore Repositorium](https://github.com/sosnus/iot-tul)  <br>
Instruction: [How to deploy Your page to GitHub Pages](https://pages.github.com/)   <br>
