# manual <Name>
## ttn-tul-node-v1 manual

## Arduino configuration
### Download Arduino IDE
Link to the software is available on the website: https://www.arduino.cc/en/Main/Software.
### Test the Arduino Board 
he easiest way to test the Arduino board is to load the "Blink" example.
You can find the project in the menu File/Examples/01.Basics/Blink or go throught tutorial: https://www.arduino.cc/en/Tutorial/Blink.
### Install the LMIC-Arduino library and others (e.g. for LCD hd44780)
Go to Sketch/Include Library\Manage Libraries... and search for "LMIC-Arduino". Install the newest version.
# thethingsnetwork.com portal
### Sign up
### Create application and add device
# Get date to PŁ "LoraStore" portal
Ask administrator for them.
## Change Activation Method to ABP
## Add decoder function here https://console.thethingsnetwork.org/applications/ YOUR NAME OF APPLICATION /payload-formats 
Decoder function is available on our the github.
## Add HTTP integration here https://console.thethingsnetwork.org/applications/ YOUR NAME OF APPLICATION /integrations
ccess Key: default key
URL: https://ttn-parser-cs.azurewebsites.net/api/ttn-11-01-2019?code=A4HPfv9KqjDE2StqdZPc01j0eaZ0hJhDSqEy6QpTJyBYHy3jLCGyhg==
Method: POST
## Arduino + LoRa
### Check board
## Connect arduino uno to RFM95W module, potentiometer (A1 pin) and LCD (SDA,SCL).
## Download our example from https://github.com/jakuw/ttn-tul/tree/master/src/node/arduino_ttn.
Project "arduino ttn" contains three files:
 i. arduino_ttn - code responsible for connection with RFM95W module,
 ii. my_functions - here you place your part of code,
 iii. send_functions - functions, which convert data and create appropriate message.
## Replace following network data in "send_functions":
 		i. NWKSKEY
		ii. APPSKEY
		iii. DEVADDR
## Replace following sensor data in "send_functions":
  		i. SensorId
 		ii. SensorPassword
## Upload project
## Check data traffic in data tab on https://console.thethingsnetwork.org/applications website.
### Add your own part of code
My_functions file contains two standard functions: 
- setup - runs only once at the beginning.
- main - runs each cycle.
Here you can place your part of code.
### Good luck and have fun ; )