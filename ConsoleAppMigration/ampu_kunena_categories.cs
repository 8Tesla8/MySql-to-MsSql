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
    
    public partial class ampu_kunena_categories
    {
        public int id { get; set; }
        public Nullable<int> parent_id { get; set; }
        public string name { get; set; }
        public string alias { get; set; }
        public sbyte icon_id { get; set; }
        public sbyte locked { get; set; }
        public string accesstype { get; set; }
        public int access { get; set; }
        public int pub_access { get; set; }
        public Nullable<sbyte> pub_recurse { get; set; }
        public int admin_access { get; set; }
        public Nullable<sbyte> admin_recurse { get; set; }
        public short ordering { get; set; }
        public sbyte published { get; set; }
        public string channels { get; set; }
        public sbyte checked_out { get; set; }
        public System.DateTime checked_out_time { get; set; }
        public sbyte review { get; set; }
        public sbyte allow_anonymous { get; set; }
        public sbyte post_anonymous { get; set; }
        public int hits { get; set; }
        public string description { get; set; }
        public string headerdesc { get; set; }
        public string class_sfx { get; set; }
        public sbyte allow_polls { get; set; }
        public string topic_ordering { get; set; }
        public int numTopics { get; set; }
        public int numPosts { get; set; }
        public int last_topic_id { get; set; }
        public int last_post_id { get; set; }
        public int last_post_time { get; set; }
        public string @params { get; set; }
    }
}
