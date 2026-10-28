namespace BAI03
{
    partial class TCP_Client
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
            btnSend = new Button();
            btnConnect = new Button();
            btnDisconnect = new Button();
            rtbMessage = new RichTextBox();
            SuspendLayout();
            // 
            // btnSend
            // 
            btnSend.Location = new Point(593, 112);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(169, 54);
            btnSend.TabIndex = 0;
            btnSend.Text = "Send";
            btnSend.UseVisualStyleBackColor = true;
            btnSend.Click += btnSend_Click;
            // 
            // btnConnect
            // 
            btnConnect.Location = new Point(593, 28);
            btnConnect.Name = "btnConnect";
            btnConnect.Size = new Size(169, 54);
            btnConnect.TabIndex = 1;
            btnConnect.Text = "Connect";
            btnConnect.UseVisualStyleBackColor = true;
            btnConnect.Click += btnConnect_Click;
            // 
            // btnDisconnect
            // 
            btnDisconnect.Location = new Point(593, 196);
            btnDisconnect.Name = "btnDisconnect";
            btnDisconnect.Size = new Size(169, 54);
            btnDisconnect.TabIndex = 2;
            btnDisconnect.Text = "Disconnect";
            btnDisconnect.UseVisualStyleBackColor = true;
            // 
            // rtbMessage
            // 
            rtbMessage.Location = new Point(12, 28);
            rtbMessage.Name = "rtbMessage";
            rtbMessage.Size = new Size(546, 222);
            rtbMessage.TabIndex = 3;
            rtbMessage.Text = "";
            // 
            // TCP_Client
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 280);
            Controls.Add(rtbMessage);
            Controls.Add(btnDisconnect);
            Controls.Add(btnConnect);
            Controls.Add(btnSend);
            Name = "TCP_Client";
            Text = "Form2";
            ResumeLayout(false);
        }

        #endregion

        private Button btnSend;
        private Button btnConnect;
        private Button btnDisconnect;
        private RichTextBox rtbMessage;
    }
}