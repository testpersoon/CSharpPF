using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Firma;
using Firma.Personeel;
using Firma.Materiaal;
using MateriaalStatus = Firma.Materiaal.Status;
using PersoneelStatus = Firma.Personeel.Status;


namespace CSharpPFCursus
{
    public enum Seizoen
    {
        Lente, Zomer, Herfst, Winter
    }

    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Fotokopiemachine machine =
                new Fotokopiemachine("123", -100, -5.4m);
                Console.WriteLine("Machine goed ingevuld");
            }
            catch (Fotokopiemachine.KostPerBlzException ex)
            {
                Console.WriteLine("Fout:" + ex.Message + ':' +
                ex.VerkeerdeKost);
            }
            catch (Fotokopiemachine.AantalGekopieerdeBlzException ex)
            {
                Console.WriteLine("Fout:" + ex.Message + ':' +
                ex.VerkeerdAantalBlz);
            }
            Console.WriteLine("Einde programma");
        }
    }
}
