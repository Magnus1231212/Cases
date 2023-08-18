using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Cases
{
    internal class Menu
    {
        public static void Build()
        {
            Login cUser = new Login();
            string mname = Login.MenuName;
            int choice = 0;
            bool exit = false;
            Console.Clear();
            Console.Title = "Main Menu";
            Console.WriteLine("Velkommen " + mname + "\n");

            do
            {
                Console.Clear();
                Console.WriteLine("Vælg hvad du vil.\n");
                Console.WriteLine("1. Fodbold");
                Console.WriteLine("2. Dans");
                Console.WriteLine("3. Ændre Password");
                Console.WriteLine("4. Exit\n");
                Console.Write("Valg: ");

                try
                {
                    choice = int.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.Clear();
                    Console.WriteLine("Du skal indtaste et tal");
                    Thread.Sleep(2000);
                    Console.Clear();
                };

                switch (choice)
                {
                    case 1:
                        {
                            break;
                        }
                    case 2:
                        {
                            break;
                        }
                    case 3:
                        {
                            Login.UserReset(mname);
                            break;
                        }
                    case 4:
                        {
                            exit = true;
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Du Skal vælge en funktion.");
                            Thread.Sleep(2000);
                            break;
                        }
                }
            } while (!exit);
        }
    }
}
