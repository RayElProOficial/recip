using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using recip.Properties;

namespace REC
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            switch (Settings.Default.Language)
            {
                case "ES":
                    Strings.SetLang(Language.Spanish);
                    if (Settings.Default.penLastRecipe == "No recipe")
                    {
                        Settings.Default.penLastRecipe = "Sin receta";
                    }
                    if (Settings.Default.LastRecipe == "No last recipe")
                    {
                        Settings.Default.LastRecipe = "Sin última receta";
                    }
                    if (Settings.Default.LastRecipe == "No recipe")
                    {
                        Settings.Default.LastRecipe = "Sin receta";
                    }
                    if (Settings.Default.penLastRecipe == "No last recipe")
                    {
                        Settings.Default.penLastRecipe = "Sin última receta";
                    }
                    Settings.Default.Save();
                    break;
                case "EN":
                    Strings.SetLang(Language.English);
                    if (Settings.Default.penLastRecipe == "Sin receta")
                    {
                        Settings.Default.penLastRecipe = "No recipe";
                    }
                    if (Settings.Default.LastRecipe == "Sin última receta")
                    {
                        Settings.Default.LastRecipe = "No last recipe";
                    }
                    if (Settings.Default.LastRecipe == "Sin receta")
                    {
                        Settings.Default.LastRecipe = "No recipe";
                    }
                    if (Settings.Default.penLastRecipe == "Sin última receta")
                    {
                        Settings.Default.penLastRecipe = "No last recipe";
                    }
                    Settings.Default.Save();
                    break;

            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (args.Length > 0)
            {
                string file = args[0];
                RecipeOpened.RecipeRute = file;
                RecipeOpened.OpenedByFile = true;
                Application.Run(new RecipeOpened());
            }
            else
            {
                Application.Run(new Form1());
            }
        }
    }
}
