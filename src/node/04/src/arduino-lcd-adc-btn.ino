#include <Wire.h>
#include <hd44780.h>
#include <hd44780ioClass/hd44780_I2Cexp.h>
#define LIGHT A3
#define TEMP A2
#define POT A1

hd44780_I2Cexp lcd(0x20, I2Cexp_MCP23008,7,6,5,4,3,2,1,HIGH);
void setup() {
  lcd.begin(16,2);
}

void loop() {
  int potval=analogRead(POT);
  int lightvalue=analogRead(LIGHT);
  int tempvalue=(analogRead(TEMP)*0.125 - 22.0);
  int btnD3 = digitalRead(3);
    lcd.home();
   lcd.print("A1:");
   lcd.print(potval);
  lcd.setCursor(8,0);
   lcd.print("A2:");
   lcd.print(tempvalue); 
  lcd.setCursor(0,1);   
   lcd.print("A3:");
   lcd.print(lightvalue);
  lcd.setCursor(8,1);
   lcd.print("D3:");
   lcd.print(btnD3);
  delay(500);
  lcd.clear();
}
