using System.Collections.Generic;
using System.Linq;

public class WareHouse : IWareHouse
{
    private Dictionary<string, int> ammunitions;

    private AmmunitionFactory ammunitionFactory;

    public WareHouse()
    {
        this.Ammunitions = new Dictionary<string, int>();

        this.ammunitionFactory = new AmmunitionFactory();
    }

    public Dictionary<string, int> Ammunitions
    {
        get
        {
            return this.ammunitions;
        }
        private set
        {
            this.ammunitions = value;
        }
    }

    public void AddAmmunitions(string name, int count)
    {
        if (!this.Ammunitions.ContainsKey(name))
        {
            this.Ammunitions[name] = 0;
        }
        this.Ammunitions[name] += count;
    }

    public void EquipArmy(IArmy army)
    {
        foreach (ISoldier soldier in army.Soldiers)
        {
            this.TryEquipSoldier(soldier);
        }
    }

    public bool TryEquipSoldier(ISoldier soldier)
    {
        bool isEquipped = true;

        List<string> missingWeapons = soldier.Weapons.Where(w => w.Value == null).Select(w => w.Key).ToList();

        foreach (string weaponName in missingWeapons)
        {
            if (this.ammunitions.ContainsKey(weaponName) && this.ammunitions[weaponName] > 0)
            {
                soldier.Weapons[weaponName] = this.ammunitionFactory.CreateAmmunition(weaponName);
                this.ammunitions[weaponName]--;
            }
            else
            {
                isEquipped = false;
            }
        }

        return isEquipped;
    }
}
