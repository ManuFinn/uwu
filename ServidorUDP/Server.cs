using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace ServidorUDP
{
    public class Server
    {
        UdpClient server = new UdpClient(){EnableBroadcast=true};
        public void Send(string mensaje, int tipo)
        {
            if (!string.IsNullOrWhiteSpace(mensaje) && tipo > 0)
            {
                string dat = $"{mensaje}|{tipo}";
                byte[] buffer = Encoding.UTF8.GetBytes(dat);
                server.Send(buffer, buffer.Length, new IPEndPoint(IPAddress.Broadcast, 5000));
            }
            else
            {
                if (string.IsNullOrWhiteSpace(mensaje))
                {
                    MessageBox.Show("Ingresa un mensaje");
                }
                else
                {
                    MessageBox.Show("Seleciona qué tipo de mensaje deseas enviar");
                }
            }
        }

    }
}
