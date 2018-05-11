#include <SoftwareSerial.h>
#include <AFMotor.h> /guide: https://learn.adafruit.com/adafruit-motor-shield/af-dcmotor-class

SoftwareSerial BT(10, 11); // RX | TX
AF_DCMotor motor(3); //接腳座及頻率

char mode;

void setup() 
{
  Serial.begin(9600);   // 與電腦序列埠連線
  Serial.println("BT(Bluetooth) is ready! type AT to set func:");

  BT.begin(9600);// 設定藍牙模組的連線速率

  motor.setSpeed(200);    //可調轉速約150~到255
}

void loop() 
{
  BlueToothHandler();
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
  // 若收到藍牙模組的資料，則送到「序列埠監控視窗」
  if (BT.available())
  {
    char val = BT.read();
    Serial.print(val);
  }

}




