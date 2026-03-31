using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Client
{
    public partial class Form1 : Form
    {
        private Socket _socket;
        private IPEndPoint _serverEndpoint = new IPEndPoint(IPAddress.Loopback, 5001);

        public Form1()
        {
            InitializeComponent();
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            if(_socket == null || !_socket.Connected)
            {
                MessageBox.Show("Ви не підключені до серверу!");
                btnDisconnect.Enabled = false;
                return;
            }

            _socket.Disconnect(false);
            _socket.Close();

            btnDisconnect.Enabled = false;
            btnSend.Enabled = false;
            btnConnect.Enabled = true;
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (_socket == null || !_socket.Connected)
            {
                MessageBox.Show("Ви не підключені до серверу!");
                btnSend.Enabled = false;
                return;
            }

            byte[] msg = Encoding.UTF8.GetBytes(txtMessage.Text);
            _socket.Send(msg);

            byte[] buffer = new byte[1024];
            int received = _socket.Receive(buffer);
            txtAnswer.Text = Encoding.UTF8.GetString(buffer, 0, received);
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if(_socket != null && _socket.Connected)
            {
                MessageBox.Show("Ви вже підключились до серверу!");
                btnConnect.Enabled = false;
                return;
            }

            try
            {
                _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                _socket.Connect(_serverEndpoint);
                if(_socket.Connected)
                {
                    MessageBox.Show("Підключення успішне!");
                }
                btnConnect.Enabled = false;
                btnDisconnect.Enabled = true;
                btnSend.Enabled = true;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
