using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace recip
{
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();
        }

        private void About_Load(object sender, EventArgs e)
        {
            string htmlFilePath = System.IO.Path.Combine(Application.StartupPath, "About.html");
            if (System.IO.File.Exists(htmlFilePath))
            {
                webView2.Source = new Uri(htmlFilePath);
            }
            else
            {
                MessageBox.Show("The About.html file could not be found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }
    }
}
