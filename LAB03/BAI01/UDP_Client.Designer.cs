namespace BAI01
{
    partial class UDP_Client
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            txtIP = new TextBox();
            txtPort = new TextBox();
            label3 = new Label();
            btnSend = new Button();
            lvMessage = new RichTextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(46, 57);
            label1.Name = "label1";
            label1.Size = new Size(136, 25);
            label1.TabIndex = 0;
            label1.Text = "IP Remote Host";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(437, 57);
            label2.Name = "label2";
            label2.Size = new Size(44, 25);
            label2.TabIndex = 1;
            label2.Text = "Port";
            // 
            // txtIP
            // 
            txtIP.Location = new Point(46, 90);
            txtIP.Name = "txtIP";
            txtIP.Size = new Size(333, 31);
            txtIP.TabIndex = 2;
            // 
            // txtPort
            // 
            txtPort.Location = new Point(437, 90);
            txtPort.Name = "txtPort";
            txtPort.Size = new Size(263, 31);
            txtPort.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(46, 170);
            label3.Name = "label3";
            label3.Size = new Size(82, 25);
            label3.TabIndex = 4;
            label3.Text = "Message";
            // 
            // btnSend
            // 
            btnSend.Location = new Point(46, 399);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(138, 39);
            btnSend.TabIndex = 6;
            btnSend.Text = "Send";
            btnSend.UseVisualStyleBackColor = true;
            btnSend.Click += btnSend_Click;
            // 
            // lvMessage
            // 
            lvMessage.Location = new Point(46, 198);
            lvMessage.Name = "lvMessage";
            lvMessage.Size = new Size(646, 144);
            lvMessage.TabIndex = 7;
            lvMessage.Text = "";
            // 
            // UDP_Client
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(750, 450);
            Controls.Add(lvMessage);
            Controls.Add(btnSend);
            Controls.Add(label3);
            Controls.Add(txtPort);
            Controls.Add(txtIP);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "UDP_Client";
            Text = "UDP Client";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox txtIP;
        private TextBox txtPort;
        private Label label3;
        private Button btnSend;
        private RichTextBox lvMessage;
    }
}