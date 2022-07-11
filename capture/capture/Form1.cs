using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using OpenCvSharp;

namespace capture
{
    public partial class Form1 : Form
    {

        private Mat _flame;
        public int k = 1;
        public char str;

        private void scanCOMPorts()
        {
            combox.Items.Clear();
            string[] ports = SerialPort.GetPortNames();
            foreach (string p in ports)
            {
                combox.Items.Add(p);
            }
        }

        public Form1()
        {
            InitializeComponent();
            scanCOMPorts();
        }



        private void button1_Click(object sender, EventArgs e)
        {
            //VideoCapture作成
            var capture = new VideoCapture();

            //カメラの起動　
            capture.Open(1); //change by cameras

            //画像取得用のMatを作成
            _flame = new Mat();

            //キャプチャ画面の生成
            Cv2.NamedWindow("Capture", WindowFlags.AutoSize);
            
            while (capture.IsOpened())
            {
                //webカメラ画像の読み込み
                capture.Read(_flame);
                Mat mat = _flame;
                //顔の数カウント変数
                int n = 0;
                int m = 0;

                // 分類機の用意
                using (CascadeClassifier cascade = new CascadeClassifier(@"C:\opencv\sources\data\haarcascades\haarcascade_frontalface_default.xml"))
                {
                    //gray画像用の変数の用意
                    Mat gray = new Mat();
                    //顔認識用のgray化画像を用意
                    Cv2.CvtColor(mat,gray, ColorConversionCodes.RGB2GRAY);

                    foreach (Rect rectFace in cascade.DetectMultiScale(gray, 1.1, 8))
                    {
                        // 見つかった場所に赤枠を表示
                        Rect rect = new Rect(rectFace.X, rectFace.Y, rectFace.Width, rectFace.Height);
                        Cv2.Rectangle(mat, rect, new OpenCvSharp.Scalar(0, 0, 255), 2);

                        //認識した顔画像の座標と個数を記録
                        n++;
                        m += rectFace.X + (rectFace.Width / 2);
                    }
                }
                if (n != 0)
                {
                    //認識された複数の顔の平均した座標を計算
                    m = m / n;
                    label1.Text = m.ToString();// デバッグ用_0~640で変化

                    if(m <= 230 && k == 1)
                    {
                        serialPort1.Write("l\r\n");
                        k = 0;
                    }
                    else if(230<m && m<410)
                    {
                        Cv2.ImWrite(@"C:\testimage\image.jpg", mat);//中心に捉えたら画像を保存
                    }
                    else if(410 <= m && k == 1)
                    {
                        serialPort1.Write("r\r\n");
                        k = 0;
                    }
                }

                Cv2.ImShow("Capture", mat);

                int key = Cv2.WaitKey(2);
                if (key == '\x1b')
                {
                    break;
                }

            }
            Cv2.DestroyWindow("Capture");
        }

        private void rescanbtn_Click(object sender, EventArgs e)
        {
            scanCOMPorts();
        }

        private void openbtn_Click(object sender, EventArgs e)
        {
            try
            {
                serialPort1.PortName = combox.Text; // COM名設定
                serialPort1.Open();                     // ポート接続
            }
            catch
            {
                serialPort1.Close();     // 切断ボタンを押す
            }
        }

        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            str = (char)serialPort1.ReadChar();
            this.Invoke(new EventHandler(moved));
        }
        private void moved(object sender, EventArgs e)
        {
            if(str == 'e') { 
                k = 1;
                str = 'n';
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            k = 1;
        }
    }
}  

