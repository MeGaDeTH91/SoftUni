namespace P02_ExtendedDatabase
{
    using System;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            
            ExtendedDatabase db = new ExtendedDatabase();

            Person person = new Person(15, "Ivan Drago");
            Person person2 = new Person(16, "Ivan Drago2");


            db.Add(person);
            db.Add(person2);

            var temp = db.DatabasePeople;
        }
    }
}
