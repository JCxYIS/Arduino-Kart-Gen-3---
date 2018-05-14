#include <SoftwareSerial.h>
#include <AFMotor.h> //guide: https://learn.adafruit.com/adafruit-motor-shield/af-dcmotor-class

SoftwareSerial BT(10, 11); // RX | TX
AF_DCMotor motorL(3), motorR(4); //接腳座及頻率

char command[20];
int speedL = 0, speedR = 0;

void setup() 
{
  Serial.begin(9600);   // 與電腦序列埠連線
  Serial.println("BT(Bluetooth) is ready! type AT to set func:");

  BT.begin(9600);// 設定藍牙模組的連線速率
  command[0] = ' ';

  motorL.setSpeed(0);    //可調轉速約150~到255
  motorL.run(RELEASE);
  motorR.setSpeed(0);    //可調轉速約150~到255
  motorR.run(RELEASE);
}

void loop() 
{
  BlueToothHandler();
  CommandHandler();
  MotorMovement(speedL, speedR);
}

//這裡處理藍芽事宜
void BlueToothHandler()
{
  // 若收到「序列埠監控視窗」的資料，則送到藍牙模組
  if (Serial.available()) 
  {
    char val = Serial.read();
    BT.print(val);
  }
  // 若收到藍牙模組的資料，則送到「序列埠監控視窗」，並加入command
  if (BT.available())
  {
    int inSize = BT.available();
    for (int i = 0; i < inSize; i++)
    {
        byte tmp = BT.read();
        command[i] = (char)tmp;
        Serial.print("BT Get: ");
        Serial.print(command[i]);
    }
  }
  

}
//把command轉化為各參數
void CommandHandler()
{
  switch(command[0])
  {
    case ' ':
    break;

    case 'M'://mod Motor speed, 001~205 //EX: M-048+163
      speedL = command[2]*100 + command[3]*10 + command[4];
      speedR = command[6]*100 + command[7]*10 + command[8];
      if(command[1] == '-'){speedL *= -1;}
      if(command[5] == '-'){speedR *= -1;}
    break;

    default:
      Serial.println("CommandNotSupportError: Doesn't support this function!");
      break;
  }
  for(int i = 0; i<20; i++)
  {
    command[i] = ' ';
  }
}
//負責馬達
void MotorMovement(int l, int r)
{
  if(l < 0)
  {
    l *= -1;
    motorL.setSpeed(l);
    motorL.run(BACKWARD);
  }
  else if(l > 0)
  {
    motorL.setSpeed(l);
    motorL.run(FORWARD);
  }
  else
  {
    motorL.run(RELEASE);
  }
  if(r < 0)
  {
    r *= -1;
    motorR.setSpeed(r);
    motorR.run(BACKWARD);
  }
  else if(r > 0)
  {
    motorR.setSpeed(r);
    motorR.run(FORWARD);
  }
  else
  {
    motorR.run(RELEASE);
  }
}




