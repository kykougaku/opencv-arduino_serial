using OpenCvSharp;

namespace cap1
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
             //VideoCapture�쐬
                var capture = new VideoCapture();
            
                //�J�����̋N���@
                capture.Open(0); //change by cameras

                //�摜�擾�p��Mat���쐬
                _flame = new Mat();


                Cv2.NamedWindow("Capture",WindowFlags.AutoSize);


                while (capture.IsOpened())
                {
                 
                capture.Read(_flame);
                Mat mat = _flame;

                int n = 0;
                int m = 0;

                    // ���ދ@�̗p��
                    using (CascadeClassifier cascade = new CascadeClassifier(@"C:\opencv\sources\data\haarcascades\haarcascade_frontalface_default.xml"))
                    {
                        foreach (Rect rectFace in cascade.DetectMultiScale(mat))
                        {
                        n++;
                        // ���������ꏊ�ɐԘg��\��
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