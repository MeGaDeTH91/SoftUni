using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14.Boat_Simulator
{
    class Program
    {
        static void Main(string[] args)
        {
            char firstBoat = char.Parse(Console.ReadLine());
            char secondBoat = char.Parse(Console.ReadLine());

            
            int boat1 = 50;
            int boat2 = 50;
            int n = int.Parse(Console.ReadLine());
            for (int i = 1; i <= n; i++)
            {
                string move = Console.ReadLine();
                if (move == "UPGRADE")
                {
                    firstBoat = (char)(firstBoat + 3);
                    secondBoat = (char)(secondBoat + 3);
                }
                if (i % 2 > 0 && move != "UPGRADE")
                {
                    boat1 = boat1 - (move.Length);
                }
                else if (i % 2 == 0 && move != "UPGRADE")
                {
                    boat2 = boat2 - (move.Length);
                }
                if (boat1 == 0 || boat2 == 0 || boat1 < 0 || boat2 < 0)
                {

                    break;
                }
            }
            if(boat1 <= 0)
            {
                Console.WriteLine(firstBoat);
            }
           else if (boat2 <= 0)
            {
                Console.WriteLine(secondBoat);
            }
            else
            {
                if(boat1 > boat2)
                {
                    Console.WriteLine(secondBoat);
                }
                else
                {
                    Console.WriteLine(firstBoat);
                }
            }

        }
    }
}
