using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PastaPizzaNet
{
    public class PrijsVanDessertNietGevonden : Exception
    {
        public string VerkeerdDessert { get; set; }
        public PrijsVanDessertNietGevonden(string message, string verkeerdDessert) : base(message)
        {
            VerkeerdDessert = verkeerdDessert;
        }
    }
}
