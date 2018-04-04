namespace P07_InfernoInfinity
{
    using P07_InfernoInfinity.Factories;
    using P07_InfernoInfinity.Models.Enums;
    using P07_InfernoInfinity.Models.Gems;
    using P07_InfernoInfinity.Models.Weapons;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            Axe axe = new Axe("BigFuckinAxe", RarityType.Epic);
            WeaponFactory weaponFactory = new WeaponFactory();
            GemFactory gemFactory = new GemFactory();

            List<Weapon> weapons = new List<Weapon>();

            string command;
            while((command = Console.ReadLine()) != "END")
            {
                string[] commTokens = command.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

                string currentCommand = commTokens[0];

                switch (currentCommand)
                {
                    case "Create":
                        string[] createItemTypeAndRarity = commTokens[1].Split();
                        string rarityType = createItemTypeAndRarity[0];
                        string weaponType = createItemTypeAndRarity[1];
                        string weaponName = commTokens[2];

                        Weapon weaponToAdd = weaponFactory.CreateWeapon(rarityType, weaponType, weaponName);

                        weapons.Add(weaponToAdd);
                        break;
                    case "Add":
                        string enhanceWeaponName = commTokens[1];
                        int enhanceSocketIndex = int.Parse(commTokens[2]);
                        string[] gemArgs = commTokens[3].Split();

                        Gem currentGem = gemFactory.CreateGem(gemArgs);
                        Weapon weaponToEnhance = weapons.FirstOrDefault(x => x.Name.Equals(enhanceWeaponName));

                        weaponToEnhance.EnhanceWithGem(enhanceSocketIndex, currentGem);
                        break;
                    case "Remove":
                        string removeEnhanceWeaponName = commTokens[1];
                        int removeEnhanceSocketIndex = int.Parse(commTokens[2]);

                        Weapon weaponToRemoveEnhance = weapons.FirstOrDefault(x => x.Name.Equals(removeEnhanceWeaponName));

                        weaponToRemoveEnhance.RemoveGem(removeEnhanceSocketIndex);
                        break;
                    case "Print":
                        string printWeaponName = commTokens[1];
                        Weapon printWeapon = weapons.FirstOrDefault(x => x.Name.Equals(printWeaponName));
                        Console.WriteLine(printWeapon);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
