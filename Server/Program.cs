using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Server
{
    public class Program
    {
        private const int PORT = 5001;

        static void Main(string[] args)
        {
            Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            server.Bind(new IPEndPoint(IPAddress.Any, PORT));

            server.Listen(10);

            Console.WriteLine($"Server listening on port {PORT}");

            while(true)
            {
                Socket client = server.Accept();

                HandleClient(client);
            }
        }

        private static void HandleClient(Socket client)
        {
            try
            {
                byte[] buffer = new byte[1024];
                while(true)
                {
                    int received = client.Receive(buffer);
                    if (received == 0) break;

                    string msg = Encoding.UTF8.GetString(buffer, 0, received);
                    Console.WriteLine(msg);
                    string answer = "Echo: " + msg;

                    client.Send(Encoding.UTF8.GetBytes(answer));
                }
            }
            catch (SocketException ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                client.Close();
                Console.WriteLine("Клієнт від'єднався!");
            }
        }
    }
}
