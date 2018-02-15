using System;
using P02_DatabaseFirst.Data;
using P02_DatabaseFirst.Data.Models;
using System.Linq;

namespace _15_RemoveTowns
{
    class Program
    {
        static void Main(string[] args)
        {
            string townName = Console.ReadLine();
            using (var db = new SoftUniContext())
            {
                db.Employees
                     .Where(x => x.Address.Town.Name == townName)
                     .ToList()
                     .ForEach(x => x.AddressId = null);

                int addCount = db.Addresses
                    .Where(x => x.Town.Name == townName)
                    .Count();

                var removeAddress = db.Addresses
                    .Where(x => x.Town.Name == townName)
                    .ToList();

                var removeTown = db.Towns
                    .Where(x => x.Name == townName)
                    .First();

                db.Addresses.RemoveRange(removeAddress);
                db.Towns.Remove(removeTown);

                db.SaveChanges();
                Console.WriteLine($"{addCount} {(addCount == 1? "address":"addresses")} in {townName} {(addCount == 1?"was":"were")} deleted");
            }
        }
    }
}
