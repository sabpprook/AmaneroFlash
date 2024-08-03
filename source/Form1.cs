using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Ports;
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
            ListFirmware();
        }

        private void ListFirmware()
        {
            if (Directory.Exists("CPLD"))
            {
                var files = Directory.GetFiles(".\\CPLD", "*.txt");
                foreach (var file in files)
                    comboBox_CPLD.Items.Add(new FWInfo(file));
            }

            if (Directory.Exists("CPU"))
            {
                var files = Directory.GetFiles(".\\CPU", "*.txt");
                foreach (var file in files)
                    comboBox_CPU.Items.Add(new FWInfo(file));
            }
        }

        private string GetComPort()
        {
            var port = string.Empty;
            var ports = new List<string>();

            var reg = Registry.LocalMachine.OpenSubKey("HARDWARE\\DEVICEMAP\\SERIALCOMM");
            foreach (var val in reg.GetValueNames())
            {
                ports.Add(reg.GetValue(val) as string);
            }

            reg = Registry.LocalMachine.OpenSubKey("SYSTEM\\CurrentControlSet\\Enum\\USB");
            foreach (var sub in reg.GetSubKeyNames())
            {
                if (sub.Contains("PID_6124"))
                {
                    reg = reg.OpenSubKey(sub);
                    break;
                }
            }
            foreach (var sub in reg.GetSubKeyNames())
            {
                var device = reg.OpenSubKey(sub).OpenSubKey("Device Parameters");
                var portname = device.GetValue("PortName") as string;
                if (ports.Contains(portname))
                {
                    port = portname;
                    break;
                }
            }
            return port;
        }

        private void FlashFW(string comport, FWInfo fw)
        {
            Invoke(new Action(() =>
            {
                progressBar.Value = 0;
                progressBar.Maximum = fw.Size;
            }));

            try
            {
                var sp = new SerialPort(comport, 115200, Parity.None, 8, StopBits.One);

                sp.Open();
                foreach (var line in fw.Data)
                {
                    sp.Write(line);
                    Thread.Sleep(20);

                    if (sp.IsOpen)
                        sp.ReadExisting();

                    var length = line.Length;
                    Invoke(new Action(() => progressBar.Value += length));
                }
                sp.Close();

                Thread.Sleep(500);
            }
            catch
            {
            }

            Invoke(new Action(() => progressBar.Value = progressBar.Maximum));
        }

        private async void btn_Flash_Click(object sender, EventArgs e)
        {
            panel.Enabled = false;

            var comport = GetComPort();

            FWInfo fw = null;
            var option = (sender as Button).Tag.ToString();
            if (option == "CPLD") fw = comboBox_CPLD.SelectedItem as FWInfo;
            if (option == "CPU") fw = comboBox_CPU.SelectedItem as FWInfo;

            if (!string.IsNullOrEmpty(comport) && fw != null)
            {
                await Task.Run(() => FlashFW(comport, fw));
            }

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

        public string[] Data { get { return File.ReadAllLines(info.FullName); } }

        public int Size { get { return (int)info.Length; } }

        public FWInfo(string path)
        {
            info = new FileInfo(path);
        }

        public override string ToString()
        {
            return Path.GetFileNameWithoutExtension(info.FullName);
        }
    }
}
