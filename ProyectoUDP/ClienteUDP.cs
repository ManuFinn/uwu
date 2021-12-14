using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoUDP
{
    public class ClienteUDP
    {
        public string Mensaje { get; set; } = "Ejecucion en proceso";
        public int Tipo { get; set; } = 0;
        public event Action Recibido;
        UdpClient Listener;
        public void Iniciar()
        {
            Task.Run(IniciarServidor);
        }

        private void IniciarServidor()
        {
            try
            {
                int p =5000 ;
                IPEndPoint e = new IPEndPoint(IPAddress.Any, p);
                Listener = new UdpClient();
                Listener.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
                Listener.Client.Bind(e);
                while(true)
                {
                    byte[] dat = Listener.Receive(ref e);
                    if(dat.Length>0)
                    {
                        string mensaje= Encoding.UTF8.GetString(dat);   
                        var inf = mensaje.Split('|');
                        mensaje= inf[0];
                        Tipo=int.Parse(inf[1]);
                        ThreadSafeEventLaunch();
                    }
                }
         
            }
            catch (Exception ex)
            {
               MessageBox.Show(ex.Message);  

            }
        }
        void ThreadSafeEventLaunch()
        {
            if (Recibido != null)
            {
                foreach (var d in Recibido.GetInvocationList())
                {
                    ISynchronizeInvoke i = d.Target as ISynchronizeInvoke;
                    i.Invoke(Recibido, null);
                }
            }
        }
    }
}
