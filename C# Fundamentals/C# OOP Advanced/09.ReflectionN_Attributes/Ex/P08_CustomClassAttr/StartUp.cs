using System;
using System.Linq;
using System.Reflection;

namespace P08_CustomClassAttr
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Type weaponType = typeof(Weapon);

            var weaponAttributes = weaponType.GetCustomAttributes(false);

            WeaponAttribute myWeaponAtt = (WeaponAttribute)weaponAttributes.FirstOrDefault(x => x.GetType() == typeof(WeaponAttribute));

            string command;
            while((command = Console.ReadLine()) != "END")
            {
                switch (command)
                {
                    case "Author":
                        Console.WriteLine($"Author: {myWeaponAtt.Author}");
                        break;
                    case "Revision":
                        Console.WriteLine($"Revision: {myWeaponAtt.Revision}");
                        break;
                    case "Description":
                        Console.WriteLine($"Class description: {myWeaponAtt.Description}");
                        break;
                    case "Reviewers":
                        Console.WriteLine($"Reviewers: {string.Join(", ", myWeaponAtt.Reviewers)}");
                        break;
                    default:
                        break;
                }
            }

        }
    }
}
