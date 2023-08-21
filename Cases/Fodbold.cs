using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cases
{
    internal class Fodbold
    {
        public static string FodboldLogic() {
            Console.Clear();
            Console.Write("Skriv input: ");
            int.TryParse(Console.ReadLine(), out int passeings);
            string goal = Console.ReadLine();

            if(goal.ToLower() == "mål")
            {
                return "Olé olé olé";
            } else
            {
                if(passeings == 0)
                {
                    return "Shh";
                } else if(passeings > 10)
                {
                    return "High Five – Jubel!";
                } else if (passeings < 10 && passeings > 0)
                {
                    string rebold = "\n";
                    for (int i = 0; i < passeings; i++)
                    {
                        rebold += "Huh! ";
                    }
                    return rebold;
                }
            }
            return "";
        }
    }
}
