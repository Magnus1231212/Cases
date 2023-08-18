using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;

namespace Cases
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string tempCheck = Path.Combine(Directory.GetCurrentDirectory() + "/data.txt");
            if (!File.Exists(tempCheck))
            {
                Console.Clear();
                Console.WriteLine("Kunne ikke finde data.txt");
                Console.WriteLine("Opret venligst filen og prøv igen");
                Console.ReadKey();
                System.Environment.Exit(0);
            }
            Console.Title = "Cases Program";
            Console.Clear();
            if(Login.StartLogin())
            {

            } else
            {
                Console.Clear();
                Console.WriteLine("Fejl: Genstat programmet og prøv igen");
                Console.ReadKey();
                System.Environment.Exit(0);
            }
            Menu.Build();

            Console.ReadKey();
        }

        public static void ErrorMsg(string msg)
        {
            Console.WriteLine("\n" + msg);
            Thread.Sleep(3000);
        }
    }
}
