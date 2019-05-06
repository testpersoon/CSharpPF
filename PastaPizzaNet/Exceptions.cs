using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PastaPizzaNet
{
    public class GeenFrisdrankException : Exception
    {
        public string VerkeerdeDrank { get; set; }
        public GeenFrisdrankException(string message, string verkeerdeDrank) : base(message)
        {
            VerkeerdeDrank = verkeerdeDrank;
        }
    }
    public class GeenWarmeDrankException : Exception
    {
        public string VerkeerdeDrank { get; set; }
        public GeenWarmeDrankException(string message, string verkeerdeDrank) : base(message)
        {
            VerkeerdeDrank = verkeerdeDrank;
        }
    }
    public class PrijsVanDessertNietGevonden : Exception
    {
        public string VerkeerdDessert { get; set; }
        public PrijsVanDessertNietGevonden(string message, string verkeerdDessert) : base(message)
        {
            VerkeerdDessert = verkeerdDessert;
        }
    }
}
