﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Cases
{
    internal class Menu
    {
        public void Build()
        {
            string mname = Login.MenuName;
            int choice = 0;
            bool exit = false;
            Console.Clear();
            Console.Title = "Main Menu";

            do
            {
                Console.Clear();
                Console.WriteLine("Velkommen " + mname + "\n");
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
                            Fodbold fodbold = new Fodbold();
                            Console.WriteLine(fodbold.FodboldLogic());
                            Thread.Sleep(3000);
                            break;
                        }
                    case 2:
                        {
                            Console.Clear();
                            Dans person1 = new Dans();
                            Dans person2 = new Dans();

                            person1.setData();
                            person2.setData();

                            Dans par = person1 + person2;

                            Console.WriteLine("{0} {1}", par.Name, par.Points);
                            Thread.Sleep(4000);
                            break;
                        }
                    case 3:
                        {
                            Login cUser = new Login();
                            cUser.UserReset(mname);
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
