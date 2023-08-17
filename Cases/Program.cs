using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Cases
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Program starting...");
            Console.Title = "Cases Program";
            Thread.Sleep(2000);
            Console.Clear();
            if(Login.StartLogin())
            {

            } else
            {
                Console.Clear();
                Console.WriteLine("Fejl: Genstat programmet og prøv igen");
            }
            Console.Clear();
            Console.WriteLine("Test");

            Console.ReadKey();
        }

        public static void ErrorMsg(string msg)
        {
            Console.WriteLine("\n" + msg);
            Thread.Sleep(3000);
        }
    }
}
