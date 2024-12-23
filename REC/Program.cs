﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

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
