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
 

Stepper myStepper(StepsPerRotate, MOTOR_PIN1, MOTOR_PIN3, MOTOR_PIN2, MOTOR_PIN4); 
 
void setup() { 
  Serial.begin(9600);      // シリアル通信の初期化 
  myStepper.setSpeed(rpm);  // rpmを設定 
} 
 
void loop() { 

    char key;     // 受信データを格納するchar型の変数

  // 受信データがあった時だけ、処理を行う
  if ( Serial.available() ) {       // 受信データがあるか？
    key = Serial.read();            // 1文字だけ読み込む
//    Serial.write( key );            // 1文字送信。受信データをそのまま送り返す。

    // keyの文字に応じて、行う処理を切り替える
    switch( key ) {
      // rキーが押された時の処理
      case 'r':
          myStepper.step(85); //15deg
          delay(500);
          while (Serial.available())Serial.read();
          Serial.println('e');
        break;

      // lキーが押された時の処理
      case 'l':          
          myStepper.step(-85); //-15deg
          delay(500);
          while (Serial.available())Serial.read();
          Serial.println('e');
        break;

      // 上記以外の場合の処理(何もしない)
      default:
        break;
    } //switch文の末尾
  } // if文の末尾

}
