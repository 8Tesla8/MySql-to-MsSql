//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ConsoleAppMigration
{
    using System;
    using System.Collections.Generic;
    
    public partial class ampu_phocagallery_img_votes
    {
        public int id { get; set; }
        public int imgid { get; set; }
        public int userid { get; set; }
        public System.DateTime date { get; set; }
        public bool rating { get; set; }
        public bool published { get; set; }
        public long checked_out { get; set; }
        public System.DateTime checked_out_time { get; set; }
        public int ordering { get; set; }
        public string @params { get; set; }
        public string language { get; set; }
    }
}
