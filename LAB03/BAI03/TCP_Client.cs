using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace BAI03
{
    public partial class TCP_Client : Form
    {
        private TcpClient tcpClient;
        private NetworkStream networkStream;
        public TCP_Client()
        {
            InitializeComponent();
            btnSend.Enabled = false;
            btnDisconnect.Enabled = false;
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                // Tạo đối tượng TcpClient
                this.tcpClient = new TcpClient();

                // Kết nối tới IP Loopback và Port 8080 của Server
                IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
                IPEndPoint ipEndPoint = new IPEndPoint(ipAddress, 5241);
                this.tcpClient.Connect(ipEndPoint);

                // Lấy luồng NetworkStream để sẵn sàng đọc/ghi dữ liệu
                this.networkStream = this.tcpClient.GetStream();

                MessageBox.Show("Kết nối tới Server thành công!");
                btnConnect.Enabled = false;
                btnSend.Enabled = true;
                btnDisconnect.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể kết nối đến Server: " + ex.Message);
            }
        }

        // 2. Nút Send: Đẩy dữ liệu qua đường ống NetworkStream
        private void btnSend_Click(object sender, EventArgs e)
        {
            string message = rtbMessage.Text.Trim();
            if (string.IsNullOrEmpty(message))
            {
                MessageBox.Show("Vui lòng nhập nội dung cần gửi!");
                return;
            }

            try
            {
                // Kiểm tra xem đã kết nối với Server qua NetworkStream
                if (this.networkStream != null && this.networkStream.CanWrite)
                {
                    // Thêm ký tự xuống dòng để phân định thông điệp
                    byte[] data = Encoding.UTF8.GetBytes(message + "\n");

                    // Ghi mảng byte vào luồng mạng
                    this.networkStream.Write(data, 0, data.Length);
                    this.networkStream.Flush(); // Đẩy toàn bộ dữ liệu đi ngay lập tức

                    rtbMessage.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi gửi dữ liệu: " + ex.Message);
            }
        }

        // 3. Nút Disconnect: Đóng luồng và đóng socket kết nối
        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            CloseConnection();
            MessageBox.Show("Đã ngắt kết nối với Server.");
        }

        private void CloseConnection()
        {
            try
            {
                if (this.networkStream != null)
                {
                    // Có thể gửi tín hiệu quit trước khi ngắt nếu cần thiết
                    byte[] quitSignal = Encoding.UTF8.GetBytes("quit\n");
                    this.networkStream.Write(quitSignal, 0, quitSignal.Length);

                    this.networkStream.Close();
                    this.networkStream = null;
                }

                if (this.tcpClient != null)
                {
                    this.tcpClient.Close();
                    this.tcpClient = null;
                }
            }
            catch { }
            finally
            {
                btnConnect.Enabled = true;
                btnSend.Enabled = false;
                btnDisconnect.Enabled = false;
            }
        }

        // Đóng form
        private void TCPClient_FormClosing(object sender, FormClosingEventArgs e)
        {
            CloseConnection();
        }


    }
}
