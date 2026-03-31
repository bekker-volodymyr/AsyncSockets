using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class Program
    {
        private const int PORT = 5001;

        static async Task Main(string[] args)
        {
            Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            server.Bind(new IPEndPoint(IPAddress.Any, PORT));

            server.Listen(10);

            Console.WriteLine($"Server listening on port {PORT}");

            while(true)
            {
                Socket client = await server.AcceptAsync();

                _ = Task.Run(() => HandleClientAsync(client));
            }
        }

        private static async Task HandleClientAsync(Socket client)
        {
            try
            {
                byte[] buffer = new byte[1024];
                while(true)
                {
                    int received = await client.ReceiveAsync(buffer);
                    if (received == 0) break;

                    string msg = Encoding.UTF8.GetString(buffer, 0, received);
                    Console.WriteLine(msg);
                    string answer = "Echo: " + msg;

                    await client.SendAsync(Encoding.UTF8.GetBytes(answer));
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
