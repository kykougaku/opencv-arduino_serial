/*#define SIG_PIN 2 // D1

void setup() {
  Serial.begin(115200);
  pinMode(SIG_PIN, OUTPUT);
  digitalWrite(SIG_PIN, LOW);
  delay(2);
}



void loop() {
 for(int i =0;i<1900;i+=3){
  servo(i);
 }
}

void servo(int kdeg){
  if(kdeg<1900){
    //int duration_H = 2400; // (2.4ms - 0.5ms) / 2 + 0.5ms
    int duration_L = 20000 - kdeg; // 20ms - 1.45ms
    digitalWrite(SIG_PIN, HIGH);
    delayMicroseconds(kdeg);
    digitalWrite(SIG_PIN, LOW);
    delayMicroseconds(duration_L);
}
  }*/

#include <Stepper.h> 
 
#define MOTOR_PIN1 5  // 使用するモータのpin 
#define MOTOR_PIN2 6 
#define MOTOR_PIN3 7 
#define MOTOR_PIN4 8 
#define STEPS_PER_ROTATE_28BYJ48 2048 // 1回転に必要なステップ数. 360[deg] / 5.625[deg/step] / 2(相励磁) * 64(gear比) 
 
const int StepsPerRotate = STEPS_PER_ROTATE_28BYJ48; 
 
// 毎分の回転数(rpm) 
int rpm = 15; // 1-15rpmでないと動かない 
 
// モータに与えるステップ数 
int Steps = 512; // 90度回転. 360deg : 90deg = 2048 : 512 
 
// ライブラリとモータ配線の整合性を取り, C1, C2を入れ替える 
// ref https://github.com/arduino-libraries/Stepper/blob/master/src/Stepper.cpp 
Stepper myStepper(StepsPerRotate, MOTOR_PIN1, MOTOR_PIN3, MOTOR_PIN2, MOTOR_PIN4); 
 
void setup() { 
  Serial.begin(9600);      // シリアル通信の初期化 
  myStepper.setSpeed(rpm);  // rpmを設定 
} 
 
void loop() { 
  // ステッピングモータを回転 
  Serial.println("Rotate"); 
  myStepper.step(Steps); 
  delay(500); 
  Serial.println(); 
}
