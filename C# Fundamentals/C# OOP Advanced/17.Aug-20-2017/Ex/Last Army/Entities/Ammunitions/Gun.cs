public class Gun : Ammunition
{
    public const double GunWeight = 1.4d;

    public Gun(string name)
        : base(name, GunWeight)
    {
    }
}