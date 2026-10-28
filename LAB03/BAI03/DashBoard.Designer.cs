namespace BAI03
{
    partial class DashBoard
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnClient = new Button();
            btnSever = new Button();
            SuspendLayout();
            // 
            // btnClient
            // 
            btnClient.Location = new Point(60, 40);
            btnClient.Name = "btnClient";
            btnClient.Size = new Size(266, 57);
            btnClient.TabIndex = 0;
            btnClient.Text = "TCP Client";
            btnClient.UseVisualStyleBackColor = true;
            btnClient.Click += btnClient_Click;
            // 
            // btnSever
            // 
            btnSever.Location = new Point(367, 40);
            btnSever.Name = "btnSever";
            btnSever.Size = new Size(264, 57);
            btnSever.TabIndex = 1;
            btnSever.Text = "TCP Sever";
            btnSever.UseVisualStyleBackColor = true;
            btnSever.Click += btnSever_Click;
            // 
            // DashBoard
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(693, 130);
            Controls.Add(btnSever);
            Controls.Add(btnClient);
            Name = "DashBoard";
            Text = "DashBoard";
            ResumeLayout(false);
        }

        #endregion

        private Button btnClient;
        private Button btnSever;
    }
}
