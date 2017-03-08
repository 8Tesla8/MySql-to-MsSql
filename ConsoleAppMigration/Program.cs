using ConsoleAppMigration.CodeFirstForAspIdentity.Migration;
using System;

namespace ConsoleAppMigration
{
    class Program
    {
        static void Main(string[] args)
        {
            //using (ApplicationDbContext newDb = new ApplicationDbContext())
            //{
            //    var cities = newDb.Sites.Where(s => s.language.id == 1);
            //    foreach (var item in cities)
            //    {
            //        Console.WriteLine(item.title);
            //    }
            //}

            AdoNetMigration migration = new AdoNetMigration();
            migration.FullMigration();
            //migration.MigrationMainSite();
            //migration.CountRowsInNewDb();


            Console.WriteLine("Press Any Key");
            Console.ReadKey();
        }
    }
}
