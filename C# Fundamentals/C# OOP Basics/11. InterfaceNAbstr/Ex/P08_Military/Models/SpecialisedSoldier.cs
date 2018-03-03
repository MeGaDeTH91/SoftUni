using System;

public class SpecialisedSoldier : Private, ISpecialisedSoldier
{
    private CorpsType corps;

    public CorpsType Corps
    {
        get { return corps; }
        set { corps = value; }
    }

    public SpecialisedSoldier(int id, string firstName, string lastName, decimal salary, CorpsType corps) : base(id, firstName, lastName, salary)
    {
        this.Corps = corps;
    }
}