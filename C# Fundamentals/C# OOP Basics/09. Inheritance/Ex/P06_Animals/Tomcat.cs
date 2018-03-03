using System;

public class Tomcat : Cat, ISoundProducable
{
    public Tomcat(string name, int age, string gender) : base(name, age, gender)
    {
        this.Gender = "Male";
    }

    public override string ProduceSound()
    {
        return "MEOW";
    }
}
