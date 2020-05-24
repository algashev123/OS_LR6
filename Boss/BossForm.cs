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
using System.Threading;
using System.Diagnostics;
using System.IO;

namespace Client
{
    public partial class BossForm : Form
    {
        Socket[] scouts;
        Thread[] threads;
        Mutex mutex;
        Socket listen;
        Process[] processes;
        Action action;
        int index;
        int count = 0;
        public void talk(Object current)
        {
            try
            {
                mutex.WaitOne();
                index = (int)current;
                if (processes[index].HasExited)
                {
                    action = () => LogBox.Text += "Шпион № " + (index + 1).ToString() + " принудительно завершил работу.";
                    Invoke(action);
                    action = () => LogBox.Text += Environment.NewLine;
                    Invoke(action);
                    if (count == processes.Length - 1)
                    {
                        MessageBox.Show("Программа успешно завершила работу.");
                        Environment.Exit(0);
                    }
                }
                else
                {
                    action = () => LogBox.Text += "Шпион № " + (index + 1).ToString() + " передаёт сообщение: ";
                    Invoke(action);
                    while (true)
                    {
                        StringBuilder builder = new StringBuilder();
                        int bytes = 0; // количество полученных байтов
                        byte[] message = new byte[256]; // буфер для получаемых данных
                        do
                        {
                            bytes = scouts[index].Receive(message);
                            builder.Append(Encoding.Unicode.GetString(message, 0, bytes));
                        }
                        while (scouts[index].Available > 0);
                        if (builder.ToString() == "")
                            throw new SocketException();
                        if (builder.ToString() == "!")
                        {
                            action = () => LogBox.Text += Environment.NewLine;
                            Invoke(action);
                            action = () => LogBox.Text += "Шпион № " + (index + 1).ToString() + " отключился" + Environment.NewLine;
                            Invoke(action);
                            break;
                        }
                        else
                        {
                            action = () => LogBox.Text += builder.ToString();
                            Invoke(action);
                        }
                    }
                }
            }
            catch (SocketException ex)
            {
                action = () => LogBox.Text += Environment.NewLine;
                Invoke(action);
                action = () => LogBox.Text += "Шпион № " + (index + 1).ToString() + " отключился" + Environment.NewLine;
                Invoke(action);
            }
            catch (AbandonedMutexException ex) { }
            if (count == processes.Length - 1)
            {
                mutex.ReleaseMutex();
                scouts[count].Close();
                threads[count].Abort();
                MessageBox.Show("Программа успешно завершила работу.");
                Environment.Exit(0);
            }
            mutex.ReleaseMutex();
            scouts[count].Close();
            threads[count].Abort();
            count++;
            if (count == processes.Length - 1)
            {
                MessageBox.Show("Программа успешно завершила работу.");
                Environment.Exit(0);
            }
        }

        public BossForm()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            StreamReader read = new StreamReader("C:\\Users\\Alex\\source\\repos\\OS 6\\log.txt");
            string line;
            while ((line = read.ReadLine()) != null)
            {
                LogBox.Text += line + Environment.NewLine;
            }
            read.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string save = LogBox.Text;
            StreamWriter inp = new StreamWriter("C:\\Users\\Alex\\source\\repos\\OS 6\\log.txt");
            inp.WriteLine(save);
            inp.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int n = Int32.Parse(InputCountScouts.Text);
                if (n > 0 && n <= 10)
                {
                    processes = new Process[n];
                    scouts = new Socket[n];
                    threads = new Thread[n];
                    ProcessStartInfo prc = new ProcessStartInfo();
                    for (int i = 0; i < n; i++)
                    {
                        prc.FileName = "C:\\Users\\Alex\\source\\repos\\OS 6\\" +
                            "WindowsFormsApp1\\bin\\Debug\\WindowsFormsApp1.exe";
                        prc.Arguments = (i + 1).ToString();
                        processes[i] = Process.Start(prc);
                        scouts[i] = listen.Accept();
                        threads[i] = new Thread(new ParameterizedThreadStart(talk));
                        threads[i].Start(i);
                    }
                    InputCountScouts.Enabled = false;
                    buttonConectScout.Enabled = false;
                }
                else
                    MessageBox.Show("Необходимо ввести целое положительное число в диапазоне от 1 до 10.");
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Необходимо ввести целое положительное число в диапазоне от 1 до 10.");
            }
            catch (Win32Exception ex)
            {
                MessageBox.Show("Ошибка! Неверно указ путь к файлу типа exe (на каждом компьютере этот путь разный).");
            }
            InputCountScouts.Clear();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            int port = 8005;
            IPEndPoint ipPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), port);

            // создаем сокет
            listen = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                // связываем сокет с локальной точкой, по которой будем принимать данные
                listen.Bind(ipPoint);

                // начинаем прослушивание
                listen.Listen(10);

                LogBox.Text += "Сервер запущен. Ожидание подключений..." + Environment.NewLine;
                mutex = new Mutex();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void BossForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            MessageBox.Show("Резидент принудительно завершил свою работу.");
            try
            {
                for (int i = index; i < processes.Length; i++)
                {
                    scouts[i].Close();
                    threads[i].Abort();
                    try
                    {
                        processes[i].Kill();
                    }
                    catch (InvalidOperationException ex)
                    {

                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}
