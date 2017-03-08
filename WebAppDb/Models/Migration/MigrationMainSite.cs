namespace WebAppDb.Models.Migration
{
    //public class MigrationMainSite
    //{
    //    public MigrationMainSite()
    //    {
    //        int lang = LanguageMigration();//не ставить коментарий

    //        int site = SiteMigration(); //+
    //        int ban = BannerMigration(); //+

    //        int usGr = UserGroupMigration();//+
    //        int us = UserMigration();//+

    //        int mt = MenuTypeMigration();//+
    //        int menu = MenuMigration();//+ -
    //        int mToM = MenuToMenuMigration();//+

    //        int alb = AlbumMigration();//+
    //        int img = ImageMigration();//+

    //        int cat = CategoryMigration();//+
    //        int cont = ContentMigration();//+
    //    }

    //    public int LanguageMigration() //1
    //    {

    //        List<Language> lang = new List<Language>
    //        {
    //            new Language { title="English" },
    //            new Language { title="Russian" },
    //            new Language { title="Ukrainian" }
    //        };

    //        int countChanges = -1;
    //        using (ApplicationDbContext newDb = new ApplicationDbContext())
    //        {
    //            //newDb.Languages.AddRange(lang);
    //            foreach (var item in lang)
    //            {
    //                newDb.Languages.Add(item);
    //            }
    //            countChanges = newDb.SaveChanges();
    //        }

    //        return countChanges;
    //    }

    //    public int SiteMigration()
    //    {
    //        int countChanges = -1;
    //        using (ApplicationDbContext newDb = new ApplicationDbContext())
    //        {
    //            var langFromNewDb = newDb.Languages.ToList();

    //            List<Site> sites = new List<Site>{
    //                new Site { title="Главный сайт", language = langFromNewDb[1]},   //1 risuian
    //                new Site { title="Main site", language = langFromNewDb[0]},     //0 English
    //                new Site { title="Головний сайт", language = langFromNewDb[2]},  //2 ukranian

    //                new Site { title="Белгород-Днестровск", language = langFromNewDb[1]},   //1 risuian
    //                new Site { title="Belgorod-Dniester", language = langFromNewDb[0]},     //0 English
    //                new Site { title="Білгород-Дністровськ", language = langFromNewDb[2]},  //2 ukranian

    //                new Site { title="Бердянск", language = langFromNewDb[1]},
    //                new Site { title="Berdyansk", language = langFromNewDb[0]},
    //                new Site { title="Бердянськ", language = langFromNewDb[2]},

    //                new Site { title="Дельта-лоцман", language = langFromNewDb[1]},
    //                new Site { title="Delta-Pilot", language = langFromNewDb[0]},
    //                new Site { title="Дельта-лоцман", language = langFromNewDb[2]},

    //                new Site { title="Измаил", language = langFromNewDb[1]},
    //                new Site { title="Ishmael", language = langFromNewDb[0]},
    //                new Site { title="Ізмаїл", language = langFromNewDb[2]},

    //                new Site { title="Ильичевск", language = langFromNewDb[1]},
    //                new Site { title="Ilyichevsk", language = langFromNewDb[0]},
    //                new Site { title="Іллічівськ", language = langFromNewDb[2]},

    //                new Site { title="Мариуполь", language = langFromNewDb[1]},
    //                new Site { title="Mariupol", language = langFromNewDb[0]},
    //                new Site { title="Маріуполь", language = langFromNewDb[2]},

    //                new Site { title="Николаев", language = langFromNewDb[1]},
    //                new Site { title="Nikolaev", language = langFromNewDb[0]},
    //                new Site { title="Миколаїв", language = langFromNewDb[2]},

    //                new Site { title="Одесса", language = langFromNewDb[1]},
    //                new Site { title="Odessa", language = langFromNewDb[0]},
    //                new Site { title="Одеса", language = langFromNewDb[2]},

    //                new Site { title="Октябрьск", language = langFromNewDb[1]},
    //                new Site { title="Oktyabrsk", language = langFromNewDb[0]},
    //                new Site { title="Октябрьск", language = langFromNewDb[2]},

    //                new Site { title="Рени", language = langFromNewDb[1]},
    //                new Site { title="Reni", language = langFromNewDb[0]},
    //                new Site { title="Рені", language = langFromNewDb[2]},

    //                new Site { title="Скадовск", language = langFromNewDb[1]},
    //                new Site { title="Skadovsk", language = langFromNewDb[0]},
    //                new Site { title="Скадовськ", language = langFromNewDb[2]},

    //                new Site { title="Усть-Дунайск", language = langFromNewDb[1]},
    //                new Site { title="Ust-Danube", language = langFromNewDb[0]},
    //                new Site { title="Усть-Дунайськ", language = langFromNewDb[2]},

    //                new Site { title="Херсон", language = langFromNewDb[1]},
    //                new Site { title="Herson", language = langFromNewDb[0]},
    //                new Site { title="Херсон", language = langFromNewDb[2]},

    //                new Site { title="Южный", language = langFromNewDb[1]},
    //                new Site { title="Yuznyi", language = langFromNewDb[0]},
    //                new Site { title="Южний", language = langFromNewDb[2]},
    //            };
    //            //45
    //            //newDb.Sites.AddRange(sites);
    //            foreach (var item in sites)
    //            {
    //                newDb.Sites.Add(item);
    //            }

    //            countChanges = newDb.SaveChanges();
    //        }
    //        return countChanges;
    //    }

    //    public int BannerMigration()//3 
    //    {
    //        List<ampu_banners> oldBanners = null;
    //        using (oldUspaEntities oldDb = new oldUspaEntities())
    //        {
    //            oldBanners = oldDb.ampu_banners.ToList();
    //        }

    //        int countChanges = -1;
    //        using (UspaDbContextEntity newDb = new UspaDbContextEntity())
    //        {
    //            var siteFromNewDb = newDb.Sites.ToList();

    //            var langFromNewDb = newDb.Languages.ToList();

    //            foreach (var item in oldBanners)
    //            {
    //                Banner ban = new Banner
    //                {
    //                    title = item.name,
    //                    url = item.clickurl,
    //                    state = (item.state > 0) ? true : false,
    //                };


    //                newDb.Banners.Add(ban);
    //            }

    //            countChanges = newDb.SaveChanges();
    //            Console.WriteLine("Banners migration| rows=" + countChanges);
    //        }
    //        return countChanges;
    //    }
    //}
}