namespace BAI01
{
    partial class Dashboard
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
            UdpSever = new Button();
            UdpClient = new Button();
            SuspendLayout();
            // 
            // UdpSever
            // 
            UdpSever.Location = new Point(311, 46);
            UdpSever.Name = "UdpSever";
            UdpSever.Size = new Size(189, 42);
            UdpSever.TabIndex = 0;
            UdpSever.Text = "UDP Sever";
            UdpSever.UseVisualStyleBackColor = true;
            UdpSever.Click += UdpSever_Click;
            // 
            // UdpClient
            // 
            UdpClient.Location = new Point(38, 46);
            UdpClient.Name = "UdpClient";
            UdpClient.Size = new Size(189, 42);
            UdpClient.TabIndex = 1;
            UdpClient.Text = "UDP Client";
            UdpClient.UseVisualStyleBackColor = true;
            UdpClient.Click += UdpClient_Click;
            // 
            // Dashboard
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(546, 128);
            Controls.Add(UdpClient);
            Controls.Add(UdpSever);
            Name = "Dashboard";
            Text = "Dashboard";
            ResumeLayout(false);
        }

        #endregion

        private Button UdpSever;
        private Button UdpClient;
    }
}