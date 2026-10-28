using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BAI01
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void UdpClient_Click(object sender, EventArgs e)
        {
            UDP_Client udpClient = new UDP_Client();
            udpClient.Show();
            
        }

        private void UdpSever_Click(object sender, EventArgs e)
        {
            UDP_Sever udpSever = new UDP_Sever();
            udpSever.Show();
        }
    }
}
