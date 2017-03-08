using ConsoleAppMigration.CodeFirstForAspIdentity.DbModel;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;

namespace ConsoleAppMigration.CodeFirstForAspIdentity.Migration
{
    public class AdoNetMigration
    {
        MySqlConnectionStringBuilder conn_string;

        public AdoNetMigration()
        {
            conn_string = new MySqlConnectionStringBuilder();
            conn_string.Server = "127.0.0.1";
            conn_string.UserID = "root";
            //conn_string.Password = "a455555_me";
            conn_string.Database = "uspa";
            conn_string.AllowZeroDateTime = true;
            conn_string.ConvertZeroDateTime = true;

        }

        public void FullMigration()
        {
            //it must be
            LanguageMigration();//не ставить коментарий
            SiteMigration();

            RoleMigration();
            MenuTypeMigration();
            //+++


            MigrationOtherSitesMigration();

            CountRowsInNewDb();
            ClearPrevId();

            MigrationMainSite();


            CountRowsInNewDb();
        }
        #region MainSiteMigration 
        public void MigrationMainSite()
        {
            BannerMigration();

            //RoleMigration();
            UserMigration();
            SetUsersRole();

            //MenuTypeMigration();
            MenuMigration();
            MenuToMenuMigration();

            AlbumMigration();
            ImageMigration();

            CategoryMigration();
            ContentMigration();
        }

        public void CountRowsInNewDb()
        {
            Console.WriteLine();

            using (ApplicationDbContext newDb = new ApplicationDbContext())
            {
                int lang = newDb.Languages.ToList().Count;
                int st = newDb.Sites.ToList().Count;
                int bnr = newDb.Banners.ToList().Count;
                int rl = newDb.Roles.ToList().Count;
                int us = newDb.Users.ToList().Count;
                int mt = newDb.MenuType.ToList().Count;
                int m = newDb.Menu.ToList().Count;
                int mm = newDb.Menu.Where(x => x.parentid != null).ToList().Count;
                int alb = newDb.Albums.ToList().Count;
                int img = newDb.Images.ToList().Count;
                int ctg = newDb.Categories.ToList().Count;
                int ctn = newDb.Contents.ToList().Count;

                //++++++++++++++++++++++++++++++++++++++++++++++
                Console.WriteLine("languages rows = " + lang);
                Console.WriteLine("sites rows = " + st);
                Console.WriteLine("banners rows = " + bnr);
                Console.WriteLine("roles rows = " + rl);
                Console.WriteLine("users rows = " + us);
                Console.WriteLine("menuTypes rows = " + mt);
                Console.WriteLine("menus rows = " + m);
                Console.WriteLine("menu to menu rows = " + mm);
                Console.WriteLine("albums rows = " + alb);
                Console.WriteLine("images rows = " + img);
                Console.WriteLine("categories rows = " + ctg);
                Console.WriteLine("contents rows = " + ctn);

                //in main site
                //3
                //45
                //16
                //14
                //299 + 1 testUser
                //7
                //630
                //629
                //136 
                //3370
                //320
                //16390 || 14430

                //in other site
                //3 lang 
                //45 sites  
                //0 banners 
                //14 roles 
                //23 users 
                //7 meny types
                //70 meny 
                //41 meny to meny
                //0 albums
                //0 images
                //122 categories
                //675 content

                //both
                //3 lang
                //45 sites
                //16 banners
                //14 roles
                //323 users
                //7 meny types
                //700 meny
                //meny to meny
                //136 albums
                //3370 images
                //442 categories
                //15118 contents

            }
        }

        int LanguageMigration() //1
        {

            List<Language> lang = new List<Language>
            {
                new Language { title="English" },
                new Language { title="Russian" },
                new Language { title="Ukrainian" }
            };

            int countChanges = -1;
            using (ApplicationDbContext newDb = new ApplicationDbContext())
            {
                //newDb.Languages.AddRange(lang);
                foreach (var item in lang)
                {
                    newDb.Languages.Add(item);
                }
                countChanges = newDb.SaveChanges();
                Console.WriteLine("Language migration| rows=" + countChanges);
            }

            return countChanges;
        }

        int SiteMigration() //2
        {
            int countChanges = -1;
            using (ApplicationDbContext newDb = new ApplicationDbContext())
            {
                var langFromNewDb = newDb.Languages.ToList();

                List<Site> sites = new List<Site>{
                    new Site { title="Главный сайт", language = langFromNewDb[1]},   //1 risuian
                    new Site { title="Main site", language = langFromNewDb[0]},     //0 English
                    new Site { title="Головний сайт", language = langFromNewDb[2]},  //2 ukranian

                    new Site { title="Белгород-Днестровск", language = langFromNewDb[1]},   //1 risuian
                    new Site { title="Belgorod-Dniester", language = langFromNewDb[0]},     //0 English
                    new Site { title="Білгород-Дністровськ", language = langFromNewDb[2]},  //2 ukranian

                    new Site { title="Бердянск", language = langFromNewDb[1]},
                    new Site { title="Berdyansk", language = langFromNewDb[0]},
                    new Site { title="Бердянськ", language = langFromNewDb[2]},

                    new Site { title="Дельта-лоцман", language = langFromNewDb[1]},
                    new Site { title="Delta-Pilot", language = langFromNewDb[0]},
                    new Site { title="Дельта-лоцман", language = langFromNewDb[2]},

                    new Site { title="Измаил", language = langFromNewDb[1]},
                    new Site { title="Ishmael", language = langFromNewDb[0]},
                    new Site { title="Ізмаїл", language = langFromNewDb[2]},

                    new Site { title="Ильичевск", language = langFromNewDb[1]},
                    new Site { title="Ilyichevsk", language = langFromNewDb[0]},
                    new Site { title="Іллічівськ", language = langFromNewDb[2]},

                    new Site { title="Мариуполь", language = langFromNewDb[1]},
                    new Site { title="Mariupol", language = langFromNewDb[0]},
                    new Site { title="Маріуполь", language = langFromNewDb[2]},

                    new Site { title="Николаев", language = langFromNewDb[1]},
                    new Site { title="Nikolaev", language = langFromNewDb[0]},
                    new Site { title="Миколаїв", language = langFromNewDb[2]},

                    new Site { title="Одесса", language = langFromNewDb[1]},
                    new Site { title="Odessa", language = langFromNewDb[0]},
                    new Site { title="Одеса", language = langFromNewDb[2]},

                    new Site { title="Октябрьск", language = langFromNewDb[1]},
                    new Site { title="Oktyabrsk", language = langFromNewDb[0]},
                    new Site { title="Октябрьск", language = langFromNewDb[2]},

                    new Site { title="Рени", language = langFromNewDb[1]},
                    new Site { title="Reni", language = langFromNewDb[0]},
                    new Site { title="Рені", language = langFromNewDb[2]},

                    new Site { title="Скадовск", language = langFromNewDb[1]},
                    new Site { title="Skadovsk", language = langFromNewDb[0]},
                    new Site { title="Скадовськ", language = langFromNewDb[2]},

                    new Site { title="Усть-Дунайск", language = langFromNewDb[1]},
                    new Site { title="Ust-Danube", language = langFromNewDb[0]},
                    new Site { title="Усть-Дунайськ", language = langFromNewDb[2]},

                    new Site { title="Херсон", language = langFromNewDb[1]},
                    new Site { title="Herson", language = langFromNewDb[0]},
                    new Site { title="Херсон", language = langFromNewDb[2]},

                    new Site { title="Южный", language = langFromNewDb[1]},
                    new Site { title="Yuznyi", language = langFromNewDb[0]},
                    new Site { title="Южний", language = langFromNewDb[2]},
                };
                //45
                //newDb.Sites.AddRange(sites);
                foreach (var item in sites)
                {
                    newDb.Sites.Add(item);
                }

                countChanges = newDb.SaveChanges();
                Console.WriteLine("Sites migration| rows=" + countChanges);
            }
            return countChanges;
        }

        void BannerMigration() //3
        {
            using (ApplicationDbContext newDb = new ApplicationDbContext())
            {
                Site mainSite = newDb.Sites.FirstOrDefault(s => s.title.Equals("Главный сайт"));

                List<Banner> banners = new List<Banner>();


                using (MySqlConnection connect = new MySqlConnection(conn_string.ToString()))
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    string commandLine = "SELECT name, clickurl, state FROM ampu_banners";
                    cmd.CommandText = commandLine;

                    cmd.Connection = connect;
                    cmd.Connection.Open();

                    using (MySqlDataReader msdr = cmd.ExecuteReader())
                    {
                        while (msdr.Read())
                        {
                            String name = msdr.GetString(0);
                            String clickurl = msdr.GetString(1);
                            String state = msdr.GetString(2);

                            Banner ban = new Banner
                            {
                                title = name,
                                url = clickurl,
                                site = mainSite,
                                state = (Int32.Parse(state) > 0) ? true : false,
                            };

                            banners.Add(ban);
                        }

                        //do stuff.....
                    } // <- here the DataReader is closed and disposed.
                }



                newDb.Banners.AddRange(banners);

                int countChanges = newDb.SaveChanges();
                Console.WriteLine("Banners migration| rows=" + countChanges);
            }
        }

        Dictionary<int, string> prevRoles = new Dictionary<int, string>();
        void RoleMigration() //4
        {
            List<Role> roles = new List<Role>();

            using (MySqlConnection connect = new MySqlConnection(conn_string.ToString()))
            using (MySqlCommand cmd = new MySqlCommand())
            {
                string commandLine = "SELECT title, id FROM ampu_usergroups";
                cmd.CommandText = commandLine;

                cmd.Connection = connect;
                cmd.Connection.Open();

                using (MySqlDataReader msdr = cmd.ExecuteReader())
                {
                    while (msdr.Read())
                    {
                        //string name = Encoding.UTF8.GetString(Encoding.Default.GetBytes(msdr.GetString(0)));
                        string name = msdr.GetString(0);


                        prevRoles.Add(Int32.Parse(msdr.GetString(1)), name);

                        roles.Add(new Role
                        {
                            Name = name,
                        });
                    }

                    //do stuff.....
                } // <- here the DataReader is closed and disposed.
            }

            using (ApplicationDbContext newDb = new ApplicationDbContext())
            {
                var RoleManager = new RoleManager<Role>(new RoleStore<Role>(newDb));


                foreach (var item in roles)
                {
                    //var roleResult = RoleManager.Create(new Role { Name = item.Name });
                    newDb.Roles.Add(new Role { Name = item.Name });
                }
                int countChanges = newDb.SaveChanges();
                Console.WriteLine("Role migration| rows=" + countChanges);
            }
        }
        void UserMigration() //5
        {
            List<User> users = new List<User>();

            using (MySqlConnection connect = new MySqlConnection(conn_string.ToString()))
            using (MySqlCommand cmd = new MySqlCommand())
            {
                string commandLine = "SELECT name, username, email, block, registerDate, lastvisitDate, id   FROM ampu_users";
                cmd.CommandText = commandLine;

                cmd.Connection = connect;
                cmd.Connection.Open();

                using (MySqlDataReader msdr = cmd.ExecuteReader())
                {
                    while (msdr.Read())
                    {
                        DateTime? register = (msdr.GetDateTime(4) >= (DateTime)SqlDateTime.MinValue)
                            ? msdr.GetDateTime(4) : (DateTime?)null;
                        DateTime? lastVisit = (msdr.GetDateTime(5) >= (DateTime)SqlDateTime.MinValue)
                            ? msdr.GetDateTime(5) : (DateTime?)null;


                        User newUser = new User
                        {
                            name = msdr.GetString(0), //Encoding.UTF8.GetString(Encoding.Default.GetBytes(msdr.GetString(0))),
                            UserName = msdr.GetString(1), //Encoding.UTF8.GetString(Encoding.Default.GetBytes(msdr.GetString(1))),
                            Email = msdr.GetString(2), //Encoding.UTF8.GetString(Encoding.Default.GetBytes(msdr.GetString(2))),
                            //password = item.password,
                            block = (Int32.Parse(msdr.GetString(3)) > 0) ? true : false,
                            registerDate = register,//(item.registerDate >= (DateTime)SqlDateTime.MinValue) ? item.registerDate : (DateTime?)null,
                            lastVisitDate = lastVisit,
                            prevId = Int32.Parse(msdr.GetString(6)),
                        };

                        users.Add(newUser);
                    }

                    //do stuff.....
                } // <- here the DataReader is closed and disposed.
            }

            using (ApplicationDbContext newDb = new ApplicationDbContext())
            {
                //user fo tests
                User testUser = new User
                {
                    name = "testUser",
                    UserName = "testNick",
                    Email = "test@gmail.com",
                };
                newDb.Users.Add(testUser);

                foreach (var item in users)
                {
                    newDb.Users.Add(item);
                }
                int countChanges = newDb.SaveChanges();
                Console.WriteLine("users migration| rows=" + countChanges);
            }
        }
        void SetUsersRole()
        {
            List<Point> mapUserIdGroupId = new List<Point>();


            using (MySqlConnection connect = new MySqlConnection(conn_string.ToString()))
            using (MySqlCommand cmd = new MySqlCommand())
            {
                string commandLine = "SELECT * FROM ampu_user_usergroup_map";
                cmd.CommandText = commandLine;

                cmd.Connection = connect;
                cmd.Connection.Open();

                using (MySqlDataReader msdr = cmd.ExecuteReader())
                {
                    while (msdr.Read())
                    {
                        Point p = new Point
                        {
                            X = Int32.Parse(msdr.GetString(0)), //userId
                            Y = Int32.Parse(msdr.GetString(1)), //groupId
                        };

                        mapUserIdGroupId.Add(p);
                    }

                    //do stuff.....
                } // <- here the DataReader is closed and disposed.
            }

            using (ApplicationDbContext newDb = new ApplicationDbContext())
            {
                //var UserManager = new UserManager<IdentityUser>(new UserStore<IdentityUser>(newDb));
                var UserManager = new UserManager<User>(new UserStore<User>(newDb));

                var roles = newDb.Roles.ToList();
                var users = newDb.Users.ToList();

                for (int i = 0; i < users.Count; i++)
                {
                    var currentUserMap = mapUserIdGroupId
                        .FirstOrDefault(m => m.X == users[i].prevId);

                    var prevRole = prevRoles
                        .FirstOrDefault(r => r.Key == currentUserMap.Y);

                    var currentRole = roles
                        .FirstOrDefault(r => r.Name.Equals(prevRole.Value));

                    //users[i].Roles.Add(currentRole.Name);
                    if (currentRole != null)
                        UserManager.AddToRole(users[i].Id, currentRole.Name);
                }

                int countChanges = newDb.SaveChanges();
                Console.WriteLine("set roles to users migration| rows=" + countChanges);
            }
        }

        void MenuTypeMigration()//6 
        {
            List<MenuType> typeMenu = new List<MenuType>
            {
                new MenuType { title = "Main menu" },
                new MenuType { title = "Top menu" },
                new MenuType { title = "Additional right menu" },
                new MenuType { title = "Right menu" },
                new MenuType { title = "Bottom menu" },
                new MenuType { title = "Hidden menu" },
                new MenuType { title = "Kunena menu" }, //чат
            };


            int countChanges = -1;
            using (ApplicationDbContext newDb = new ApplicationDbContext())
            {
                //newDb.MenuType.AddRange(typeMenu);
                foreach (var item in typeMenu)
                {
                    newDb.MenuType.Add(item);
                }

                countChanges = newDb.SaveChanges();
            }
            Console.WriteLine("Meny type migration| rows=" + countChanges);
        }
        void MenuMigration()
        {
            using (ApplicationDbContext newDb = new ApplicationDbContext())
            {
                List<Menu> newMenus = new List<Menu>();
                List<string> listOfMenuType = new List<string>();


                var siteFromNewDb = newDb.Sites.ToList();
                var newMenuType = newDb.MenuType.ToList();

                //делаю простой список меню типов меню, записываю только тип
                foreach (var item in newMenuType)
                {
                    string title = item.title;

                    var addedItem = title.Replace(" menu", "");
                    if (addedItem.Contains(" right"))
                    {
                        addedItem = addedItem.Replace(" right", "");
                    }
                    string typeMenu = addedItem.ToLower();
                    listOfMenuType.Add(typeMenu);
                }


                using (MySqlConnection connect = new MySqlConnection(conn_string.ToString()))
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    string commandLine = "SELECT id, title, published, parent_id, language, menutype  FROM ampu_menu";
                    cmd.CommandText = commandLine;

                    cmd.Connection = connect;
                    cmd.Connection.Open();

                    using (MySqlDataReader msdr = cmd.ExecuteReader())
                    {
                        while (msdr.Read())
                        {
                            Menu menu = new Menu
                            {
                                previd = Int32.Parse(msdr.GetString(0)),
                                title = msdr.GetString(1),
                                state = (Int32.Parse(msdr.GetString(2)) > 0) ? true : false,
                                parentidPrev = Int32.Parse(msdr.GetString(3)),
                            };

                            string lang = msdr.GetString(4);

                            //вибор на каком сайте меню, в зависимости от языка
                            if (lang.Contains("ru")) //1
                            {
                                menu.site = siteFromNewDb[1];
                            }
                            else if (lang.Contains("uk")) //2
                            {
                                menu.site = siteFromNewDb[2];
                            }
                            else if (lang.Contains("en")) //0
                            {
                                menu.site = siteFromNewDb[0];
                            }
                            else
                            {
                                menu.site = null;
                            }


                            string menuType = msdr.GetString(5);

                            //для типо с название просто menu
                            if (menuType.Equals("menu"))
                            {
                                menu.menuType = newMenuType[0];//main menu
                            }
                            //ищю нужний тип сравнивая строки
                            else
                            {
                                int index = -1;
                                int count = 0;

                                foreach (var comparItem in listOfMenuType)
                                {
                                    if (menuType.Contains(comparItem))
                                    {
                                        index = count;
                                        //Console.WriteLine("FOUND ={0} | INDEX={1}", comparItem, index);
                                        break;
                                    }
                                    count++;
                                }

                                if (index != -1)
                                {
                                    menu.menuType = newMenuType[index];
                                }
                            }

                            newMenus.Add(menu);
                        }
                        //do stuff.....
                    } // <- here the DataReader is closed and disposed.


                    newDb.Menu.AddRange(newMenus);

                    int countChanges = newDb.SaveChanges();
                    Console.WriteLine("Meny migration| rows=" + countChanges);
                }





                //using (ApplicationDbContext newDb = new ApplicationDbContext())
                //{
                //    newDb.Menu.AddRange(newMenus);
                //    int countChanges = newDb.SaveChanges();
                //    Console.WriteLine("Meny migration| rows=" + countChanges);
                //}
            }
        }
        void MenuToMenuMigration()
        {
            using (ApplicationDbContext newDb = new ApplicationDbContext())
            {
                var menu = newDb.Menu.ToList();

                for (int i = 0; i < menu.Count; i++)
                {
                    Menu parentMenu = null;
                    if (menu[i].parentidPrev > 0)
                        parentMenu = menu.FirstOrDefault(m => m.previd == menu[i].parentidPrev);
                    //parentMenu.menu.Add(menu[i]);
                    if (parentMenu != null)
                        menu[i].parentid = parentMenu.id;
                }

                //foreach(var item in menu)
                //{
                //    Menu parentMenu = menu.FirstOrDefault(m => m.previd == item.parentidPrev);
                //    parentMenu.parent = item;
                //}
                int countChanges = newDb.SaveChanges();
                Console.WriteLine("MenyToMenu migration| rows=" + countChanges);
            }
        }

        //8 ampu_phocagallery_categories
        void AlbumMigration()
        {
            using (ApplicationDbContext newDb = new ApplicationDbContext())
            {
                List<Album> albums = new List<Album>();
                var langFromNewDb = newDb.Languages.ToList();


                using (MySqlConnection connect = new MySqlConnection(conn_string.ToString()))
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    string commandLine = "SELECT id, title, date, language  FROM ampu_phocagallery_categories";
                    cmd.CommandText = commandLine;

                    cmd.Connection = connect;
                    cmd.Connection.Open();

                    using (MySqlDataReader msdr = cmd.ExecuteReader())
                    {
                        while (msdr.Read())
                        {
                            DateTime? date = (msdr.GetDateTime(2) >= (DateTime)SqlDateTime.MinValue)
                                ? msdr.GetDateTime(2) : (DateTime?)null;
                            string lang = msdr.GetString(3);


                            Album album = new Album
                            {
                                title = msdr.GetString(1),
                                previd = Int32.Parse(msdr.GetString(0)),
                                created = date,
                            };

                            if (lang.Contains("ru")) //1
                            {
                                album.language = langFromNewDb[1];
                            }
                            else if (lang.Contains("uk")) //2
                            {
                                album.language = langFromNewDb[2];
                            }
                            else if (lang.Contains("en")) //0
                            {
                                album.language = langFromNewDb[0];
                            }
                            else
                            {
                                album.language = null;
                            }

                            albums.Add(album);
                        }
                        //do stuff.....
                    } // <- here the DataReader is closed and disposed.
                }

                newDb.Albums.AddRange(albums);

                int countChanges = newDb.SaveChanges();
                Console.WriteLine("Album migration| rows=" + countChanges);
            }
        }

        Object lockMe = new Object();

        //9 ampu_phocagallery
        void ImageMigration()
        {
            using (ApplicationDbContext newDb = new ApplicationDbContext())
            {
                var album = newDb.Albums.ToList();



                using (MySqlConnection connect = new MySqlConnection(conn_string.ToString()))
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    string commandLine = "SELECT title, filename, date, published, catid  FROM ampu_phocagallery";
                    cmd.CommandText = commandLine;

                    cmd.Connection = connect;
                    cmd.Connection.Open();

                    using (MySqlDataReader msdr = cmd.ExecuteReader())
                    {
                        while (msdr.Read())
                        {
                            string stringOfState = msdr.GetString(3);
                            bool state = false;
                            if (stringOfState != null)
                                state = bool.Parse(stringOfState);


                            DbModel.Image image = new DbModel.Image
                            {
                                title = msdr.GetString(0),
                                filePath = msdr.GetString(1),
                                state = state, //(Int32.Parse(msdr.GetString(3)) > 0) ? true : false,
                                created = (msdr.GetDateTime(2) >= (DateTime)SqlDateTime.MinValue)
                                    ? msdr.GetDateTime(2) : (DateTime?)null,
                            };

                            int albumId = Int32.Parse(msdr.GetString(4));


                            var neededAlbum = album.FirstOrDefault(a => a.previd == albumId);
                            image.album = neededAlbum;


                            newDb.Images.Add(image);
                        }
                        //do stuff.....
                    } // <- here the DataReader is closed and disposed.
                }

                int countChanges = newDb.SaveChanges();
                Console.WriteLine("Image migration| rows=" + countChanges);
            }
        }


        void CategoryMigration()
        {
            using (ApplicationDbContext newDb = new ApplicationDbContext())
            {
                var langFromNewDb = newDb.Languages.ToList();
                var usersFromNewDb = newDb.Users.ToList();


                using (MySqlConnection connect = new MySqlConnection(conn_string.ToString()))
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    string commandLine = "SELECT title, created_time, published, id, language, created_user_id  FROM ampu_categories";
                    cmd.CommandText = commandLine;

                    cmd.Connection = connect;
                    cmd.Connection.Open();

                    using (MySqlDataReader msdr = cmd.ExecuteReader())
                    {
                        while (msdr.Read())
                        {
                            string stringOfState = msdr.GetString(2);
                            bool state = false;
                            if (stringOfState != null)
                                state = bool.Parse(stringOfState);

                            Category category = new Category
                            {
                                title = msdr.GetString(0),
                                createdTime = (msdr.GetDateTime(1) >= (DateTime)SqlDateTime.MinValue)
                                    ? msdr.GetDateTime(1) : (DateTime?)null,
                                published = state,
                                previd = Int32.Parse(msdr.GetString(3)),
                            };

                            string lang = msdr.GetString(4);


                            if (lang.Contains("ru")) //1
                            {
                                category.language = langFromNewDb[1];
                            }
                            else if (lang.Contains("uk")) //2
                            {
                                category.language = langFromNewDb[2];
                            }
                            else if (lang.Contains("en")) //0
                            {
                                category.language = langFromNewDb[0];
                            }
                            else
                            {
                                category.language = null;
                            }

                            int createdUserId = Int32.Parse(msdr.GetString(5));

                            category.createdByUser = usersFromNewDb.
                                                FirstOrDefault(u => createdUserId == u.prevId);

                            newDb.Categories.Add(category);
                        }
                        //do stuff.....
                    } // <- here the DataReader is closed and disposed.
                }


                int countChanges = newDb.SaveChanges();
                Console.WriteLine("Category migration| rows=" + countChanges);
            }
        }

        void ContentMigration()
        {
            using (ApplicationDbContext newDb = new ApplicationDbContext())
            {
                var siteFromNewDb = newDb.Sites.ToList();
                var categories = newDb.Categories.ToList();
                var users = newDb.Users.ToList();


                using (MySqlConnection connect = new MySqlConnection(conn_string.ToString()))
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    string commandLine = "SELECT title, introtext, `fulltext`, state, created, modified, publish_up, publish_down, catid, created_by, modified_by, language, id  FROM ampu_content";
                    cmd.CommandText = commandLine;

                    cmd.Connection = connect;
                    cmd.Connection.Open();

                    using (MySqlDataReader msdr = cmd.ExecuteReader())
                    {
                        int iteration = 0;

                        while (msdr.Read())
                        {
                            Content content = new Content
                            {
                                title = msdr.GetString(0),
                                introtext = msdr.GetString(1),
                                fulltext = msdr.GetString(2),
                                state = (Int32.Parse(msdr.GetString(3)) > 0) ? true : false,
                                created = (msdr.GetDateTime(4) >= (DateTime)SqlDateTime.MinValue)
                                    ? msdr.GetDateTime(4) : (DateTime?)null,
                                modified = (msdr.GetDateTime(5) >= (DateTime)SqlDateTime.MinValue)
                                    ? msdr.GetDateTime(5) : (DateTime?)null,
                                checkIn = (msdr.GetDateTime(6) >= (DateTime)SqlDateTime.MinValue)
                                    ? msdr.GetDateTime(6) : (DateTime?)null,
                                checkOut = (msdr.GetDateTime(7) >= (DateTime)SqlDateTime.MinValue)
                                    ? msdr.GetDateTime(7) : (DateTime?)null,
                                previd = Int32.Parse(msdr.GetString(12)),
                            };

                            int catId = Int32.Parse(msdr.GetString(8));
                            content.category = categories.FirstOrDefault(c => c.previd == catId);

                            int creatdBy = Int32.Parse(msdr.GetString(9));
                            if (creatdBy != 0)
                                content.createdByUser = users.FirstOrDefault(u => u.prevId == creatdBy);

                            int modifiedBy = Int32.Parse(msdr.GetString(10));
                            if (modifiedBy != 0)
                                content.modifiedByUser = users.FirstOrDefault(u => u.prevId == modifiedBy);

                            string lang = msdr.GetString(11);


                            if (lang.Contains("ru")) //1
                            {
                                content.site = siteFromNewDb[1];
                            }
                            else if (lang.Contains("uk")) //2
                            {
                                content.site = siteFromNewDb[2];
                            }
                            else if (lang.Contains("en")) //0
                            {
                                content.site = siteFromNewDb[0];
                            }
                            else
                            {
                                content.site = null;
                            }


                            newDb.Contents.Add(content);

                            iteration++;
                            Console.Write(iteration + " ");
                        }
                        //do stuff.....
                    } // <- here the DataReader is closed and disposed.
                }


                int countChanges = newDb.SaveChanges();
                Console.WriteLine("Content migration| rows=" + countChanges);
            }
        }
        #endregion

        #region OtherSitySitesMigration
        public void MigrationOtherSitesMigration()
        {
            SiteMigrationFromSite();


            //those users is already exist in db
            //UserMigrationFromSite();

            //сначала сделать миграцию site_category потом site_content потом site_menu
            CategoryMigrationFromSite();
            ContentMigrationFromSite();
            MenuMigrationFromSite();
            MenuToMenuMigrationFromSite();
        }

        //site_config
        List<int> sitesWhichNoNeedToMigrate = new List<int>();
        void SiteMigrationFromSite()
        {
            //1 - odesssa 
            //2 - bgd belgorod
            //3 - brd berdansk
            //4 - dlt delta-pilot
            //6 - izm izmail
            //7 - ilk ilichevsk
            //9 - mpv mariupol
            //10 - nik nikalaev
            //11 - okt oktabersk
            //12 - rni reni
            //14 - skd - skadovsk
            //15 - udy usd dunaisk
            //17 - herson
            //18 - uznie


            //site which does not exist in base
            //0 - admin
            //5 -
            //8 -
            //13 - svp - sevastopol 
            //16 - 
            //19
            //21

            sitesWhichNoNeedToMigrate.Add(0);
            sitesWhichNoNeedToMigrate.Add(5);
            sitesWhichNoNeedToMigrate.Add(8);
            sitesWhichNoNeedToMigrate.Add(13);
            sitesWhichNoNeedToMigrate.Add(16);
            sitesWhichNoNeedToMigrate.Add(19);
            sitesWhichNoNeedToMigrate.Add(21);

        }

        void UserMigrationFromSite()
        {
            List<User> usersOld = new List<User>();

            using (MySqlConnection connect = new MySqlConnection(conn_string.ToString()))
            using (MySqlCommand cmd = new MySqlCommand())
            {
                string commandLine = "SELECT login FROM site_users";
                cmd.CommandText = commandLine;

                cmd.Connection = connect;
                cmd.Connection.Open();

                using (MySqlDataReader msdr = cmd.ExecuteReader())
                {
                    while (msdr.Read())
                    {
                        User newUser = new User
                        {
                            UserName = msdr.GetString(0),
                            block = false,
                        };

                        usersOld.Add(newUser);
                    }

                    //do stuff.....
                } // <- here the DataReader is closed and disposed.
            }


            using (ApplicationDbContext newDb = new ApplicationDbContext())
            {
                //insert old data
                foreach (var item in usersOld)
                {
                    newDb.Users.Add(item);
                }
                int countChanges = newDb.SaveChanges();
                Console.WriteLine("users migration from site| rows=" + countChanges);




                //set role
                var UserManager = new UserManager<User>(new UserStore<User>(newDb));

                var roles = newDb.Roles.ToList();
                var users = newDb.Users.ToList();

                for (int i = 0; i < users.Count; i++)
                {
                    var currentRole = roles
                        .FirstOrDefault(r => r.Name.Equals("Администраторы"));

                    //users[i].Roles.Add(currentRole.Name);
                    if (currentRole != null)
                        UserManager.AddToRole(users[i].Id, currentRole.Name);
                }
                newDb.SaveChanges();
                Console.WriteLine("set roles to users from site| rows=" + countChanges);
            }
        }

        void CategoryMigrationFromSite()
        {
            using (ApplicationDbContext newDb = new ApplicationDbContext())
            {
                var languages = newDb.Languages.ToList();

                List<Category> categories = new List<Category>();

                using (MySqlConnection connect = new MySqlConnection(conn_string.ToString()))
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    string commandLine = "SELECT id, lan, title FROM site_category";
                    cmd.CommandText = commandLine;

                    cmd.Connection = connect;
                    cmd.Connection.Open();

                    using (MySqlDataReader msdr = cmd.ExecuteReader())
                    {
                        while (msdr.Read())
                        {
                            int lang = Int32.Parse(msdr.GetString(1));


                            Category category = new Category()
                            {
                                previd = Int32.Parse(msdr.GetString(0)),
                                title = msdr.GetString(2),
                            };


                            if (lang == 1) //1
                            {
                                category.language = languages[1];
                            }
                            else if (lang == 2) //2
                            {
                                category.language = languages[2];
                            }
                            else if (lang == 3) //0
                            {
                                category.language = languages[0];
                            }
                            else
                            {
                                category.language = null;
                            }

                            categories.Add(category);
                        }
                        //do stuff.....
                    } // <- here the DataReader is closed and disposed.
                }


                newDb.Categories.AddRange(categories);
                int countChanges = newDb.SaveChanges();
                Console.WriteLine("categories migration from site | rows=" + countChanges);
            }
        }


        void ContentMigrationFromSite()
        {
            using (ApplicationDbContext newDb = new ApplicationDbContext())
            {
                var sitesFromNewDb = newDb.Sites.ToList();
                var categoriesFromNewDb = newDb.Categories.ToList();

                List<Content> contents = new List<Content>();

                using (MySqlConnection connect = new MySqlConnection(conn_string.ToString()))
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    string commandLine = "SELECT id, active, siteid, lan, cat_id, title, text, date FROM site_content";
                    cmd.CommandText = commandLine;

                    cmd.Connection = connect;
                    cmd.Connection.Open();

                    using (MySqlDataReader msdr = cmd.ExecuteReader())
                    {
                        while (msdr.Read())
                        {
                            int lang = Int32.Parse(msdr.GetString(3));
                            int site = Int32.Parse(msdr.GetString(2));
                            int catId = Int32.Parse(msdr.GetString(4));

                            //если сайт не входит в категорию которую не нужно копировать, копирую
                            //if (sitesWhichNoNeedToMigrate.Any(s => s == site))
                            if (!sitesWhichNoNeedToMigrate.Contains(site))
                            {
                                Content cont = new Content()
                                {
                                    introtext = msdr.GetString(5),
                                    fulltext = msdr.GetString(6),
                                    state = (Int32.Parse(msdr.GetString(1)) > 0) ? true : false,
                                    created = (msdr.GetDateTime(7) >= (DateTime)SqlDateTime.MinValue)
                                        ? msdr.GetDateTime(7) : (DateTime?)null,
                                    previd = Int32.Parse(msdr.GetString(0)),
                                };

                                cont.site = SiteDefenition(sitesFromNewDb, site, lang);
                                cont.category = categoriesFromNewDb.FirstOrDefault(c => c.previd == catId);

                                contents.Add(cont);
                            }
                        }
                        //do stuff.....
                    } // <- here the DataReader is closed and disposed.
                }


                newDb.Contents.AddRange(contents);
                int countChanges = newDb.SaveChanges();
                Console.WriteLine("Content migration from site | rows=" + countChanges);
            }
        }

        Site SiteDefenition(List<Site> sitesFromNewDb, int site, int lang)
        {
            Site siteObj = null;

            //in new db lang 1 - en, 2 - ru, 3 - ua
            //in old db lang 1 - ru, 2 - ua, 3 - en
            if (site == 1) //odessa
            {
                if (lang == 1) //ru
                {
                    siteObj = sitesFromNewDb.FirstOrDefault(s => s.title.Equals("Одесса"));
                }
                else if (lang == 2) //ua
                {
                    siteObj = sitesFromNewDb.FirstOrDefault(s => s.title.Equals("Одеса"));
                }
                else if (lang == 3) //en
                {
                    siteObj = sitesFromNewDb.FirstOrDefault(s => s.title.Equals("Odessa"));
                }
            }
            else if (site == 2) //belgorod
            {
                if (lang == 1) //ru
                {
                    siteObj = sitesFromNewDb.FirstOrDefault(s => s.title.Equals("Белгород-Днестровск"));
                }
                else if (lang == 2) //ua
                {
                    siteObj = sitesFromNewDb.FirstOrDefault(s => s.title.Equals("Білгород-Дністровськ"));
                }
                else if (lang == 3) //en
                {
                    siteObj = sitesFromNewDb.FirstOrDefault(s => s.title.Equals("Belgorod-Dniester"));
                }
            }
            else if (site == 3) //berdansk
            {
                if (lang == 1) //ru
                {
                    siteObj = sitesFromNewDb.FirstOrDefault(s => s.title.Equals("Бердянск"));
                }
                else if (lang == 2) //ua
                {
                    siteObj = sitesFromNewDb.FirstOrDefault(s => s.title.Equals("Бердянськ"));
                }
                else if (lang == 3) //en
                {
                    siteObj = sitesFromNewDb.FirstOrDefault(s => s.title.Equals("Berdyansk"));
                }
            }
            else if (site == 4) //delta-pilot
            {
                if (lang == 1) //ru
                {
                    siteObj = sitesFromNewDb.FirstOrDefault(s => s.title.Equals("Дельта-лоцман"));
                }
                else if (lang == 2) //ua
                {
                    siteObj = sitesFromNewDb.FirstOrDefault(s => s.title.Equals("Дельта-лоцман"));
                }
                else if (lang == 3) //en
                {
                    siteObj = sitesFromNewDb.FirstOrDefault(s => s.title.Equals("Delta-Pilot"));
                }
            }
            else if (site == 6) //izmail
            {
                if (lang == 1) //ru
                {
                    siteObj = sitesFromNewDb.FirstOrDefault(s => s.title.Equals("Измаил"));
                }
                else if (lang == 2) //ua
                {
                    siteObj = sitesFromNewDb.FirstOrDefault(s => s.title.Equals("Ізмаїл"));
                }
                else if (lang == 3) //en
                {
                    siteObj = sitesFromNewDb.FirstOrDefault(s => s.title.Equals("Ishmael"));
                }
            }
            else if (site == 7) //ilichevsk
            {
                if (lang == 1) //ru
                {
                    siteObj = sitesFromNewDb.FirstOrDefault(s => s.title.Equals("Ильичевск"));
                }
                else if (lang == 2) //ua
                {
                    siteObj = sitesFromNewDb.FirstOrDefault(s => s.title.Equals("Іллічівськ"));
                }
                else if (lang == 3) //en
                {
                    siteObj = sitesFromNewDb.FirstOrDefault(s => s.title.Equals("Ilyichevsk"));
                }
            }
            else if (site == 9) //mariupol
            {
                if (lang == 1) //ru
                {
                    siteObj = sitesFromNewDb.FirstOrDefault(s => s.title.Equals("Мариуполь"));
                }
                else if (lang == 2) //ua
                {
                    siteObj = sitesFromNewDb.FirstOrDefault(s => s.title.Equals("Маріуполь"));
                }
                else if (lang == 3) //en
                {
                    siteObj = sitesFromNewDb.FirstOrDefault(s => s.title.Equals("Mariupol"));
                }
            }
            else if (site == 10) //nikolaev
            {
                if (lang == 1) //ru
                {
                    siteObj = sitesFromNewDb.FirstOrDefault(s => s.title.Equals("Николаев"));
                }
                else if (lang == 2) //ua
                {
                    siteObj = sitesFromNewDb.FirstOrDefault(s => s.title.Equals("Миколаїв"));
                }
                else if (lang == 3) //en
                {
                    siteObj = sitesFromNewDb.FirstOrDefault(s => s.title.Equals("Nikolaev"));
                }
            }
            else if (site == 11) //oktabersk
            {
                if (lang == 1) //ru
                {
                    siteObj = sitesFromNewDb.FirstOrDefault(s => s.title.Equals("Октябрьск"));
                }
                else if (lang == 2) //ua
                {
                    siteObj = sitesFromNewDb.FirstOrDefault(s => s.title.Equals("Октябрьск"));
                }
                else if (lang == 3) //en
                {
                    siteObj = sitesFromNewDb.FirstOrDefault(s => s.title.Equals("Oktyabrsk"));
                }
            }
            else if (site == 12) //reni
            {
                if (lang == 1) //ru
                {
                    siteObj = sitesFromNewDb.FirstOrDefault(s => s.title.Equals("Рени"));
                }
                else if (lang == 2) //ua
                {
                    siteObj = sitesFromNewDb.FirstOrDefault(s => s.title.Equals("Рені"));
                }
                else if (lang == 3) //en
                {
                    siteObj = sitesFromNewDb.FirstOrDefault(s => s.title.Equals("Reni"));
                }
            }
            else if (site == 14) //skadovsk
            {
                if (lang == 1) //ru
                {
                    siteObj = sitesFromNewDb.FirstOrDefault(s => s.title.Equals("Скадовск"));
                }
                else if (lang == 2) //ua
                {
                    siteObj = sitesFromNewDb.FirstOrDefault(s => s.title.Equals("Скадовськ"));
                }
                else if (lang == 3) //en
                {
                    siteObj = sitesFromNewDb.FirstOrDefault(s => s.title.Equals("Skadovsk"));
                }
            }
            else if (site == 15) //dunaisk
            {
                if (lang == 1) //ru
                {
                    siteObj = sitesFromNewDb.FirstOrDefault(s => s.title.Equals("Усть-Дунайск"));
                }
                else if (lang == 2) //ua
                {
                    siteObj = sitesFromNewDb.FirstOrDefault(s => s.title.Equals("Усть-Дунайск"));
                }
                else if (lang == 3) //en
                {
                    siteObj = sitesFromNewDb.FirstOrDefault(s => s.title.Equals("Ust-Danube"));
                }
            }
            else if (site == 17) //herson
            {
                if (lang == 1) //ru
                {
                    siteObj = sitesFromNewDb.FirstOrDefault(s => s.title.Equals("Херсон"));
                }
                else if (lang == 2) //ua
                {
                    siteObj = sitesFromNewDb.FirstOrDefault(s => s.title.Equals("Херсон"));
                }
                else if (lang == 3) //en
                {
                    siteObj = sitesFromNewDb.FirstOrDefault(s => s.title.Equals("Herson"));
                }
            }
            else if (site == 18) //uznie
            {
                if (lang == 1) //ru
                {
                    siteObj = sitesFromNewDb.FirstOrDefault(s => s.title.Equals("Южный"));
                }
                else if (lang == 2) //ua
                {
                    siteObj = sitesFromNewDb.FirstOrDefault(s => s.title.Equals("Южний"));
                }
                else if (lang == 3) //en
                {
                    siteObj = sitesFromNewDb.FirstOrDefault(s => s.title.Equals("Yuznyi"));
                }
            }

            return siteObj;
        }


        void MenuMigrationFromSite()
        {
            using (ApplicationDbContext newDb = new ApplicationDbContext())
            {
                //var menuTypesFromNewDb = newDb.MenuType.ToList();
                var sitesFromNewDb = newDb.Sites.ToList();
                var categoriesFromNewDb = newDb.Categories.ToList();

                var menuType = newDb.MenuType.FirstOrDefault(m => m.title.Equals("Main menu"));

                List<Menu> menu = new List<Menu>();

                using (MySqlConnection connect = new MySqlConnection(conn_string.ToString()))
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    string commandLine = "SELECT id, active, siteid, lan, category_id, title, belong   FROM site_menu";
                    cmd.CommandText = commandLine;

                    cmd.Connection = connect;
                    cmd.Connection.Open();

                    using (MySqlDataReader msdr = cmd.ExecuteReader())
                    {
                        while (msdr.Read())
                        {
                            int lang = Int32.Parse(msdr.GetString(3));
                            int site = Int32.Parse(msdr.GetString(2));
                            int catId = Int32.Parse(msdr.GetString(4));

                            //если сайт не входит в категорию которую не нужно копировать, копирую
                            //if (sitesWhichNoNeedToMigrate.Any(s => s == site))
                            if (!sitesWhichNoNeedToMigrate.Contains(site))
                            {
                                Menu m = new Menu()
                                {
                                    state = (Int32.Parse(msdr.GetString(1)) > 0) ? true : false,
                                    title = msdr.GetString(5),
                                    previd = Int32.Parse(msdr.GetString(0)),
                                    parentidPrev = Int32.Parse(msdr.GetString(6)),
                                    menuType = menuType,
                                };


                                m.site = SiteDefenition(sitesFromNewDb, site, lang);
                                //m.category = categoriesFromNewDb.FirstOrDefault(c => c.previd == catId);

                                menu.Add(m);
                            }
                        }
                        //do stuff.....
                    } // <- here the DataReader is closed and disposed.
                }


                newDb.Menu.AddRange(menu);
                int countChanges = newDb.SaveChanges();
                Console.WriteLine("menu migration from site | rows=" + countChanges);
            }
        }

        void MenuToMenuMigrationFromSite()
        {
            //field belong = parentMenuId

            using (ApplicationDbContext newDb = new ApplicationDbContext())
            {
                var menu = newDb.Menu.ToList();

                for (int i = 0; i < menu.Count; i++)
                {
                    Menu parentMenu = null;
                    if (menu[i].parentidPrev > 0)
                        parentMenu = menu.FirstOrDefault(m => m.previd == menu[i].parentidPrev);
                    //parentMenu.menu.Add(menu[i]);
                    if (parentMenu != null)
                        menu[i].parentid = parentMenu.id;
                }

                //foreach(var item in menu)
                //{
                //    Menu parentMenu = menu.FirstOrDefault(m => m.previd == item.parentidPrev);
                //    parentMenu.parent = item;
                //}
                int countChanges = newDb.SaveChanges();
                Console.WriteLine("MenyToMenu migration from site| rows=" + countChanges);
            }
        }

        #endregion

        void ClearPrevId()
        {
            //prevId exist in table
            //User prevId
            //Menu prevId parentPrevId
            //Albums prevId
            //Category prevId
            //Content prevId

            int numberWhichNeverUsed = 9999;

            using (ApplicationDbContext newDb = new ApplicationDbContext())
            {
                var users = newDb.Users.ToList();

                for (int i = 0; i < users.Count; i++)
                {
                    users[i].prevId = numberWhichNeverUsed;
                }

                var menus = newDb.Menu.ToList();
                for (int i = 0; i < menus.Count; i++)
                {
                    menus[i].previd = numberWhichNeverUsed;
                }

                var albums = newDb.Albums.ToList();
                for (int i = 0; i < albums.Count; i++)
                {
                    albums[i].previd = numberWhichNeverUsed;
                }

                var categories = newDb.Categories.ToList();
                for (int i = 0; i < categories.Count; i++)
                {
                    categories[i].previd = numberWhichNeverUsed;
                }

                var contents = newDb.Contents.ToList();
                for (int i = 0; i < contents.Count; i++)
                {
                    contents[i].previd = numberWhichNeverUsed;
                }


                int countChanges = newDb.SaveChanges();
                Console.WriteLine("prevId is cleared| count rows = " + countChanges);
            }
        }
    }
}
