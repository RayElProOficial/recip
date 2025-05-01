using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RecipSetupWPI
{
    public partial class Installed : Form
    {
        public Installed()
        {
            InitializeComponent();
            if (Form1.s.ToString() == "Windows") { this.Text = ".\\setup.exe"; }
            else { this.Text = "./setup.wpi"; }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Environment.Exit(exitCode: Environment.ExitCode);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            switch (Form1.s.ToString())
            {
                case "Windows":
                    Process.Start("C:\\Program Files\\iNS\\Recip_v09\\Application\\recip.exe");
                    break;
                default:
                    Process.Start($"C:\\Users\\{Environment.UserName}\\Software\\iNS\\Recip_v09\\Application\\recip.wpi");
                    break;
            }
        }
    }
}
