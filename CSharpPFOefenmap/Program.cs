using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPFOefenmap
{
    class Program
    {
        static void Main(string[] args)
        {
            var pw = new Personenwagen("jos", 20000m, 250, 10.2f, "1DFE152", 5, 1);
            var vw = new Vrachtwagen("flup", 19999m, 95, 20.2f, "2PKE999", 5200f);
            IPrivaat[] voertuigen = new IPrivaat[2];
            voertuigen[0] = pw;
            voertuigen[1] = vw;
            foreach (IPrivaat voertuig in voertuigen)
            {
                Console.WriteLine(voertuig.GeefPrivateData());
            }

            IMilieu[] anderevoertuigen = new IMilieu[2];
            anderevoertuigen[0] = vw;
            anderevoertuigen[1] = pw;
            foreach (IMilieu voertuig in anderevoertuigen)
                Console.WriteLine(voertuig.GeefMilieuData());
        }
    }
}
