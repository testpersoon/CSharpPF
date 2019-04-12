using System;
using System.Collections;
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
        public static void Main(string[] args)
        {
            var brouwers = new Brouwers().GetBrouwers();
            var alleBrouwers = from brouwer in brouwers orderby brouwer.Brouwernaam select new { brouwer.Brouwernaam, brouwer.Bieren.Count };
            foreach (var brouwer in alleBrouwers)
                Console.WriteLine(brouwer.ToString());
        }
    }
}
