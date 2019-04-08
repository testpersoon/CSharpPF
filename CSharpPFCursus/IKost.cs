using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPFCursus
{
    interface IKost
    {
        decimal Bedrag { get; }
        bool Menselijk { get; }
    }
}