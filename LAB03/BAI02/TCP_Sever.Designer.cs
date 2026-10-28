namespace BAI02
{
    partial class TCP_Sever
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
            btnListen = new Button();
            lvMess = new ListView();
            SuspendLayout();
            // 
            // btnListen
            // 
            btnListen.Location = new Point(414, 28);
            btnListen.Name = "btnListen";
            btnListen.Size = new Size(159, 45);
            btnListen.TabIndex = 0;
            btnListen.Text = "Listen";
            btnListen.UseVisualStyleBackColor = true;
            btnListen.Click += this.btnListen_Click;
            // 
            // lvMess
            // 
            lvMess.Location = new Point(48, 89);
            lvMess.Name = "lvMess";
            lvMess.Size = new Size(525, 391);
            lvMess.TabIndex = 1;
            lvMess.UseCompatibleStateImageBehavior = false;
            // 
            // TCP_Sever
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(606, 522);
            Controls.Add(lvMess);
            Controls.Add(btnListen);
            Name = "TCP_Sever";
            Text = "TCP Sever";
            ResumeLayout(false);
        }

        #endregion

        private Button btnListen;
        private ListView lvMess;
    }
}
