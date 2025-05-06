using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

public class RecipApp
{ 
    public static List<string> ReadSection(string filePath, string sectionName)
    {
        List<string> lines = File.ReadAllLines(filePath).ToList();
        List<string> sectionLines = new List<string>();
        bool inSection = false;

        foreach (string line in lines)
        {
            if (line.Trim().StartsWith("[") && line.Trim().EndsWith("]"))
            {
                inSection = line.Trim().Equals($"[{sectionName}]", StringComparison.OrdinalIgnoreCase);
            }
            else if (inSection)
            {
                if (line.Trim().StartsWith("[") && line.Trim().EndsWith("]"))
                {
                    break; // Salir de la sección si encontramos otra sección
                }
                sectionLines.Add(line);
            }
        }

        return sectionLines;
    }
}
