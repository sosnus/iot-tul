# Manual ttn-tul-node-v1

## Arduino configuration
### Asemble Arduino Board
In our project we use additional board provided by TME. It allows us to display data on the LCD and makes connecting sensors more confortable. If you use it also, remember to put all jumpers like on the picture.

![alt text](https://github.com/sosnus/ttn-tul/blob/master/docs/Node/TME_board.png "Logo Title Text 1")
### Download Arduino IDE
In our project we use 1.8.19.0 version. 

Link to the software is available on the website: https://www.arduino.cc/en/Main/Software. 
### Test the Arduino Board 
The easiest way to test the Arduino board is to load the "Blink" example.

You can find the project in the menu File/Examples/01.Basics/Blink or go throught tutorial: https://www.arduino.cc/en/Tutorial/Blink.

### Install the LMIC-Arduino library and others (e.g. for LCD hd44780)
Go to Sketch/Include Library\Manage Libraries... and search for "LMIC-Arduino". Install the newest version.

"LMIC-Arduino" provides template with simple real time operating system and function, which sends data.

![alt text](https://github.com/sosnus/ttn-tul/blob/master/docs/Node/libraries.png "Logo Title Text 1")
# thethingsnetwork.com portal
### Sign up
### Create application and add device
# Get date to PŁ "LoraStore" portal
Ask administrator for them.
## Change Activation Method to ABP

Example of settings of the device is presented the picture.

![alt text](https://github.com/sosnus/ttn-tul/blob/master/docs/Node/device_settings.png "Logo Title Text 1")

## Add decoder function

Decoder function converts array of asci signs to json format.

Go to the website: https://console.thethingsnetwork.org/applications/ **YOUR NAME OF APPLICATION** /payload-formats 

and add the folowing code:

```javascript
function Decoder(bytes, port) {
  var decoded = {sensorID:"",sensorPassword:"",Value:""};
  var flag=0;
  for (i=0;i<8;i++)
  {
    if ((String.fromCharCode(bytes[i]) != "0") || flag==1)
    {
      decoded.sensorID += String.fromCharCode(bytes[i]);
      flag=1;
    }
  }
  for (i=0;i<8;i++)
  {
    if (String.fromCharCode(bytes[8+i]) != "0")
    {
      decoded.sensorPassword += String.fromCharCode(bytes[8+i]);
    }
  }
  var flaga=0;
  for (i=0;i<16;i++)
  {
    if ((String.fromCharCode(bytes[16+i]) != "0") | (flaga === 1))
    {
      decoded.Value += String.fromCharCode(bytes[16+i]);
      flaga=1;
    }
  }
  return decoded;
}
```

## Add HTTP integration


Go to the: https://console.thethingsnetwork.org/applications/ **YOUR NAME OF APPLICATION** /integrations

Set only the following parameters:
1. Access Key: default key
2. URL: https://ttn-parser-cs.azurewebsites.net/api/ttn-11-01-2019?code=A4HPfv9KqjDE2StqdZPc01j0eaZ0hJhDSqEy6QpTJyBYHy3jLCGyhg==
3. Method: POST
Anything else left default.

### Check board
## Download our example

Take project from our repository: https://github.com/jakuw/ttn-tul/tree/master/src/node/arduino_ttn.

Project "arduino ttn" contains three files:
1. arduino_ttn - code responsible for connection with RFM95W module,
2. my_functions - here you place your part of code,
3. send_functions - functions, which convert data and create appropriate message.

You can find "add new tab" on the drop-down list like on the picture.

![alt text](https://github.com/sosnus/ttn-tul/blob/master/docs/Node/list_new_tab.png "Logo Title Text 1")

## Replace following network data in "send_functions":
 		i. NWKSKEY
		ii. APPSKEY
		iii. DEVADDR
Take data from https://console.thethingsnetwork.org/applications/ **YOUR NAME OF APPLICATION** /devices/ **YOUR DEVICE**

![alt text](https://github.com/sosnus/ttn-tul/blob/master/docs/Node/data1.png "Logo Title Text 1")
		
## Replace following sensor data in "send_functions":
  		i. SensorId
 		ii. SensorPassword
This data you should get from the administrator.		
		
## Upload project
## Check data traffic

Go to the https://console.thethingsnetwork.org/applications website and open data tab.

### Add your own part of code
My_functions file contains two standard functions: 
- setup - runs only once at the beginning.
- main - runs each cycle.
Here you can place your part of code.
### Good luck and have fun ; )
