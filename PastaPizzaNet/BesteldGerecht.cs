using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Voeding;

namespace PastaPizzaNet
{
    public class BesteldGerecht:IBedrag
    {
        static readonly decimal supplementGroot = 3m, supplementExtra = 1m;
        public BesteldGerecht(Gerecht gerecht, Grootte grootte = Grootte.Klein, int aantalBrood = 0, int aantalKaas = 0, int aantalLook = 0)
        {
            Gerecht = gerecht;
            Grootte = grootte;
            ExtraToevoegenAanLijst(Extra.Brood, aantalBrood);
            ExtraToevoegenAanLijst(Extra.Kaas, aantalKaas);
            ExtraToevoegenAanLijst(Extra.Look, aantalLook);
        }
        public void ExtraToevoegenAanLijst(Extra extra, int aantal)
        {
            if (Extras == null)
                Extras = new List<Extra>();
            for (int i = 0; i < aantal; i++) Extras.Add(extra);
        }
        public Gerecht Gerecht { get; set; }
        public Grootte Grootte { get; set; }
        public List<Extra> Extras { get; set; }
        public decimal BerekenBedrag()
        {
            decimal bedrag = 0;
            bedrag
                += Gerecht.BerekenBedrag()
                + (Grootte == Grootte.Groot ? supplementGroot : 0m)
                + Extras.Count * supplementExtra;
            return bedrag;
        }
        public override string ToString()
        {
            string extras = "";
            if (Extras.Count != 0)
            {
                extras = " extra:";
                foreach (Extra extra in Extras)
                {
                    extras += " " + extra.ToString();
                }
            }
            StringBuilder tekst = new StringBuilder();
            tekst.AppendFormat("{0} <{1}>{2} <bedrag: {3} euro>", Gerecht.ToString(), Grootte, extras, BerekenBedrag());
                            //e.g. "Spaghetti Bolognese <12 euro> met gehaktsaus <Groot> extra: Kaas <bedrag: 16 euro>"
            return tekst.ToString();
        }
    }
}
