namespace ConsoleAppMigration.CodeFirstForAspIdentity.DbModel
{
    //url siteId/categoryId/contentId автоматическую генерацию
    public class Menu
    {
        public int id { get; set; }
        //public int menuTypeId { get; set; }
        public virtual MenuType menuType { get; set; }
        public int previd { get; set; }
        public int? parentidPrev { get; set; }

        public int? parentid { get; set; }

        public string title { get; set; }
        public bool state { get; set; }

        //public int siteId { get; set; }
        public virtual Site site { get; set; } //all odessa 

        //public int contentId { get; set; }
        public virtual Content сontent { get; set; } //nullable пока не связываем

        //public int categoryId { get; set; }
        //public virtual Category category { get; set; } //++++

        //public int languageId { get; set; }
        //public virtual Language language { get; set; }

        //public virtual ICollection<Menu> menu { set; get; }
        //public Menu()
        //{
        //    menu = new List<Menu>();
        //}
    }
}