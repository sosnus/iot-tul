///Jakub Stańczyk, 07.12.18 00:27, Łódź///
#include <Wire.h>
#include "DHT.h"
#include <hd44780.h>
#include <hd44780ioClass/hd44780_I2Cexp.h>
#define LIGHT A3
#define TEMP A2
#define POT A1
#define DHT11_PIN 6
#define PIR 5
#define BUZ 2
#define LED 13//LED
//#define RES 4//D4
DHT dht;
volatile bool pir = 0;
//volatile bool reset = 0;
int ileRazy=0;
int wilgotnosc, temperatura;
int buzzer=0;
hd44780_I2Cexp lcd(0x20, I2Cexp_MCP23008,7,6,5,4,3,2,1,HIGH);


void setup() {
  lcd.begin(16,2);
  Serial.begin(115200);
  dht.setup(DHT11_PIN);
  pinMode(PIR, INPUT); 
  //pinMode(RES, INPUT); 
  pinMode(LED, OUTPUT);
  pinMode(BUZ, OUTPUT);
  digitalWrite(LED, LOW);   
  attachInterrupt(digitalPinToInterrupt(PIR), alarm, RISING);
  ///attachInterrupt(digitalPinToInterrupt(RES), res, RISING);
}

void loop() {
  
   ///////////////LCD///////////////////////////////
  lcd.home();
  lcd.print("temp: ");
  lcd.print(temperatura);
  lcd.print("*C");
  lcd.setCursor(0,1);   
  lcd.print("wilg: ");
  lcd.print(wilgotnosc);
  lcd.print(" %");
  ////////////////dht11///////////////////////////////////
  //Pobranie informacji o wilgotnosci
   wilgotnosc = dht.getHumidity();
  //Pobranie informacji o temperaturze
   temperatura = dht.getTemperature();
  if (dht.getStatusString() == "OK") {
    Serial.print("DHT11: ");
    Serial.print(wilgotnosc);
    Serial.print("% | ");
    Serial.print(temperatura);
    Serial.println("*C");
  }
    delay(dht.getMinimumSamplingPeriod());
    
  ///////////////Analog input///////////////////////////////
  int potval=analogRead(POT);
  int lightvalue=analogRead(LIGHT);
  int tempvalue=(analogRead(TEMP)*0.125 - 22.0);
  int btnD3 = digitalRead(3);
  Serial.print("A1:");
  Serial.println(potval);
  Serial.println("A2:");
  Serial.println(tempvalue);   
  Serial.println("A3:");
  Serial.println(lightvalue);
  Serial.println("D3:");
  Serial.println(btnD3);
  
  ////////////////PIR///////////////////////////////////
  if(pir==1){
    pir=0;
    Serial.print("ruch");
    Serial.print("");
    ileRazy++;  
  }
  if(ileRazy>=6){
    digitalWrite(LED, HIGH);
  }
  if(ileRazy<6){
    digitalWrite(LED, LOW);
  }
////////////////reset-D4///////////////////////////////
/* if(reset==1){
    reset=0;
    Serial.print("reset");
    Serial.print("");
    delay(30);
    if(digitalRead(RES)==1){
    ileRazy=0; 
       }
  }*/
 ///buzzer////
  buzzer=buzzer+1;
  Serial.print("Buzzer: ");
  Serial.print(buzzer);
  if(buzzer<20){
    digitalWrite(BUZ,LOW);
  }
  if(buzzer>=20){
    digitalWrite(BUZ,HIGH);
  }
  if(buzzer>=25){
  buzzer=0;
  }
  
  delay(500);
  lcd.clear();
 
}


void alarm() { 
  pir=1; 
}
/*void res() { 
  reset=1; 
}*/
