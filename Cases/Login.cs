using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;

namespace Cases
{
    internal class Login
    {

        public static bool StartLogin()
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
                            addUsr("UserTe", "Test");
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
            return true;
        }

        public static void UserLogin()
        {

        }

        public static string addUsr(string user, string pass)
        {
            bool ufound = false;
            string[] sdata = null;
            string path = Path.Combine(Directory.GetCurrentDirectory() + "/data.txt");
            string[] data = File.ReadAllLines(path);
            foreach (string udata in data)
            {
                sdata = udata.Split(' ');
                if (sdata[0] == user)
                {
                    ufound = true;
                }
            }
            if (!ufound)
            {
                string[] saveData = new string[] {pass};
                File.AppendAllLines(path, saveData);
            }
            Thread.Sleep(5000);
            return "User Was Found";
        }

        public static string changeUsr(string user, string npass)
        {
            //string ufound = null;
            //string[] sdata = null;
            //string path = Path.Combine(Directory.GetCurrentDirectory() + "/data.txt");
            //string[] data = File.ReadAllLines(path);
            //foreach (string udata in data)
            //{
            //    sdata = udata.Split(' ');
            //    if (sdata[0] == user)
            //    {
            //        ufound = true;
            //    }
            //}
            //if (!ufound)
            //{
            //    string[] saveData = new string[] { pass };
            //    File.AppendAllLines(path, saveData);
            //}
            //Thread.Sleep(5000);
            return "User Was Found";
        }

        public static bool UserSetup()
        {
            string username = null;
            string password = null;
            bool user = false;
            bool pass = false;
            bool done = false;
            do
            {
                while (!user) {
                    Console.Clear();
                    Console.WriteLine("Velkommen til Oprettelses siden!\n");
                    Console.WriteLine("Indtast et brugernavn.");
                    Console.Write("Brugernavn: ");
                    username = Console.ReadLine();
                    if (string.IsNullOrEmpty(username))
                    {
                        Program.ErrorMsg("Du kan ikke have et tomt brugernavn");
                    } 
                    else if (username.Any(space => char.IsWhiteSpace(space))) 
                    {
                        Program.ErrorMsg("Der må ikke være mellemrum i dit brugernavn");
                    }
                    else
                    {
                        user = true;
                    }
                };

                while (!pass)
                {
                    Console.Clear();
                    Console.WriteLine("Velkommen til Oprettelses siden!\n");
                    Console.WriteLine("Indtast et password");
                    Console.Write("Password: ");
                    password = Console.ReadLine();
                    if (string.IsNullOrEmpty(password))
                    {
                        Program.ErrorMsg("Du kan ikke have et tomt password");
                    }
                    else if (password.Length < 12)
                    {
                        Program.ErrorMsg("Du skal indtaste et password der er længere end 12 tegn");
                    } else if (!password.Any(upper => char.IsUpper(upper)) || !password.Any(lower => char.IsLower(lower)) || !password.Any(degit => char.IsDigit(degit))) {
                        Program.ErrorMsg("Dit password skal indeholde både små og store bogstaver og tal");
                    } else if (char.IsDigit(password[0]) || char.IsDigit(password[password.Length-1]))
                    {
                        Program.ErrorMsg("Der må ikke være tal i starten og slutningen af passwordet");
                    } else if (password.Any(space => char.IsWhiteSpace(space)))
                    {
                        Program.ErrorMsg("Der må ikke være mellemrum i dit password");
                    }
                    else
                    {
                        pass = true;
                    }
                };


                done = true;

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
