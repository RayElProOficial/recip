using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RecipCore
{
    public partial class MakeRecipe : Form
    {
        public MakeRecipe()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string entrada = textBox1.Text;
            string archivo = LimpiarNombreArchivo(entrada); // Resultado: como_hacer_esta_receta
            saveFileDialog1.FileName = archivo + ".rec";
            saveFileDialog1.ShowDialog();

        }
        public static string LimpiarNombreArchivo(string texto)
        {
            // Convertir a minúsculas
            texto = texto.ToLowerInvariant();

            // Quitar acentos y ñ → n
            texto = QuitarAcentos(texto);

            // Reemplazar espacios por _
            texto = texto.Replace(' ', '_');

            // Eliminar signos especiales específicos
            texto = texto.Replace("¿", "").Replace("¡", "");

            // Reemplazar caracteres prohibidos por _
            var prohibidos = Path.GetInvalidFileNameChars();
            foreach (char c in prohibidos)
            {
                texto = texto.Replace(c, '_');
            }

            return texto;
        }
        private static string QuitarAcentos(string texto)
        {
            var normalized = texto.Normalize(NormalizationForm.FormD);
            var sb = new StringBuilder();

            foreach (var c in normalized)
            {
                var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
                if (unicodeCategory != UnicodeCategory.NonSpacingMark)
                {
                    // Reemplazar ñ y Ñ manualmente, ya que se pierden con Normalize
                    if (c == 'ñ') sb.Append('n');
                    else if (c == 'Ñ') sb.Append('n');
                    else sb.Append(c);
                }
            }

            return sb.ToString().Normalize(NormalizationForm.FormC);
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

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void MakeRecipe_Load(object sender, EventArgs e)
        {
            label1.Text = Strings.LabelRecipeName;
            label2.Text = Strings.LabelIngredients;
            label3.Text = Strings.LabelSteps;
            button1.Text = Strings.BtnSave;
            button2.Text = Strings.BtnClose;
        }
    }
}
