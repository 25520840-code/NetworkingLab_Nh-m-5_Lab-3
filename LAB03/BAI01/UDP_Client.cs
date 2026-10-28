using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace BAI01
{
    public partial class UDP_Client : Form
    {
        private UdpClient udpClient;

        public UDP_Client()
        {
            InitializeComponent();
        }
        private void btnSend_Click(object sender, EventArgs e)
        {
            //lấy IP & Port
            string ipAddress = txtIP.Text.Trim();
            string message = lvMessage.Text.Trim();

            if (string.IsNullOrEmpty(ipAddress) || !int.TryParse(txtPort.Text.Trim(), out int port))
            {
                MessageBox.Show("Vui lòng kiểm tra lại IP và Port đích!");
                return;
            }

            if (string.IsNullOrEmpty(message))
            {
                MessageBox.Show("Vui lòng nhập nội dung tin nhắn!");
                return;
            }

            try
            {
                // tạo một UdpClient mới để gửi dữ liệu
                using (UdpClient udpClient = new UdpClient())
                {
                    // Chuyển chuỗi tiếng Việt có dấu sang mảng byte chuẩn UTF-8
                    byte[] sendBytes = Encoding.UTF8.GetBytes(message);

                    // Bắn gói tin tới địa chỉ và cổng đích
                    udpClient.Send(sendBytes, sendBytes.Length, ipAddress, port);
                }

                lvMessage.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi gửi dữ liệu: " + ex.Message);
            }
        }

    }
}
