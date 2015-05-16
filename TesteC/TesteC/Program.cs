using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace TesteC
{
    struct test
    {
        public string X, Y;
       
    }
    class Program
    {
        private static void modifica(ref test unu)
        {
            unu.X = 620.ToString();
        }
        static void Main(string[] args)
        {
            test p1 = new test();
            p1.X = 120.ToString();
            Console.WriteLine("p1.X: "+p1.X);
            test p2 = p1;
            Console.WriteLine("p2.X: "+p2.X);
            p1.X = 320.ToString();
            Program.modifica(ref p1);
            Console.WriteLine("p1.X: " + p1.X);
            Console.WriteLine("p2.X: " + p2.X);
            Console.WriteLine(1.GetType());
            Console.ReadLine();

        }
    }
}
