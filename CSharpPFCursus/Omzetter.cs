using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPFCursus
{
    public class Omzetter
    {
        public const double CentimetersPerInch = 2.54;
        public double CmNaarInch(double cm)
        {
            return cm / CentimetersPerInch;
        }
        public double InchNaarCm(double inch)
        {
            return inch * CentimetersPerInch;
        }
    }
}
