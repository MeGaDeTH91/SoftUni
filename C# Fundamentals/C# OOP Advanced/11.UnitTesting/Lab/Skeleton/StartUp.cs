using System;
public class StartUp
{
    public static void Main(string[] args)
    {
        Axe axe = new Axe(10, 10);
        Dummy dummy = new Dummy(10, 100);
        axe.Attack(dummy);
        axe.Attack(dummy);
    }
}
