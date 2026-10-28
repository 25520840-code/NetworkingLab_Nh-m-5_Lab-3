using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;
namespace BAI01
{
    public partial class UDP_Sever : Form
    {
        private UdpClient udpServer;
        private Thread serverThread;
        private bool isListening = false;
        public UDP_Sever()
        {
            InitializeComponent();
        }

        private void btnListen_Click(object sender, EventArgs e)
        {
            if (isListening) return; // bỏ qua các click đằng sau

            if (!int.TryParse(txtPort.Text.Trim(), out int port)) 
            {
                MessageBox.Show("Vui lòng nhập số Port hợp lệ!");
                return;
            }

            try
            {
                // Khởi tạo UdpClient lắng nghe trên port được chọn
                udpServer = new UdpClient(port);
                isListening = true;

                // Tạo luồng phụ để chờ nhận dữ liệu không làm đơ giao diện
                serverThread = new Thread(ReceiveMessages)
                {
                    IsBackground = true // Đảm bảo thread tắt khi đóng Form
                };
                serverThread.Start();

                //chặn không cho người dùng thay đổi port và bấm Listen nhiều lần
                btnListen.Enabled = false;
                txtPort.Enabled = false;
                AddMessageToListView($"Server đang lắng nghe tại cổng {port}...");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi mở server: " + ex.Message);
            }
        }

        private void ReceiveMessages()
        {
            while (isListening)
            {
                try
                {
                    // Hộp chứa rỗng để hứng IP và Port của bên gửi
                    IPEndPoint remoteEP = new IPEndPoint(IPAddress.Any, 0);

                    // Lệnh chặn chờ gói tin đến
                    byte[] receiveBytes = udpServer.Receive(ref remoteEP);

                    // Giải mã sang tiếng Việt UTF-8
                    string message = Encoding.UTF8.GetString(receiveBytes);
                    string displayData = $"{remoteEP.Address}:{remoteEP.Port} - {message}";

                    // Gọi cập nhật giao diện Thread-safe
                    AddMessageToListView(displayData);
                }
                catch (SocketException)
                {
                    // Xảy ra khi udpServer bị Close() lúc tắt Form
                    break;
                }
                catch (Exception ex)
                {
                    AddMessageToListView("Lỗi nhận dữ liệu: " + ex.Message);
                }
            }
        }

        // Phương thức cập nhật ListView an toàn qua Invoke (do luồng phụ không thể dùng listView nên phải đẩy qua Invoke để back to main thread)
        private void AddMessageToListView(string text)
        {
            if (lvMess.InvokeRequired)
            {
                lvMess.Invoke(new Action(() => AddMessageToListView(text))); // đẩy qua luồng chính xử lí nếu nhận được invoke)
                return;
            }
            lvMess.Items.Add(new ListViewItem(text));
        }

        // Đóng Socket sạch sẽ khi tắt Form
        private void UDPServer_FormClosing(object sender, FormClosingEventArgs e)
        {
            isListening = false;
            udpServer?.Close();
        }
    }
}

