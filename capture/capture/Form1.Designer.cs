namespace capture
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.rescanbtn = new System.Windows.Forms.Button();
            this.combox = new System.Windows.Forms.ComboBox();
            this.openbtn = new System.Windows.Forms.Button();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(280, 160);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(173, 52);
            this.button1.TabIndex = 0;
            this.button1.Text = "Start!";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(555, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "X-axis";
            // 
            // rescanbtn
            // 
            this.rescanbtn.Location = new System.Drawing.Point(44, 46);
            this.rescanbtn.Name = "rescanbtn";
            this.rescanbtn.Size = new System.Drawing.Size(103, 51);
            this.rescanbtn.TabIndex = 2;
            this.rescanbtn.Text = "ReScan";
            this.rescanbtn.UseVisualStyleBackColor = true;
            this.rescanbtn.Click += new System.EventHandler(this.rescanbtn_Click);
            // 
            // combox
            // 
            this.combox.FormattingEnabled = true;
            this.combox.Location = new System.Drawing.Point(153, 62);
            this.combox.Name = "combox";
            this.combox.Size = new System.Drawing.Size(121, 26);
            this.combox.TabIndex = 3;
            this.combox.Text = "-select-";
            // 
            // openbtn
            // 
            this.openbtn.Location = new System.Drawing.Point(280, 48);
            this.openbtn.Name = "openbtn";
            this.openbtn.Size = new System.Drawing.Size(75, 49);
            this.openbtn.TabIndex = 4;
            this.openbtn.Text = "Open";
            this.openbtn.UseVisualStyleBackColor = true;
            this.openbtn.Click += new System.EventHandler(this.openbtn_Click);
            // 
            // serialPort1
            // 
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 242);
            this.Controls.Add(this.openbtn);
            this.Controls.Add(this.combox);
            this.Controls.Add(this.rescanbtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "追尾カメラ";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button rescanbtn;
        private System.Windows.Forms.ComboBox combox;
        private System.Windows.Forms.Button openbtn;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Timer timer1;
    }
}

