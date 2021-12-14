using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoUDP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        ClienteUDP client = new();
        Icon icon = new("Assets/notes.ico");

        Icon icon0 = new("Assets/notes.ico");
        Icon icon1 = new Icon("Assets/message.ico");
        Icon icon2 = new Icon("Assets/warning.ico");
        Icon icon3 = new Icon("Assets/error.ico");

        private void Form1_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            notifyIcon.Visible = true;
            notificacion();
            client.Recibido += Client_Recibido;
            client.Iniciar();

        }

        private void Client_Recibido()
        {
            notifyIcon.BalloonTipTitle = "UDP Mensaje";
            notifyIcon.BalloonTipText = client.Mensaje;
            notifyIcon.Text = client.Mensaje;
            switch (client.Tipo)
            {
                case 1:
                    notifyIcon.Icon = icon1;
                    break;
                case 2:
                    notifyIcon.Icon = icon2;
                    break;
                case 3:
                    notifyIcon.Icon = icon3;
                    break;
                default:
                    notifyIcon.Icon = icon0;
                    break;
            }
            notifyIcon.ShowBalloonTip(3000);
        }

        
        private void Form1_Shown(object sender, EventArgs e)
        {
            
        }

        private void notificacion()
        {
            notifyIcon.BalloonTipTitle = "Notificacion UDP";
            notifyIcon.BalloonTipText = client.Mensaje;
            notifyIcon.Text=client.Mensaje;
            notifyIcon.Icon = icon0;
            notifyIcon.ShowBalloonTip(3000);
            
        }
      

        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void cerrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}