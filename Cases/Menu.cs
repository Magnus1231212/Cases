using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cases
{
    internal class Menu
    {
        public static void Build()
        {
            Login cUser = new Login();
            string mname = Login.MenuName;
            Console.Clear();
            Console.Title = "Main Menu";
            Console.WriteLine("Velkommen " + mname);
            Console.ReadKey();
        }
    }
}
