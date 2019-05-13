using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PastaPizzaNet
{
    public class GeenWarmeDrankException : Exception
    {
        public string VerkeerdeDrank { get; set; }
        public GeenWarmeDrankException(string message, string verkeerdeDrank) : base(message)
        {
            VerkeerdeDrank = verkeerdeDrank;
        }
    }
}
