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
            Console.Title = "Cases Program";
            string tempCheck = Path.Combine(Directory.GetCurrentDirectory() + "/data/");
            if (!Directory.Exists(tempCheck))
            {
                Console.WriteLine("Data Mappe ikke fundet");
                Directory.CreateDirectory(tempCheck);
                Console.WriteLine("Data Mappe Oprettet\n");
                Thread.Sleep(2000);
            }
            if (!File.Exists(tempCheck + "/data.txt"))
            {
                Console.WriteLine("Data Fil ikke fundet");
                var Cfile = File.Create(tempCheck + "/data.txt");
                Cfile.Close();
                Console.WriteLine("Data Fil Oprettet\n");
                Thread.Sleep(2000);
            }
            Console.WriteLine("Indlæser...");
            Thread.Sleep(2000);
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
        }

        public static void ErrorMsg(string msg)
        {
            Console.WriteLine("\n" + msg);
            Thread.Sleep(3000);
        }
    }
}
