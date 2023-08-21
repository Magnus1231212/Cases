using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cases
{
    internal class Dans
    {
        public int Points { get; set; }
        public string Name { get; set; }

        public void setData()
        {
            Console.WriteLine("Skrive venligst dit navn");
            string name = Console.ReadLine();

            Console.WriteLine("Indtast vnligst points");
            int points = 0;
            try
            {
                points = int.Parse(Console.ReadLine());
            }catch(Exception)
            {
                Console.WriteLine("Du skal indtaste et tal!");
            }

            Name = name;
            Points = points;
        }

        public static Dans operator+ (Dans a, Dans b)
        {
            Dans partners = new Dans();
            partners.Points = a.Points + b.Points;
            partners.Name = a.Name + " & " + b.Name;
            return partners;
        }
    }
}
