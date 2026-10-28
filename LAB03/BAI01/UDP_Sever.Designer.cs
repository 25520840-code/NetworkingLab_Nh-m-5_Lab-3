namespace BAI01
{
    partial class UDP_Sever
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
            txtPort = new TextBox();
            btnListen = new Button();
            label2 = new Label();
            lvMess = new ListView();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(55, 32);
            label1.Name = "label1";
            label1.Size = new Size(44, 25);
            label1.TabIndex = 0;
            label1.Text = "Port";
            // 
            // txtPort
            // 
            txtPort.Location = new Point(105, 32);
            txtPort.Name = "txtPort";
            txtPort.Size = new Size(228, 31);
            txtPort.TabIndex = 1;
            // 
            // btnListen
            // 
            btnListen.Location = new Point(606, 29);
            btnListen.Name = "btnListen";
            btnListen.Size = new Size(112, 34);
            btnListen.TabIndex = 2;
            btnListen.Text = "Listen";
            btnListen.UseVisualStyleBackColor = true;
            btnListen.Click += btnListen_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(55, 116);
            label2.Name = "label2";
            label2.Size = new Size(156, 25);
            label2.TabIndex = 3;
            label2.Text = "Received Message";
            // 
            // lvMess
            // 
            lvMess.Location = new Point(55, 144);
            lvMess.Name = "lvMess";
            lvMess.Size = new Size(663, 273);
            lvMess.TabIndex = 4;
            lvMess.UseCompatibleStateImageBehavior = false;
            // 
            // UDP_Sever
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(770, 450);
            Controls.Add(lvMess);
            Controls.Add(label2);
            Controls.Add(btnListen);
            Controls.Add(txtPort);
            Controls.Add(label1);
            Name = "UDP_Sever";
            Text = "Form3";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtPort;
        private Button btnListen;
        private Label label2;
        private ListView lvMess;
    }
}