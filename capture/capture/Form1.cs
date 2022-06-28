using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenCvSharp;

namespace capture
{
    public partial class Form1 : Form
    {

        private Mat _flame;

        public Form1()
        {
            InitializeComponent();
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

    }
}  

