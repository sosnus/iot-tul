extern double values[10];
extern void send_message(double *value);
extern uint32_t message_counter;

#define NUMBER_OF_MEASUREMENTS 1



#include <Wire.h>
#include <hd44780.h>
#include <hd44780ioClass/hd44780_I2Cexp.h>
#define LIGHT A3
#define TEMP A2
#define POT A1

double value1=97.323;
double value2=2.412;

hd44780_I2Cexp lcd(0x20, I2Cexp_MCP23008,7,6,5,4,3,2,1,HIGH);

void my_setup(void)
{
  lcd.begin(16,2);
  values[0]=value1;
  values[1]=value2;
}



void my_main(void)
{

  values[0] = analogRead(LIGHT)* (5.0 / 1023.0);
  lcd.home();
  lcd.print("Cnt:");
  lcd.print(message_counter);
  lcd.setCursor(0,1);
  lcd.print("ADC:");
  lcd.print(analogRead(LIGHT)); 
  delay(500);
  lcd.clear();
  
  send_message(values);
}
