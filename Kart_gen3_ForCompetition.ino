#include <SoftwareSerial.h>
#include <AFMotor.h> //guide: https://learn.adafruit.com/adafruit-motor-shield/af-dcmotor-class

SoftwareSerial BT(10, 11); // RX | TX
AF_DCMotor motorL(3), motorR(4); //接腳座及頻率

String command;
int speedL = 0, speedR = 0;

void setup() 
{
  Serial.begin(9600);   // 與電腦序列埠連線
  Serial.println("BT(Bluetooth) is ready! type AT to set func:");

  BT.begin(9600);// 設定藍牙模組的連線速率

  motorL.setSpeed(0);    //可調轉速約150~到255
  motorL.run(RELEASE);
  motorR.setSpeed(0);    //可調轉速約150~到255
  motorR.run(RELEASE);
}

void loop() 
{
  BlueToothHandler();
  CommandHandler();
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
    char val = BT.read();
    Serial.print(val);
    command += val;
  }

}

void CommandHandler()
{
  if(command != "")
  {
    
  }
}




