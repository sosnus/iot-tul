uint8_t NWKSKEY[16] = { 0x02, 0x00, 0x59, 0x05, 0x00, 0xE2, 0x02, 0x80, 0xEA, 0x07, 0xE0, 0x31, 0x00, 0x20, 0x96, 0x06 };
uint8_t APPSKEY[16] = { 0x00, 0xD0, 0x8C, 0x05, 0x80, 0xEC, 0x03, 0x30, 0x64, 0x03, 0xF0, 0x9E, 0x07, 0x60, 0x60, 0x0F };
u4_t DEVADDR = 0x26011787;

char SensorID[]= "346";
char SensorPassword[] = "pass";

void send_message(double *value);
void make_message(char *ID, uint8_t rID, char *password, uint8_t rpass, double data);

double values[10];

extern uint8_t sended;
uint8_t sended_counter=0;
uint32_t message_counter=0;
extern uint8_t mydata[48];



void send_message(double *value)
{ 
  if(sended==1)
  {
      make_message(SensorID,sizeof(SensorID),SensorPassword,sizeof(SensorPassword),values[sended_counter]);
      sended=0;
      sended_counter++;
      message_counter++;
      if(sended_counter==NUMBER_OF_MEASUREMENTS)
      {
        sended_counter=0;
      }
  }
}

void make_message(char *ID, uint8_t rID, char *password, uint8_t rpass, double data)
{
  uint8_t temps[32];
  uint8_t temp=0;
  uint8_t temp2=0;

  temp=rID;
  for (uint8_t i=0;i<8;i++)
  {
    if(i>(8-temp))
    {
      mydata[i]=ID[i+temp-9];
    }
    else
    {
      mydata[i]=48;
    }
    Serial.print(mydata[i]);
  }

  temp=rpass;
  for (uint8_t i=0;i<8;i++)
  {
    if(i>(8-temp))
    {
      mydata[8+i]=password[i+temp-9];
    }
    else
    {
      mydata[8+i]=48;
    }
    Serial.print(mydata[8+i]);
  }

  dtostrf(data,16,16,temps);
  temp=0;
  temp2=0;
  for (uint8_t i=0;i<32;i++)
  {
     if((temps[i]==46) || (temp2==1))
     {
        temp++;
        temp2=1;
     }
     if(temp<16)
     {
      mydata[16+i]=temps[i];
     }  
     else
     {
      mydata[16+i]=48;
     }
     Serial.print(mydata[16+i]);
  }
  Serial.println() ;

}
