using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerjeOppgaveAnsatte
{
    class FileHandler
    {
        public List<string> TextToListOfLines(string fileLocation)
        {
            string line;
            var lines = new List<string>();
            var file = new StreamReader(fileLocation);
            while ((line = file.ReadLine()) != null)
            {
                lines.Add(line);
            }
            file.Close();
            return lines;
        }
    }
}
