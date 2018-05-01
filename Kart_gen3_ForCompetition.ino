#include <SoftwareSerial.h>

SoftwareSerial BT(10, 11); // RX | TX
const int W2_2 = 12, W2_1 = 13;
const int W1_1 = 10, W1_2 = 11; //wheel output
const int servo = 9, minhz = 1000, maxhz = 2000; //servo


char mode;

void setup() 
{
  Serial.begin(9600);   // 與電腦序列埠連線
  Serial.println("BT(Bluetooth) is ready! type AT to set func:");

  BT.begin(9600);// 設定藍牙模組的連線速率

  pinMode(W1_1, OUTPUT);
  pinMode(W1_2, OUTPUT);
  pinMode(W2_1, OUTPUT);
  pinMode(W2_2, OUTPUT);
  myservo.attach(servo, minhz, maxhz);
  pinMode(ir1, INPUT);
  pinMode(ir2, INPUT);
  pinMode(eyetrig, OUTPUT);
  pinMode(eyeecho, INPUT)
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
    val = BT.read();
    Serial.print(val);
  }

  void motor(int xxx)
  {
   //no=0; only ir1 = 1; only ir2 = 2; both = 3
  switch (xxx)
  {
    case 0: //no, (no use?)
      digitalWrite(W1_1, LOW);
  }

}

void lets_servo()
{
 // motor(0xC8763);
  digitalWrite(W1_1, LOW);
  digitalWrite(W1_2, LOW);
  digitalWrite(W2_1, LOW);
  digitalWrite(W2_2, LOW);
  for (int pos = 0; pos <= 25; pos += 1) 
  {
    myservo.write(pos);
    delay(15);
  }
  digitalWrite(W1_1, LOW);
  digitalWrite(W1_2, HIGH);
  digitalWrite(W2_1, LOW);
  digitalWrite(W2_2, HIGH);
  delay(2017);
  digitalWrite(W1_1, LOW);
  digitalWrite(W1_2, LOW);
  digitalWrite(W2_1, LOW);
  digitalWrite(W2_2, LOW);
  for (int pos = 30; pos <= 110; pos += 1) {
    myservo.write(pos);
    delay(15);
  }
}

}
