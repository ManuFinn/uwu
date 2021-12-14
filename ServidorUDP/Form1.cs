namespace ServidorUDP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        Server serv=new Server();   
        private void button1_Click(object sender, EventArgs e)
        {
            serv.Send(textBox1.Text, comboBox1.SelectedIndex+1);
        }
    }
}