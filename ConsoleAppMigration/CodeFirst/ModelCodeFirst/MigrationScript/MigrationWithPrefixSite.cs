namespace ConsoleAppMigration.CodeFirst.ModelCodeFirst.MigrationScript
{
    public class MigrationWithPrefixSite
    {
        public MigrationWithPrefixSite()
        {

        }

        //языки в моей базе
        //List<Language> lang = new List<Language>
        //{
        //    new Language { title="English" },
        //    new Language { title="Russian" },
        //    new Language { title="Ukrainian" }
        //};
        //Языки в базе с префиксом site
        //1 ru
        //2 ua
        //3 en

        //TODO сделать сайты сначала


        //public void SiteCategory()
        //{
        //    List<site_category> siteCategory = null;
        //    using (uspaEntities oldDb = new uspaEntities())
        //    {
        //        siteCategory = oldDb.site_category.ToList();
        //    }

        //    int countChanges = -1;
        //    using (UspaDbContextEntity newDb = new UspaDbContextEntity())
        //    {
        //        //смигрировать языки
        //        var langFromNewDb = newDb.Languages.ToList(); 

        //        foreach (var item in siteCategory)
        //        {
        //            Category cat = new Category
        //            {
        //                previd = item.id,
        //                //siteId -----??????????
        //                title = item.title,
        //            };

        //            if(item.lan == 1)
        //            {
        //               cat.language = langFromNewDb[2];
        //            }
        //            else if (item.lan == 2)
        //            {
        //                cat.language = langFromNewDb[3];
        //            }
        //            else if (item.lan == 3)
        //            {
        //                cat.language = langFromNewDb[1];
        //            }

        //            newDb.Categories.Add(cat);

        //        }
        //        countChanges = newDb.SaveChanges();
        //        Console.WriteLine("Banners migration| rows=" + countChanges);
        //    }
        //}

    }
}
