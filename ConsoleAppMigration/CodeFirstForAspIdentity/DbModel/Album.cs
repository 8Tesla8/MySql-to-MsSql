using System.Collections.Generic;

namespace ConsoleAppMigration.CodeFirstForAspIdentity.DbModel
{
    public class Album //ampu_phocogalery_category
    {
        public int id { get; set; }
        public string title { get; set; }
        //public bool state { get; set; }
        public int previd { get; set; }
        public System.DateTime? created { get; set; }
        //public long createdByUserId { get; set; }
        public virtual User createdByUser { get; set; } //publish

        public System.DateTime? modified { get; set; }
        //public long modifiedByUserId { get; set; }
        public virtual User modifiedByUser { get; set; }

        public virtual Language language { get; set; }

        public virtual ICollection<Image> images { set; get; }
        public Album()
        {
            images = new List<Image>();
        }
    }
}
