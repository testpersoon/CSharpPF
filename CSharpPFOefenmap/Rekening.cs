using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPFOefenmap
{
    public delegate void Transactie(Rekening rekening);
    public abstract class Rekening: ISpaarmiddel
    {
        public Klant Eigenaar {get; set; }

        private string rekeningnummerValue;
        public string Rekeningnummer
        {
            get
            {
                return rekeningnummerValue;
            }
            set
            {
                if (IsGeldigRekeningnummer(value)){
                    rekeningnummerValue = value;
                }
            }
        }

        private DateTime creatiedatumValue;
        public DateTime Creatiedatum
        {
            get
            {
                return creatiedatumValue;
            }
            set
            {
                if (value.Year >= 1900)
                {
                    creatiedatumValue = value;
                }
            }
        }

        public decimal Saldo { get; set; }

        public Rekening(string nummer, decimal saldo, DateTime creatieDatum, Klant eigenaar)
        {
            Rekeningnummer = nummer;
            Saldo = saldo;
            Creatiedatum = creatieDatum;
            Eigenaar = eigenaar;
        }

        public virtual void Afbeelden()
        {
            if (Eigenaar != null)
            {
                Console.WriteLine("Eigenaar");
                Eigenaar.Afbeelden();
            }
            Console.WriteLine("Rekeningnummer: " + rekeningnummerValue);
            Console.WriteLine("Saldo: " + Saldo + " euro");
            Console.WriteLine("Creatiedatum: " + creatiedatumValue);
        }

        public void Storten(decimal bedrag)
        {
            if (bedrag > 0)
            {
                VorigSaldo = Saldo;
                Saldo += bedrag;
                RekeningUittreksel?.Invoke(this);
            }
        }
        private bool IsGeldigRekeningnummer(string rekeningnummer)
        {
            string controleNr = rekeningnummer.Replace(" ", "");

            if (controleNr.Length == 16
                    && controleNr.Substring(0, 2) == "BE"
                    && double.TryParse(controleNr.Substring(2, 2), out double eersteTweeCijfers)
                    && double.TryParse(controleNr.Substring(4, 10), out double tienCijfers)
                    && double.TryParse(controleNr.Substring(14, 2), out double laatsteTweeCijfers)
                    && laatsteTweeCijfers == tienCijfers % 97)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public event Transactie RekeningUittreksel;
        public event Transactie SaldoInHetRood;
        public decimal VorigSaldo { get; set; }
        public void Afhalen(decimal bedrag)
        {
            if (bedrag > 0 && bedrag <= Saldo)
            {
                VorigSaldo = Saldo;
                Saldo -= bedrag;
                RekeningUittreksel?.Invoke(this);
            }
            else if (bedrag > 0 && bedrag > Saldo)
            {
                SaldoInHetRood?.Invoke(this);
            }
        }
    }
}
