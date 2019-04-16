using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Firma;
using Firma.Personeel;
using Firma.Materiaal;
using MateriaalStatus = Firma.Materiaal.Status;
using PersoneelStatus = Firma.Personeel.Status;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;


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
            try
            {
                using (var bestand = File.Open(@"C:\Users\net07\Documents\CSharpPF\CSharpPFCursus\Pizza.obj", FileMode.Open, FileAccess.Read))
                {
                    var lezer = new BinaryFormatter();
                    Pizza pizza;
                    pizza = (Pizza)lezer.Deserialize(bestand);
                    Console.WriteLine(pizza.Naam);
                    foreach (var onderdeel in pizza.Onderdelen)
                        Console.WriteLine(onderdeel);
                    Console.WriteLine(pizza.Prijs);
                }
            }
            catch (SerializationException)
            {
                Console.WriteLine("Fout bij het deserialiseren");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
