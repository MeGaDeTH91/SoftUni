using System;

public class ArmorRepairKit : Item
{
    private const int Armor_RepairKit_Weight = 10;

    public ArmorRepairKit() : base(Armor_RepairKit_Weight)
    {
    }

    public override void AffectCharacter(Character character)
    {
        base.AffectCharacter(character);
        character.RepairArmor();
    }
}
