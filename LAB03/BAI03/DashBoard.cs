namespace BAI03
{
    public partial class DashBoard : Form
    {
        public DashBoard()
        {
            InitializeComponent();
        }
        
        private void btnClient_Click(object sender, EventArgs e)
        {
            TCP_Client clientForm = new TCP_Client();
            clientForm.Show();
        }


        private void btnSever_Click(object sender, EventArgs e)
        {
            TCP_Sever serverForm = new TCP_Sever();
            serverForm.Show();
        }
    }
}
