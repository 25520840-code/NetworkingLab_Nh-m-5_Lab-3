using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace BAI02
{
    public partial class TCP_Sever : Form
    {
        private Socket listenerSocket;
        private Thread serverThread;
        private bool isListening = false;
        public TCP_Sever()
        {
            InitializeComponent();
        }

        private void btnListen_Click(object sender, EventArgs e)
        {
            if (isListening) return;

            isListening = true;
            btnListen.Enabled = false;

            // Khởi tạo luồng phụ để chạy hàm ListenProcess
            serverThread = new Thread(new ThreadStart(ListenProcess))
            {
                IsBackground = true // Khi tắt Form, luồng phụ này tự hủy
            };
            serverThread.Start();

            AddLog("Telnet running on 127.0.0.1:8080");
        }

        // 2. Hàm chạy trong luồng phụ (Worker Thread)
        private void ListenProcess()
        {
            try
            {
                // Khởi tạo socket lắng nghe TCP cấp thấp
                listenerSocket = new Socket(
                    AddressFamily.InterNetwork,
                    SocketType.Stream,
                    ProtocolType.Tcp
                );

                IPEndPoint ipepServer = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8080);
                listenerSocket.Bind(ipepServer);
                listenerSocket.Listen(-1);

                // Dừng luồng phụ tại đây để chờ Client kết nối tới
                Socket clientSocket = listenerSocket.Accept();
                AddLog("New client connected");

                byte[] recv = new byte[1]; // Mảng 1 byte để đọc từng ký tự gõ từ Telnet
                string text = "";

                // Vòng lặp đọc dữ liệu khi Client còn kết nối
                while (clientSocket.Connected && isListening)
                {
                    // Lệnh chặn Receive: Dừng luồng phụ cho đến khi Client gõ phím
                    int bytesReceived = clientSocket.Receive(recv);

                    // Khi người dùng tắt CMD Telnet, Receive trả về 0 byte -> Thoát lặp
                    if (bytesReceived == 0)
                    {
                        AddLog("Client disconnected.");
                        break;
                    }

                    text += Encoding.UTF8.GetString(recv);

                    // Telnet gửi ký tự '\n' khi người dùng nhấn Enter
                    if (text.EndsWith("\n"))
                    {
                        AddLog(text.TrimEnd('\r', '\n'));
                        text = ""; // Làm sạch chuỗi để đón dòng mới
                    }
                }

                clientSocket.Close();
            }
            catch (SocketException)
            {
                // Xảy ra khi đóng socket từ FormClosing
            }
            catch (Exception ex)
            {
                AddLog("Lỗi: " + ex.Message);
            }
        }

        // 3. Hàm cập nhật ListView an toàn từ luồng phụ (Thread-safe)
        private void AddLog(string msg)
        {
            // Kiểm tra xem có đang bị gọi từ luồng phụ hay không
            if (lvMess.InvokeRequired)
            {
                lvMess.Invoke(new Action(() => AddLog(msg)));
                return;
            }

            // Đang ở luồng chính (UI Thread): ghi trực tiếp lên ListView
            lvMess.Items.Add(new ListViewItem(msg));
        }

        // 4. Giải phóng tài nguyên khi đóng Form
        private void FormBai02_FormClosing(object sender, FormClosingEventArgs e)
        {
            isListening = false;
            try
            {
                listenerSocket?.Close(); // Đóng socket để giải phóng port 8080
            }
            catch { }
        }
    }
}
