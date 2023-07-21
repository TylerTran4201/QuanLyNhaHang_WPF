using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace QuanLyNhaHang.MultiClient
{
    class Client
    {
        public IPAddress ip { get; set; }
        public IPEndPoint ipEndpoint { get; set; }
        public Socket client { get; set; }
        public byte[] data = new byte[1024];

        public string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            return null;
        }
        public Client()
        {
            ip = IPAddress.Parse(this.GetLocalIPAddress());
            ipEndpoint = new IPEndPoint(ip, 8000);
            client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }

        public void Connected()
        {
            //Client kết nối với server theo địa chỉ ipEndpoint
            client.Connect(ipEndpoint);
            client.BeginReceive(data, 0, data.Length, SocketFlags.None, new AsyncCallback(ReceiveData), client);
        }
        public void Disconnected()
        {
            client.Disconnect(true);
            client.Close();
        }
        public void Send(Models.Ban ban, int ischeck)
        {
            ban.Status = ischeck;
            data = new Models.BanConverter().ToBytes(ban);
            client.BeginSend(data, 0, data.Length, SocketFlags.None, SendCallback, null);
        }
        private void SendCallback(IAsyncResult AR)
        {
            client.EndSend(AR);            
        }
        public void ReceiveData(IAsyncResult ar)
        {
            Socket socket = (Socket)ar.AsyncState;
            int received = socket.EndReceive(ar);
            Models.Ban ban = Models.BanConverter.FromBytes(data);
            foreach (var item in ViewModels.MainThuNganViewModel.bansTemp) {
                if (ban.Id.CompareTo(item.Id) == 0) {
                    item.Status = ban.Status;
                    break;
                }
            }

            client.BeginReceive(data, 0, data.Length, SocketFlags.None, new AsyncCallback(ReceiveData),
            client);
        }
    }
}
