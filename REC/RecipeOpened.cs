using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace REC {
    public partial class RecipeOpened : Form
    {
        public static string RecipeRute;
        public static bool OpenedByFile;
        public RecipeOpened()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void RecipeOpened_Load(object sender, EventArgs e)
        {
            textBox1.Text = null;
            textBox2.Text = null;
            if (OpenedByFile!=true)
            {
                button2.Hide();
            }
            else
            {
                button1.Hide();
            }
            string filePath = RecipeRute;
            string sectionName = "Ingredients";
            List<string> sectionLines = RecipApp.ReadSection(filePath, sectionName);

            foreach (string line in sectionLines)
            {
                if (string.IsNullOrEmpty(textBox1.Text)) // Verifica si el TextBox está vacío
                {
                    textBox1.Text = line;
                }
                else
                {
                    textBox1.Text += "\r\n" + line; // Agrega un salto de línea solo si ya hay texto
                }
            }

            sectionName = "Steps";
            sectionLines = RecipApp.ReadSection(filePath, sectionName);

            foreach (string line in sectionLines)
            {
                if (string.IsNullOrEmpty(textBox2.Text)) // Verifica si el TextBox está vacío
                {
                    textBox2.Text = line;
                }
                else
                {
                    textBox2.Text += "\r\n" + line; // Agrega un salto de línea solo si ya hay texto
                }
            }


            sectionName = "RecipeName";
            sectionLines = RecipApp.ReadSection(filePath, sectionName);

            foreach (string line in sectionLines)
            {
                Text = line;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
