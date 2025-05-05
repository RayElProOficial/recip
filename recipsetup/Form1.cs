using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;

namespace recipsetup
{
    public partial class Form1 : Form
    {
        bool dene;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            object a = Registry.GetValue(@"HKEY_LOCAL_MACHINE\Software\iNS\deneOS", "Status", "Windows");
            if ((string)a == "Windows")
            {
                label6.Text = "C:\\Program Files\\iNS\\Recip\\v1.0\\";
                dene = false;
            }
            else if ((string)a == "deneOS")
            {
                label6.Text = "~/Software/iNS/Recip/v1.0/";
                dene = true;
            }
            else
            {
                label6.Text = "C:\\Program Files\\iNS\\Recip\\v1.0\\";
                dene = false;
            }
                RegistryKey registryKey = Registry.ClassesRoot.CreateSubKey(@".rec");
            registryKey.SetValue("@", "recfile");
                RegistryKey registryKey2 = Registry.ClassesRoot.CreateSubKey(@"recfile\shell\open\command");
            registryKey2.SetValue("@", "/*INSTALL LOCATION \\ RECIP.[WPI/EXE] */");
            
        }
    }
}
