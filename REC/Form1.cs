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
            Settings.Default.penLastRecipe = Settings.Default.LastRecipe;
            Settings.Default.pLRRoute = Settings.Default.LRRoute;
            Settings.Default.LastRecipe = openFileDialog1.FileName.Substring(openFileDialog1.FileName.LastIndexOf('\\')+1);
            Settings.Default.LRRoute = openFileDialog1.FileName;
            Settings.Default.Save();
            RecipeOpened.RecipeRute = openFileDialog1.FileName; 
            new RecipeOpened().ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            switch (comboBox1.Text.ToUpper())
            {
                case "B&W":
                    Icon = Resources.B_W_logo_83x681;
                    pictureBox1.Image = Resources.B_W_logo_83x68;
                    break;
                case "COLOR":
                    Icon = Resources.COLOR_logo_83x681;
                    pictureBox1.Image = Resources.COLOR_logo_83x68;
                    break;
                case "COLOR (REESCALATED TO 800X600)":
                    Icon = Resources.COLOR_logo_800x600_Basic_reescaled1;
                    pictureBox1.Image = Resources.COLOR_logo_800x600_Basic_reescaled;
                    break;
                case "MONOCHROMATIC":
                    Icon = Resources.MONO_logo_83x681;
                    pictureBox1.Image = Resources.MONO_logo_83x68;
                    break;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (button4.Text == "-")
            {
                Size = new Size(454,166);
                button4.Text = "+";
            }
            else if (button4.Text == "+")
            {
                Size = new Size(454, 203);
                button4.Text = "-";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button5.Text = Settings.Default.LastRecipe;
            button6.Text = Settings.Default.penLastRecipe;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            RecipeOpened.RecipeRute = Settings.Default.LRRoute;
            new RecipeOpened().ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            RecipeOpened.RecipeRute = Settings.Default.pLRRoute;
            new RecipeOpened().ShowDialog();
        }
    }
}
