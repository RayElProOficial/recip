using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RecipSetupWPI
{
    public partial class Form1 : Form
    {
        public static object s;
        public Form1()
        {
            InitializeComponent();
            panel1.Show();
            panel2.Hide();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked) { button2.Enabled = true; }
            else { button2.Enabled = false; }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked) { button2.Enabled = false; }
            else { button2.Enabled = true; }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel2.Show();
            panel2.Focus();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var registryValue = Microsoft.Win32.Registry.GetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\iNS\\deneOS", "Status", "Windows");
            var a = registryValue;
            if (registryValue != null && registryValue.ToString() != null)
            {
                a = registryValue.ToString();
            }
            else
            {
                a = "Windows";
            }

            if (a.ToString() == "Windows")
            {
                //Código si es Windows
                textBox2.Text =
                    "Destination location:" +
                    "\r\n C:\\Program Files\\iNS\\Recip_v09" +
                    "\r\n" +
                    "\r\nAdditional tasks" + 
                    "\r\n Create Regedit Key for Recip";
            }
            else
            {
                //Código si es deneOS
                textBox2.Text =
                    "Destination location:" +
                    "\r\n ~/Software/iNS/Recip_v09" + // En deneOS, ~ es C:\\Users\\<user>\\
                    "\r\n" +
                    "\r\nAdditional tasks" +
                    "\r\n Create Regedit Key for Recip";
            }
            s = a;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            panel2.Hide();
            panel1.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //INSTALL
            switch (s.ToString())
            {
                case "Windows":
                    //Código si es Windows
                    Directory.CreateDirectory("C:\\Program Files\\iNS");
                    Directory.CreateDirectory("C:\\Program Files\\iNS\\Recip_v09");
                    Directory.CreateDirectory("C:\\Program Files\\iNS\\Recip_v09\\Application");
                    WebClient webClient = new WebClient();
                    webClient.DownloadFile("https://objects.githubusercontent.com/github-production-release-asset-2e65be/843549059/0196008e-9847-491c-9de3-623c2c0a541b?X-Amz-Algorithm=AWS4-HMAC-SHA256&X-Amz-Credential=releaseassetproduction%2F20250430%2Fus-east-1%2Fs3%2Faws4_request&X-Amz-Date=20250430T144325Z&X-Amz-Expires=300&X-Amz-Signature=5fcff91f47839dc5cdff65cfb5406ae9119c5a438c9e72ee3ffb148c9f67feaa&X-Amz-SignedHeaders=host&response-content-disposition=attachment%3B%20filename%3Drecip.exe.zip&response-content-type=application%2Foctet-stream",
                        "C:\\Program Files\\iNS\\Recip_v09\\recip.zip");
                    System.IO.Compression.ZipFile.ExtractToDirectory(
                        "C:\\Program Files\\iNS\\Recip_v09\\recip.zip",
                        "C:\\Program Files\\iNS\\Recip_v09\\Application");
                    break;
                case "deneOS":
                    //Código si es deneOS
                    Directory.CreateDirectory($"C:\\Users\\{Environment.UserName}\\Software\\iNS");
                    Directory.CreateDirectory($"C:\\Users\\{Environment.UserName}\\Software\\iNS\\Recip_v09");
                    Directory.CreateDirectory($"C:\\Users\\{Environment.UserName}\\Software\\iNS\\Recip_v09\\Application");
                    WebClient webClient2 = new WebClient();
                    webClient2.DownloadFile(
                        "https://objects.githubusercontent.com/github-production-release-asset-2e65be/843549059/27899618-1269-47f3-873a-e2de66d67837?X-Amz-Algorithm=AWS4-HMAC-SHA256&X-Amz-Credential=releaseassetproduction%2F20250430%2Fus-east-1%2Fs3%2Faws4_request&X-Amz-Date=20250430T144012Z&X-Amz-Expires=300&X-Amz-Signature=bedf1162f5eee7b49909109cc222975747a3bdbeda5b12153108732663caa29c&X-Amz-SignedHeaders=host&response-content-disposition=attachment%3B%20filename%3Drecip.wpi.zip&response-content-type=application%2Foctet-stream", 
                        $"C:\\Users\\{Environment.UserName}\\Software\\iNS\\Recip_v09\\recip.zip");
                    System.IO.Compression.ZipFile.ExtractToDirectory(
                        $"C:\\Users\\{Environment.UserName}\\Software\\iNS\\Recip_v09\\recip.zip",
                        $"C:\\Users\\{Environment.UserName}\\Software\\iNS\\Recip_v09\\Application");
                    break;
            }
            new Installed().ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
