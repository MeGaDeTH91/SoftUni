public class MachineGun : Ammunition
{
    public const double MachineGunWeight = 10.6d;

    public MachineGun(string name)
        : base(name, MachineGunWeight)
    {
    }
}