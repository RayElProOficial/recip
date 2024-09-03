using recip;
using recip.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace REC
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new MakeRecipe().ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            RecipeOpened.RecipeRute = openFileDialog1.FileName; 
            new RecipeOpened().ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            switch (comboBox1.Text.ToUpper())
            {
                case "B&W":
                    Icon = Resources.B_W_logo_83x681;
                    break;
                case "COLOR":
                    Icon = Resources.COLOR_logo_83x681;
                    break;
                case "COLOR (REESCALATED TO 800X600)":
                    Icon = Resources.COLOR_logo_800x600_Basic_reescaled1;
                    break;
                case "MONOCHROMATIC":
                    Icon = Resources.MONO_logo_83x681;
                    break;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Size = new Size(254, 134);//174 max.
        }
    }
}
