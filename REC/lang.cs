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
using recip.Properties;

namespace recip
{
    public partial class lang : Form
    {
        public lang()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Strings.SetLang(Language.English);
            Settings.Default.Language = "EN";
            Settings.Default.Save();
            var result = MessageBox.Show(Strings.MsgRestartToApply, "Recip", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Process.Start(Application.ExecutablePath);
                Application.Exit();
            }
            else
            {
                return;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Strings.SetLang(Language.Spanish);
            Settings.Default.Language = "ES";
            Settings.Default.Save();
            var result = MessageBox.Show(Strings.MsgRestartToApply, "Recip", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Process.Start(Application.ExecutablePath);
                Application.Exit();
            }
            else
            {
                return;
            }
        }
    }
}
