using System;

namespace P01_Database
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Database db = new Database(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17);
            
            db.Add(5);
            db.Add(5);
            db.Add(5);

            db.Remove();
        }
    }
}
