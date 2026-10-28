using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace BAI03
{
    public partial class TCP_Sever : Form
    {
        private TcpListener tcpListener;
        private Thread listenThread;
        private bool isListening = false;
        public TCP_Sever()
        {
            InitializeComponent();
        }

        private void btnListen_Click(object sender, EventArgs e)
        {
            // Tránh bị bấm nhiều lần dẫn đến xung đột
            if (isListening) return;

            isListening = true;
            btnListen.Enabled = false;

            // Khởi chạy luồng phụ để chạy tiến trình lắng nghe
            listenThread = new Thread(new ThreadStart(StartListening))
            {
                IsBackground = true
            };
            listenThread.Start();
        }

        private void StartListening()
        {
            try
            {
                // Lắng nghe trên mọi card mạng tại cổng 5241
                tcpListener = new TcpListener(IPAddress.Any, 5241); //IPAdress.Any = bất cứ IP nào
                tcpListener.Start();
                AddLog("Server started!");

                while (isListening)
                {
                    // Lệnh chặn: Dừng luồng phụ chờ có Client kết nối tới
                    TcpClient client = tcpListener.AcceptTcpClient();

                    // Lấy thông tin IP và Port của máy Client vừa kết nối
                    IPEndPoint clientEP = (IPEndPoint)client.Client.RemoteEndPoint;
                    AddLog($"Connection accepted from {clientEP.Address}:{clientEP.Port}");

                    // Lấy đường ống NetworkStream để đọc dữ liệu
                    NetworkStream stream = client.GetStream();
                    byte[] buffer = new byte[1024]; // Bộ đệm 1 KB

                    while (client.Connected)
                    {
                        int bytesRead = stream.Read(buffer, 0, buffer.Length);

                        // bytesRead == 0 nghĩa là Client đã chủ động ngắt kết nối
                        if (bytesRead == 0)
                        {
                            AddLog($"Client {clientEP.Address}:{clientEP.Port} disconnected.");
                            break;
                        }

                        // Chuyển mảng byte nhận được thành chuỗi UTF-8
                        string message = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                        AddLog($"From client: {message.TrimEnd('\r', '\n')}");
                    }

                    stream.Close();
                    client.Close();
                }
            }
            catch (SocketException)
            {
                // Xảy ra khi đóng TcpListener lúc tắt form
            }
            catch (Exception ex)
            {
                AddLog("Lỗi: " + ex.Message);
            }
        }

        // Cập nhật giao diện an toàn (Thread-safe) qua Invoke ( đẩy qua luồng chính xử lí lv)
        private void AddLog(string msg)
        {
            if (lvMessage.InvokeRequired)
            {
                lvMessage.Invoke(new Action(() => AddLog(msg)));
                return;
            }
            lvMessage.Items.Add(new ListViewItem(msg));
        }

        // Đóng form
        private void TCPServer_FormClosing(object sender, FormClosingEventArgs e)
        {
            isListening = false;
            try
            {
                tcpListener?.Stop();
            }
            catch { }
        }


    }
}
