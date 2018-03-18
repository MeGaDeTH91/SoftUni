using System;

public abstract class Item
{
    private int weight;

    protected Item(int weight)
    {
        this.Weight = weight;
    }

    public virtual void AffectCharacter(Character character)
    {
        if (!character.IsAlive)
        {
            throw new InvalidOperationException("Must be alive to perform this action!");
        }
    }

    public int Weight
    {
        get { return this.weight; }
        protected set { this.weight = value; }
    }

}
