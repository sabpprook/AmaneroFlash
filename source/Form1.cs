using System;
using System.Diagnostics;
using System.IO;
using System.IO.Ports;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AmaneroFlash
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            btn_RefreshCom.PerformClick();
            ListFirmware();
        }

        private void ListFirmware()
        {
            if (Directory.Exists("CPLD"))
            {
                var files = Directory.GetFiles(".\\CPLD", "*.txt");
                comboBox_CPLD.Items.Clear();
                foreach (var file in files)
                {
                    comboBox_CPLD.Items.Add(new FWInfo(file));
                }
            }

            if (Directory.Exists("CPU"))
            {
                var files = Directory.GetFiles(".\\CPU", "*.txt");
                comboBox_CPU.Items.Clear();
                foreach (var file in files)
                {
                    comboBox_CPU.Items.Add(new FWInfo(file));
                }
            }
        }

        private void FlashFW(string comport, FWInfo fw)
        {
            Invoke(new Action(() =>
            {
                progressBar.Value = 0;
                progressBar.Maximum = fw.GetSize();
            }));

            var buff = new byte[1024];
            var sp = new SerialPort(comport, 115200, Parity.None, 8, StopBits.One);

            sp.DataReceived += (s, e) =>
            {
                var size = sp.Read(buff, 0, 1024);
                Console.WriteLine($"recv: {size} bytes");
            };

            sp.Open();

            foreach (var line in fw.GetData())
            {
                var payload = Encoding.ASCII.GetBytes(line);
                var length = line.Length;

                sp.Write(payload, 0, length);

                Invoke(new Action(() => progressBar.Value += length));
                Console.WriteLine($"send: {length} bytes");

                var wait_time = (length * 1000 / 115200) < 10 ? 10 : 25;
                Thread.Sleep(wait_time);
            }

            Invoke(new Action(() => progressBar.Value = progressBar.Maximum));

            sp.Close();
        }

        private void btn_RefreshCom_Click(object sender, EventArgs e)
        {
            comboBox_ComPorts.Items.Clear();
            var ports = SerialPort.GetPortNames();
            foreach (var port in ports)
            {
                if (!comboBox_ComPorts.Items.Contains(port))
                    comboBox_ComPorts.Items.Add(port);
            }
            if (comboBox_ComPorts.Items.Count > 0)
            {
                comboBox_ComPorts.SelectedIndex = 0;
            }
        }

        private async void btn_FlashCPLD_Click(object sender, EventArgs e)
        {
            panel.Enabled = false;
            var port = comboBox_ComPorts.Text;
            var fw = comboBox_CPLD.SelectedItem as FWInfo;
            await Task.Run(() => FlashFW(port, fw));
            panel.Enabled = true;
        }

        private async void btn_FlashCPU_Click(object sender, EventArgs e)
        {
            panel.Enabled = false;
            var port = comboBox_ComPorts.Text;
            var fw = comboBox_CPU.SelectedItem as FWInfo;
            await Task.Run(() => FlashFW(port, fw));
            panel.Enabled = true;
        }

        private void linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/sabpprook/AmaneroFlash");
        }
    }

    public class FWInfo
    {
        private FileInfo info;

        public FWInfo(string path)
        {
            info = new FileInfo(path);
        }

        public override string ToString()
        {
            return Path.GetFileNameWithoutExtension(info.FullName);
        }

        public string[] GetData()
        {
            return File.ReadAllLines(info.FullName);
        }

        public int GetSize()
        {
            return (int)info.Length;
        }
    }
}
