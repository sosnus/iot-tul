# LoRaStore <Name>

# Database schematic
![alt text][5]
[5]: https://raw.githubusercontent.com/sosnus/iot-tul-dashboard/master/docs/img/admin/5.PNG "Database schematic"
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
Try Python script for interval POST requests: [node_emulator.py](https://github.com/sosnus/ttn-tul/blob/master/src/scripts/node_emulator.py)<br>

## Get list of each records for one sensor
Request `HTTP GET`: `https://lorastore20181206101456.azurewebsites.net/api/Measurements?id=<ID>` <br>
(Replace ID)
Example`HTTP GET`: `https://lorastore20181206101456.azurewebsites.net/api/Measurements?id=36` <br>
Test: [Get list of measurements from SensorID=36](https://lorastore20181206101456.azurewebsites.net/api/Measurements?id=36)<br>

### an example of an answer to the query
![alt text][4]
[4]: https://raw.githubusercontent.com/sosnus/iot-tul-dashboard/master/docs/img/admin/4.PNG "an example of an answer to the query"

# Sensors management (only for application administrator)

### Login
![alt text][1]
[1]: https://raw.githubusercontent.com/sosnus/iot-tul-dashboard/master/docs/img/admin/1.PNG "Login"

### Sensors management
![alt text][2]
[2]: https://raw.githubusercontent.com/sosnus/iot-tul-dashboard/master/docs/img/admin/2.PNG "Sensors management"

### Sensors editor
![alt text][3]
[3]: https://raw.githubusercontent.com/sosnus/iot-tul-dashboard/master/docs/img/admin/3.PNG "Sensors editor"