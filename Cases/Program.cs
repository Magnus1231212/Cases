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
            Login.StartLogin();
            Console.Clear();
            Console.WriteLine("Test");

            Console.ReadKey();
        }
    }
}
