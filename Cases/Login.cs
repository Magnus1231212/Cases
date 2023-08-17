using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Cases
{
    internal class Login
    {
        public static void StartLogin()
        {
            bool IsLoggedIn = false;
            int choice = 0;
            do
            {
                Console.Clear();
                Console.WriteLine("Vælg hvad du vil.\n");
                Console.WriteLine("1. Login via eksisterende bruger");
                Console.WriteLine("2. Opret ny bruger");
                Console.WriteLine("3. Ændre password på eksisterende bruger\n");
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
                            UserSetup();
                            break;
                        }
                    case 3:
                        {
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Du Skal vælge en funktion.");
                            Thread.Sleep(2000);
                            break;
                        }
                }
            } while (!IsLoggedIn);
        }

        public static void UserLogin()
        {

        }

        public static bool UserSetup()
        {
            string username = null;
            string password = null;
            bool done = false;
            Console.Clear();
            Console.WriteLine("Velkommen til Oprettelses siden!\n");
            do
            {
                Console.WriteLine("Indtast et brugernavn.");
                Console.Write("Brugernavn: ");
                username = Console.ReadLine();
                if (string.IsNullOrEmpty(username))
                {
                    Console.WriteLine("\nDu skal indtaske et brugernavn\n");
                } else
                {
                    return true;
                }

                Console.WriteLine("Indtast et password");
                password = Console.ReadLine();
                if (password.Length < 12)
                {
                    
                }
                else
                {
                    return false;
                }
            }while (!done);
            if (done)
            {
                return true;
            } else
            {
                return false;
            }
        }
    }
}
