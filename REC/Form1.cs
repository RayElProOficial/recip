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
            using (var dialog = new OpenFileDialog())
            {
                dialog.Filter = "Recipes|*.rec|All files|*.*";
                dialog.Title = "Where is the recipe?";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        Settings.Default.penLastRecipe = Settings.Default.LastRecipe;
                        Settings.Default.pLRRoute = Settings.Default.LRRoute;
                        Settings.Default.LastRecipe = dialog.FileName.Substring(dialog.FileName.LastIndexOf('\\') + 1);
                        Settings.Default.LRRoute = dialog.FileName;
                        Settings.Default.Save();
                        RecipeOpened.RecipeRute = dialog.FileName;
                        new RecipeOpened().ShowDialog();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }



        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

            try
            {
                Settings.Default.penLastRecipe = Settings.Default.LastRecipe;
                Settings.Default.pLRRoute = Settings.Default.LRRoute;
                Settings.Default.LastRecipe = openFileDialog1.FileName.Substring(openFileDialog1.FileName.LastIndexOf('\\') + 1);
                Settings.Default.LRRoute = openFileDialog1.FileName;
                Settings.Default.Save();
                RecipeOpened.RecipeRute = openFileDialog1.FileName;
                new RecipeOpened().ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            switch (comboBox1.Text.ToUpper())
            {
                case "B&W":
                    Icon = Resources.B_W_logo_83x681;
                    pictureBox1.Image = Resources.B_W_logo_83x68;
                    break;
                case "B/N":
                    Icon = Resources.B_W_logo_83x681;
                    pictureBox1.Image = Resources.B_W_logo_83x68;
                    break;
                case "COLOR":
                    Icon = Resources.COLOR_logo_83x681;
                    pictureBox1.Image = Resources.COLOR_logo_83x68;
                    break;
                case "COLOR (REESCALADO)":
                    Icon = Resources.COLOR_logo_800x600_Basic_reescaled1;
                    pictureBox1.Image = Resources.COLOR_logo_800x600_Basic_reescaled;
                    break;
                case "COLOR (RESCALED)":
                    Icon = Resources.COLOR_logo_800x600_Basic_reescaled1;
                    pictureBox1.Image = Resources.COLOR_logo_800x600_Basic_reescaled;
                    break;
                case "MONOCHROMATIC":
                    Icon = Resources.MONO_logo_83x681;
                    pictureBox1.Image = Resources.MONO_logo_83x68;
                    break;
                case "MONOCROMÁTICO":
                    Icon = Resources.MONO_logo_83x681;
                    pictureBox1.Image = Resources.MONO_logo_83x68;
                    break;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (button4.Text == "-")
            {
                Size = MinimumSize;
                button4.Text = "+";
            }
            else if (button4.Text == "+")
            {
                Size = this.MaximumSize;
                button4.Text = "-";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            /*archivoToolStripMenuItem (File)
             * newToolStripMenuItem (File->New)
             * openToolStripMenuItem (File->Open)
             * helpToolStripMenuItem (Help)
             * aboutRecipToolStripMenuItem (Help->About Recip)
             * button1 (Open)
             * button2 (Make)
             * groupBox1 (App Settings)
             * comboBox1 (Color)
             * button3 (Set logo)
             * groupBox2 (Latest recipes)
             * comboBox1.Contenidos (Color, Color reescalated...)
             * languageToolStripMenuItem (Language)
             * toolStripMenuItem1 (./)
             */
            button5.Text = Settings.Default.LastRecipe;
            button6.Text = Settings.Default.penLastRecipe;
            archivoToolStripMenuItem.Text = Strings.MenuFile;
            newToolStripMenuItem.Text = Strings.MenuFileNew;
            openToolStripMenuItem.Text = Strings.MenuFileOpen;
            helpToolStripMenuItem.Text = Strings.MenuHelp;
            aboutRecipToolStripMenuItem.Text = Strings.MenuHelpAbout;
            button1.Text = Strings.BtnOpen;
            button2.Text = Strings.BtnMake;
            groupBox1.Text = Strings.GroupAppSettings;
            comboBox1.Items.Clear();
            comboBox1.Items.Add(Strings.ComboBW);
            comboBox1.Items.Add(Strings.ComboColor);
            comboBox1.Items.Add(Strings.ComboColorRescaled);
            comboBox1.Items.Add(Strings.ComboMonochromatic);
            groupBox2.Text = Strings.GroupLatestRecipes;
            ToolTip toolTip1 = new ToolTip();
            toolTip1.SetToolTip(button7, Strings.ToolTipReset);
            ToolTip restart = new ToolTip();
            restart.SetToolTip(button8, Strings.ToolTipRestart);
            languageToolStripMenuItem.Text = Strings.MenuLanguage;
            toolStripMenuItem1.Text = Strings.MenuLanguageChange;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string nlr = Strings.BtnNoLastRecipe;
            string nr = Strings.BtnNoRecipe;
            string nrs = Strings.MsgNoRecipeSelected;
            if (button5.Text == nlr || button5.Text == nr)
            {
                MessageBox.Show(nrs, "RECIP", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            RecipeOpened.RecipeRute = Settings.Default.LRRoute;
            new RecipeOpened().ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string nlr = Strings.BtnNoLastRecipe;
            string nr = Strings.BtnNoRecipe;
            string nrs = Strings.MsgNoRecipeSelected;
            if (button6.Text == nr || button6.Text == nlr)
            {
                MessageBox.Show(nrs, "RECIP", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            RecipeOpened.RecipeRute = Settings.Default.pLRRoute;
            new RecipeOpened().ShowDialog();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var dialog = new OpenFileDialog())
            {
                dialog.Filter = "Recipes|*.rec|All files|*.*";
                dialog.Title = "Where is the recipe?";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        Settings.Default.penLastRecipe = Settings.Default.LastRecipe;
                        Settings.Default.pLRRoute = Settings.Default.LRRoute;
                        Settings.Default.LastRecipe = dialog.FileName.Substring(dialog.FileName.LastIndexOf('\\') + 1);
                        Settings.Default.LRRoute = dialog.FileName;
                        Settings.Default.Save();
                        RecipeOpened.RecipeRute = dialog.FileName;
                        new RecipeOpened().ShowDialog();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new MakeRecipe().ShowDialog();
        }

        private void aboutRecipToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new About().ShowDialog();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new lang().ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string msg = Strings.MsgResetSettings;
            var dr = MessageBox.Show(msg, "RECIP", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            switch (dr)
            {
                case DialogResult.Yes:
                    ResetSettings();
                    break;
                case DialogResult.No:
                    break;
            }
        }
        void ResetSettings()
        {
            Settings.Default.Reset();
            Settings.Default.Save();
            MessageBox.Show("Settings reseted", "RECIP", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Application.Restart();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void languageToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
