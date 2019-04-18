using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPFOefenmap
{
    [Serializable]
    public class Tweet
    {
        public string Naam { get; set; }
        private string berichtValue;
        public string Bericht
        {
            get
            {
                return berichtValue;
            }
            set
            {
                if (value.Length <= 280)
                {
                    berichtValue = value;
                }
            }
        }
        public DateTime Tijdstip { get; set; }
        public override string ToString()
        {
            TimeSpan verschil = DateTime.Now.Subtract(Tijdstip);
            var tekst = string.Empty;
            if (verschil.Days >= 1)
            {
                tekst += Tijdstip.ToString("dd-MM-yyyy") + "       ";
            }
            else if (verschil.Hours >= 1)
            {
                tekst += DateTime.Now.Subtract(Tijdstip).Hours.ToString() + " uur geleden   ";
            }
            else if (verschil.Minutes >= 1){
                tekst += DateTime.Now.Subtract(Tijdstip).Minutes.ToString() + " minuten geleden  ";
            }
            else
            {
                tekst += Tijdstip.ToString("HH:mm") + "            ";
            }
            tekst += $" - {Naam} - {Bericht}";
            return tekst;
        }
    }
}
