using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CSharpPFCursus
{
    public class ProvincieInfo
    {
        public int ProvincieGrootte(string provincieNaam)
        {
            StreamReader lezer = new StreamReader(@"C:\VS2017\provincies.txt");
            int oppervlakte = -1;
            string regel;
            while ((regel = lezer.ReadLine()) != null)
            {
                int dubbelPuntPos = regel.IndexOf(':');
                string provincie = regel.Substring(0, dubbelPuntPos);
                if (provincie == provincieNaam)
                    oppervlakte = int.Parse(regel.Substring(dubbelPuntPos + 1));
            }
            lezer.Close();
            if (oppervlakte == -1)
                throw new Exception("Onbestaande provincie: " + provincieNaam);
            else
                return oppervlakte;
        }
    }
}
