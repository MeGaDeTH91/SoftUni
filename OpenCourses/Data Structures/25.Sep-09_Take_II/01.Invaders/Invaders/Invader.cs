using System;

public class Invader : IInvader
{
    public Invader(int damage, int distance)
    {
        this.Damage = damage;
        this.Distance = distance;
    }
    
    public int Damage { get; set; }
    public int Distance { get; set; }

    public int CompareTo(IInvader other)
    {
        int firstCheck = this.Distance.CompareTo(other.Distance);

        if(firstCheck == 0)
        {
            return other.Damage.CompareTo(this.Damage);
        }
        return firstCheck;
    }
}
