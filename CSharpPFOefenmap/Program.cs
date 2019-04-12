using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPFOefenmap
{
    public class Program
    {
        static void Main(string[] args)
        {
            Func<int, bool> even = getal => Math.Abs(getal) % 2 == 0;
            Func<int, bool> pos = getal => getal >= 0;
            var getallen = new List<int>
            { 2, 15, 8, 3, -5, 9, -91, 65, 2, -94, -84 };
            getallen.GetallenTonen
                (even, ConsoleColor.Green, ConsoleColor.Red);
            getallen.GetallenTonen
                (pos, ConsoleColor.White, ConsoleColor.Yellow);
        }
    }
    public static class MyListExtensions
    {
        public static void GetallenTonen(this List<int> getallen,
            Func<int, bool> test, ConsoleColor kleur1, ConsoleColor kleur2)
        {
            foreach (int getal in getallen)
            {
                Console.ForegroundColor = test(getal) ? kleur1 : kleur2;
                Console.Write($"{getal}, ");
            }
            Console.WriteLine();
        }
    }
}
