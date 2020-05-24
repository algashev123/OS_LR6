using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;

namespace WindowsFormsApp1
{
    public partial class ScoutForm : Form
    {
        Socket scout;
        int n;
        public ScoutForm(string arg)
        {
            InitializeComponent();
            this.n = Int32.Parse(arg);
        }

        private void ScoutForm_Load(object sender, EventArgs e)
        {
            int port = 8005;
            IPEndPoint ipPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), port);

            // создаем сокет
            scout = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            scout.Connect(ipPoint);
        }

        private void buttonMessage_Click(object sender, EventArgs e)
        {
            string s = textMessage.Text;
            if (s == "!" || s == "-" || s == ".")
            {
                byte[] message = Encoding.Unicode.GetBytes(s);
                scout.Send(message);
                if (s == "!")
                {
                    MessageBox.Show("Шпион № " + n + " завершил работу");
                    Environment.Exit(0);
                }
            }
            else
                MessageBox.Show("Ошибка! Необходимо ввести '.','-' или '!'.");
            textMessage.Clear();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void ScoutForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            MessageBox.Show("Шпион № " + n + " принудительно завершил работу");
        }
    }
}
