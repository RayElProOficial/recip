using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace recip
{
    public partial class MakeRecipe : Form
    {
        public MakeRecipe()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            string[] inf =
            {
                "[RecipeName]",
                $"{textBox1.Text}",
                "[Ingredients]",
                $"{textBox2.Text}",
                "[Steps]",
                $"{textBox3.Text}"
            };
            File.WriteAllLines(saveFileDialog1.FileName, inf);
        }
    }
}
