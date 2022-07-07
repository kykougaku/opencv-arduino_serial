using System;
using System.IO.Ports;
using System.Windows.Forms;
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
            capture.Open(0); //change by cameras

            //画像取得用のMatを作成
            _flame = new Mat();


            Cv2.NamedWindow("Capture", WindowFlags.AutoSize);


            while (capture.IsOpened())
            {

                capture.Read(_flame);
                Mat mat = _flame;

                int n = 0;
                int m = 0;

                // 分類機の用意
                using (CascadeClassifier cascade = new CascadeClassifier(@"C:\opencv\sources\data\haarcascades\haarcascade_frontalface_default.xml"))
                {
                    foreach (Rect rectFace in cascade.DetectMultiScale(mat))
                    {
                        n++;
                        // 見つかった場所に赤枠を表示
                        Rect rect = new Rect(rectFace.X, rectFace.Y, rectFace.Width, rectFace.Height);
                        Cv2.Rectangle(mat, rect, new OpenCvSharp.Scalar(0, 0, 255), 2);
                        m = rectFace.X + (rectFace.Width / 2);
                    }
                }
                if (n != 0)
                {
                    m = m / n;
                    label1.Text = m.ToString();// 0~640
                    if(m <= 200 && k == 1)
                    {
                        serialPort1.Write("r\r\n");
                        k = 0;
                    }
                    else if(440 <= m && k == 1)
                    {
                        serialPort1.Write("l\r\n");
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

        private void button2_Click(object sender, EventArgs e)
        {
            k = 1;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            k = 1;
        }
    }
}  

