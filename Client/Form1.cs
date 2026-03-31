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

        private async void btnDisconnect_Click(object sender, EventArgs e)
        {
            if(_socket == null || !_socket.Connected)
            {
                MessageBox.Show("Ви не підключені до серверу!");
                btnDisconnect.Enabled = false;
                return;
            }

            await _socket.DisconnectAsync(false);
            _socket.Close();

            btnDisconnect.Enabled = false;
            btnSend.Enabled = false;
            btnConnect.Enabled = true;
        }

        private async void btnSend_Click(object sender, EventArgs e)
        {
            if (_socket == null || !_socket.Connected)
            {
                MessageBox.Show("Ви не підключені до серверу!");
                btnSend.Enabled = false;
                return;
            }

            byte[] msg = Encoding.UTF8.GetBytes(txtMessage.Text);
            await _socket.SendAsync(msg);

            byte[] buffer = new byte[1024];
            int received = await _socket.ReceiveAsync(buffer);
            txtAnswer.Text = Encoding.UTF8.GetString(buffer, 0, received);
        }

        private async void btnConnect_Click(object sender, EventArgs e)
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
                await _socket.ConnectAsync(_serverEndpoint);
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
