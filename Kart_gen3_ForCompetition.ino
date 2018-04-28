#include <SoftwareSerial.h>

SoftwareSerial BT(10, 11); // RX | TX
char val;  // 儲存接收資料的變數

void setup() {
  Serial.begin(9600);   // 與電腦序列埠連線
  Serial.println("BT is ready! type AT to set func");

  BT.begin(9600);// 設定藍牙模組的連線速率
}

void loop() {
  // 若收到「序列埠監控視窗」的資料，則送到藍牙模組
  if (Serial.available())
  {
    val = Serial.read();
    BT.print(val);
  }
  // 若收到藍牙模組的資料，則送到「序列埠監控視窗」
  if (BT.available())
  {
    val = BT.read();
    Serial.print(val);
  }
}
