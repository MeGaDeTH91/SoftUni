using System.Collections.Generic;

public interface IWareHouse
{
    Dictionary<string, int> Ammunitions { get; }

    void AddAmmunitions(string name, int count);

    void EquipArmy(IArmy army);

    bool TryEquipSoldier(ISoldier soldier);
}