﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;
using Cases;

namespace Cases
{
    internal class Login
    {
        public static string MenuName { get; set; }

        public bool StartLogin()
        {
            bool IsLoggedIn = false;
            int choice = 0;
            do
            {
                Console.Clear();
                Console.WriteLine("Vælg hvad du vil.\n");
                Console.WriteLine("1. Login via eksisterende bruger");
                Console.WriteLine("2. Opret ny bruger");
                Console.WriteLine("3. Exit\n");
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
                            if (UserLogin())
                            {
                                IsLoggedIn = true;
                            }
                            break;
                        }
                    case 2:
                        {
                            UserSetup();
                            break;
                        }
                    case 3:
                        {
                            System.Environment.Exit(0);
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

        public bool UserLogin()
        {
            bool done = false;
            string pass = null;
            string user = null;
            while(!done)
            {
                Console.Clear();
                Console.WriteLine("Velkommen til Login siden!\n");
                Console.WriteLine("Indtast venligst din data");
                Console.Write("Brugernavn: ");
                user = Console.ReadLine();
                Console.Write("Password: ");
                pass = Console.ReadLine();
                if(LoginHandler(user, pass))
                {
                    done = true;
                    MenuName = user;
                    return true;

                } else
                {
                    Program.ErrorMsg("brugernavn eller password er forkert angivet!");
                }
            }
            return false;
        }

        public void UserReset(string _user)
        {
            bool done = false;
            string npassword = null;
            string user = _user;

            while (!done)
            {
                Console.Clear();
                Console.WriteLine("Velkommen til Password Reset siden!\n");
                Console.WriteLine("Indtast dit nye pasword");
                Console.Write("Password: ");
                npassword = Console.ReadLine();
                if (string.IsNullOrEmpty(npassword))
                {
                    Program.ErrorMsg("Du kan ikke have et tomt password");
                }
                else if (npassword.Length < 12)
                {
                    Program.ErrorMsg("Du skal indtaste et password der er længere end 12 tegn");
                }
                else if (!npassword.Any(upper => char.IsUpper(upper)) || !npassword.Any(lower => char.IsLower(lower)) || !npassword.Any(degit => char.IsDigit(degit)))
                {
                    Program.ErrorMsg("Dit password skal indeholde både små og store bogstaver og tal");
                }
                else if (char.IsDigit(npassword[0]) || char.IsDigit(npassword[npassword.Length - 1]))
                {
                    Program.ErrorMsg("Der må ikke være tal i starten og slutningen af passwordet");
                }
                else if (npassword.Any(space => char.IsWhiteSpace(space)))
                {
                    Program.ErrorMsg("Der må ikke være mellemrum i dit password");
                }
                else if (!CheckSymbols(npassword))
                {
                    Program.ErrorMsg("Der Skal være speciale karktere i dit password");
                }
                else
                {
                    if (changeUsr(user, npassword))
                    {
                        Program.ErrorMsg("Dit password er nu ændret");
                        done = true;
                    }
                    else
                    {
                        Program.ErrorMsg("Du kan ikke ændre dit password til et tideligere password");
                    }
                    
                };
            }
        }

        public bool LoginHandler(string user, string pass)
        {
            bool auth = false;
            string[] sdata = null;
            string path = Path.Combine(Directory.GetCurrentDirectory() + "/data/data.txt");
            string[] data = File.ReadAllLines(path);
            int length = data.Length;
            for (int i = 0; i < length; i++)
            {
                sdata = data[i].Split(' ');
                if (sdata[0] == user && sdata[1] == pass)
                {
                    auth = true;
                }
            }
            if(auth)
            {
                return true;
            }
            return false;
        }

        public string addUsr(string user, string pass)
        {
            bool ufound = false;
            string[] sdata = null;
            string path = Path.Combine(Directory.GetCurrentDirectory(), "data");
            string[] data = File.ReadAllLines(Path.Combine(path, "data.txt"));
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
                string[] saveData = new string[] {user + " " + pass};
                File.AppendAllLines(Path.Combine(path, "data.txt"), saveData);
                var cFile = File.Create(Path.Combine(path, user + "_data.txt"));
                cFile.Close();
                string[] addPass = new string[] { pass };
                File.AppendAllLines(Path.Combine(path, user + "_data.txt"), addPass);
                return "";
            }
            return "User Was Found";
        }

        public bool changeUsr(string user, string npass)
        {
            int ufound = -1;
            bool rfound = false;
            string[] sdata = null;
            string path = Path.Combine(Directory.GetCurrentDirectory(), "data");
            string[] data = File.ReadAllLines(Path.Combine(path, "data.txt"));
            string[] updata = File.ReadAllLines(Path.Combine(path, user + "_data.txt"));
            int length = data.Length;
            for (int i = 0; i < length; i++)
            {
                sdata = data[i].Split(' ');
                if (sdata[0] == user)
                {
                    ufound = i;
                }
            }
            if (ufound != -1)
            {
                foreach (string up in updata)
                {
                    if(up == npass)
                    {
                        rfound = true;
                    }
                }
                if (rfound)
                {
                    return false;
                } else
                {
                    data[ufound] = user + " " + npass;
                    File.WriteAllLines(Path.Combine(path, "data.txt"), data);
                    string[] addPass = new string[] { npass };
                    File.AppendAllLines(Path.Combine(path, user + "_data.txt"), addPass);
                    return true;
                }
            }
            return false;
        }

        public bool CheckSymbols(string text)
        {
            bool isValid = false;
            char[] symbols = new char[] { '!', '"', '#', '$', '%', '&', '\'', '(', ')', '*', '+', ',', '-', '.', '/', ':', ';', '<', '=', '>', '?', '@', '[', '\\', ']', '^', '_', '`', '{', '|', '}', '~' };
            foreach (char symbol in symbols)
            {
                if(text.Contains(symbol))
                {
                    isValid = true;
                }
            }
            if(isValid)
            {
                return true;
            }
            return false;
        }

        public void UserSetup()
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
                    }else if (!CheckSymbols(password)) {
                        Program.ErrorMsg("Der Skal være speciale karktere i dit password");
                    }
                    else
                    {
                        pass = true;
                    }
                };

                addUsr(username, password);
                done = true;

            }while (!done);
        }
    }
}
