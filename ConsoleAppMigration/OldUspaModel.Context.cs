﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ConsoleAppMigration
{
    using System.Data.Entity;

    public partial class oldUspaEntities : DbContext
    {
        public oldUspaEntities()
            : base("name=oldUspaEntities")
        {
        }


        public DbSet<ampu_acymailing_config> ampu_acymailing_config { get; set; }
        public DbSet<ampu_acymailing_fields> ampu_acymailing_fields { get; set; }
        public DbSet<ampu_acymailing_filter> ampu_acymailing_filter { get; set; }
        public DbSet<ampu_acymailing_list> ampu_acymailing_list { get; set; }
        public DbSet<ampu_acymailing_listcampaign> ampu_acymailing_listcampaign { get; set; }
        public DbSet<ampu_acymailing_listmail> ampu_acymailing_listmail { get; set; }
        public DbSet<ampu_acymailing_listsub> ampu_acymailing_listsub { get; set; }
        public DbSet<ampu_acymailing_mail> ampu_acymailing_mail { get; set; }
        public DbSet<ampu_acymailing_queue> ampu_acymailing_queue { get; set; }
        public DbSet<ampu_acymailing_rules> ampu_acymailing_rules { get; set; }
        public DbSet<ampu_acymailing_stats> ampu_acymailing_stats { get; set; }
        public DbSet<ampu_acymailing_subscriber> ampu_acymailing_subscriber { get; set; }
        public DbSet<ampu_acymailing_subscriber_copy> ampu_acymailing_subscriber_copy { get; set; }
        public DbSet<ampu_acymailing_template> ampu_acymailing_template { get; set; }
        public DbSet<ampu_acymailing_url> ampu_acymailing_url { get; set; }
        public DbSet<ampu_acymailing_urlclick> ampu_acymailing_urlclick { get; set; }
        public DbSet<ampu_acymailing_userstats> ampu_acymailing_userstats { get; set; }
        public DbSet<ampu_assets> ampu_assets { get; set; }
        public DbSet<ampu_associations> ampu_associations { get; set; }
        public DbSet<ampu_banner_clients> ampu_banner_clients { get; set; }
        public DbSet<ampu_banner_tracks> ampu_banner_tracks { get; set; }
        public DbSet<ampu_banners> ampu_banners { get; set; }
        public DbSet<ampu_categories> ampu_categories { get; set; }
        public DbSet<ampu_contact_details> ampu_contact_details { get; set; }
        public DbSet<ampu_content> ampu_content { get; set; }
        public DbSet<ampu_content_frontpage> ampu_content_frontpage { get; set; }
        public DbSet<ampu_content_rating> ampu_content_rating { get; set; }
        public DbSet<ampu_easybook> ampu_easybook { get; set; }
        public DbSet<ampu_easybook_badwords> ampu_easybook_badwords { get; set; }
        public DbSet<ampu_extensions> ampu_extensions { get; set; }
        public DbSet<ampu_finder_filters> ampu_finder_filters { get; set; }
        public DbSet<ampu_finder_links> ampu_finder_links { get; set; }
        public DbSet<ampu_finder_links_terms0> ampu_finder_links_terms0 { get; set; }
        public DbSet<ampu_finder_links_terms1> ampu_finder_links_terms1 { get; set; }
        public DbSet<ampu_finder_links_terms2> ampu_finder_links_terms2 { get; set; }
        public DbSet<ampu_finder_links_terms3> ampu_finder_links_terms3 { get; set; }
        public DbSet<ampu_finder_links_terms4> ampu_finder_links_terms4 { get; set; }
        public DbSet<ampu_finder_links_terms5> ampu_finder_links_terms5 { get; set; }
        public DbSet<ampu_finder_links_terms6> ampu_finder_links_terms6 { get; set; }
        public DbSet<ampu_finder_links_terms7> ampu_finder_links_terms7 { get; set; }
        public DbSet<ampu_finder_links_terms8> ampu_finder_links_terms8 { get; set; }
        public DbSet<ampu_finder_links_terms9> ampu_finder_links_terms9 { get; set; }
        public DbSet<ampu_finder_links_termsa> ampu_finder_links_termsa { get; set; }
        public DbSet<ampu_finder_links_termsb> ampu_finder_links_termsb { get; set; }
        public DbSet<ampu_finder_links_termsc> ampu_finder_links_termsc { get; set; }
        public DbSet<ampu_finder_links_termsd> ampu_finder_links_termsd { get; set; }
        public DbSet<ampu_finder_links_termse> ampu_finder_links_termse { get; set; }
        public DbSet<ampu_finder_links_termsf> ampu_finder_links_termsf { get; set; }
        public DbSet<ampu_finder_taxonomy> ampu_finder_taxonomy { get; set; }
        public DbSet<ampu_finder_taxonomy_map> ampu_finder_taxonomy_map { get; set; }
        public DbSet<ampu_finder_terms> ampu_finder_terms { get; set; }
        public DbSet<ampu_finder_types> ampu_finder_types { get; set; }
        public DbSet<ampu_jcomments> ampu_jcomments { get; set; }
        public DbSet<ampu_jcomments_blacklist> ampu_jcomments_blacklist { get; set; }
        public DbSet<ampu_jcomments_custom_bbcodes> ampu_jcomments_custom_bbcodes { get; set; }
        public DbSet<ampu_jcomments_objects> ampu_jcomments_objects { get; set; }
        public DbSet<ampu_jcomments_reports> ampu_jcomments_reports { get; set; }
        public DbSet<ampu_jcomments_settings> ampu_jcomments_settings { get; set; }
        public DbSet<ampu_jcomments_subscriptions> ampu_jcomments_subscriptions { get; set; }
        public DbSet<ampu_jcomments_version> ampu_jcomments_version { get; set; }
        public DbSet<ampu_jcomments_votes> ampu_jcomments_votes { get; set; }
        public DbSet<ampu_kunena_announcement> ampu_kunena_announcement { get; set; }
        public DbSet<ampu_kunena_attachments> ampu_kunena_attachments { get; set; }
        public DbSet<ampu_kunena_categories> ampu_kunena_categories { get; set; }
        public DbSet<ampu_kunena_configuration> ampu_kunena_configuration { get; set; }
        public DbSet<ampu_kunena_keywords> ampu_kunena_keywords { get; set; }
        public DbSet<ampu_kunena_messages> ampu_kunena_messages { get; set; }
        public DbSet<ampu_kunena_messages_text> ampu_kunena_messages_text { get; set; }
        public DbSet<ampu_kunena_polls> ampu_kunena_polls { get; set; }
        public DbSet<ampu_kunena_polls_options> ampu_kunena_polls_options { get; set; }
        public DbSet<ampu_kunena_ranks> ampu_kunena_ranks { get; set; }
        public DbSet<ampu_kunena_sessions> ampu_kunena_sessions { get; set; }
        public DbSet<ampu_kunena_smileys> ampu_kunena_smileys { get; set; }
        public DbSet<ampu_kunena_topics> ampu_kunena_topics { get; set; }
        public DbSet<ampu_kunena_user_categories> ampu_kunena_user_categories { get; set; }
        public DbSet<ampu_kunena_users> ampu_kunena_users { get; set; }
        public DbSet<ampu_kunena_users_banned> ampu_kunena_users_banned { get; set; }
        public DbSet<ampu_kunena_version> ampu_kunena_version { get; set; }
        public DbSet<ampu_languages> ampu_languages { get; set; }
        public DbSet<ampu_menu> ampu_menu { get; set; }
        public DbSet<ampu_menu_types> ampu_menu_types { get; set; }
        public DbSet<ampu_messages> ampu_messages { get; set; }
        public DbSet<ampu_modules> ampu_modules { get; set; }
        public DbSet<ampu_modules_menu> ampu_modules_menu { get; set; }
        public DbSet<ampu_newsfeeds> ampu_newsfeeds { get; set; }
        public DbSet<ampu_overrider> ampu_overrider { get; set; }
        public DbSet<ampu_phocagallery> ampu_phocagallery { get; set; }
        public DbSet<ampu_phocagallery_categories> ampu_phocagallery_categories { get; set; }
        public DbSet<ampu_phocagallery_comments> ampu_phocagallery_comments { get; set; }
        public DbSet<ampu_phocagallery_fb_users> ampu_phocagallery_fb_users { get; set; }
        public DbSet<ampu_phocagallery_img_comments> ampu_phocagallery_img_comments { get; set; }
        public DbSet<ampu_phocagallery_img_votes> ampu_phocagallery_img_votes { get; set; }
        public DbSet<ampu_phocagallery_img_votes_statistics> ampu_phocagallery_img_votes_statistics { get; set; }
        public DbSet<ampu_phocagallery_tags> ampu_phocagallery_tags { get; set; }
        public DbSet<ampu_phocagallery_tags_ref> ampu_phocagallery_tags_ref { get; set; }
        public DbSet<ampu_phocagallery_user> ampu_phocagallery_user { get; set; }
        public DbSet<ampu_phocagallery_votes> ampu_phocagallery_votes { get; set; }
        public DbSet<ampu_phocagallery_votes_statistics> ampu_phocagallery_votes_statistics { get; set; }
        public DbSet<ampu_redirect_links> ampu_redirect_links { get; set; }
        public DbSet<ampu_schemas> ampu_schemas { get; set; }
        public DbSet<ampu_session> ampu_session { get; set; }
        public DbSet<ampu_template_styles> ampu_template_styles { get; set; }
        public DbSet<ampu_update_categories> ampu_update_categories { get; set; }
        public DbSet<ampu_update_sites> ampu_update_sites { get; set; }
        public DbSet<ampu_update_sites_extensions> ampu_update_sites_extensions { get; set; }
        public DbSet<ampu_updates> ampu_updates { get; set; }
        public DbSet<ampu_user_notes> ampu_user_notes { get; set; }
        public DbSet<ampu_user_usergroup_map> ampu_user_usergroup_map { get; set; }
        public DbSet<ampu_usergroups> ampu_usergroups { get; set; }
        public DbSet<ampu_users> ampu_users { get; set; }
        public DbSet<ampu_viewlevels> ampu_viewlevels { get; set; }
        public DbSet<ampu_weblinks> ampu_weblinks { get; set; }
        public DbSet<ampu_wf_profiles> ampu_wf_profiles { get; set; }
        public DbSet<ampu_xmap_items> ampu_xmap_items { get; set; }
        public DbSet<ampu_xmap_sitemap> ampu_xmap_sitemap { get; set; }
        public DbSet<blank> blank { get; set; }
        public DbSet<history> history { get; set; }
        public DbSet<pro_config> pro_config { get; set; }
        public DbSet<pro_dev_direction> pro_dev_direction { get; set; }
        public DbSet<pro_direction> pro_direction { get; set; }
        public DbSet<pro_port> pro_port { get; set; }
        public DbSet<pro_project> pro_project { get; set; }
        public DbSet<pro_roles> pro_roles { get; set; }
        public DbSet<pro_user_tokens> pro_user_tokens { get; set; }
        public DbSet<pro_users> pro_users { get; set; }
        public DbSet<site_admin_log> site_admin_log { get; set; }
        public DbSet<site_admin_menu> site_admin_menu { get; set; }
        public DbSet<site_category> site_category { get; set; }
        public DbSet<site_config> site_config { get; set; }
        public DbSet<site_content> site_content { get; set; }
        public DbSet<site_files> site_files { get; set; }
        public DbSet<site_images> site_images { get; set; }
        public DbSet<site_info> site_info { get; set; }
        public DbSet<site_lan> site_lan { get; set; }
        public DbSet<site_menu> site_menu { get; set; }
        public DbSet<site_url_content> site_url_content { get; set; }
        public DbSet<site_url_menu> site_url_menu { get; set; }
        public DbSet<site_users> site_users { get; set; }
        public DbSet<ampu_acymailing_history> ampu_acymailing_history { get; set; }
        public DbSet<ampu_core_log_searches> ampu_core_log_searches { get; set; }
        public DbSet<ampu_finder_terms_common> ampu_finder_terms_common { get; set; }
        public DbSet<ampu_finder_tokens> ampu_finder_tokens { get; set; }
        public DbSet<ampu_finder_tokens_aggregate> ampu_finder_tokens_aggregate { get; set; }
        public DbSet<ampu_ga_dash> ampu_ga_dash { get; set; }
        public DbSet<ampu_ga_dash_cache> ampu_ga_dash_cache { get; set; }
        public DbSet<ampu_kunena_aliases> ampu_kunena_aliases { get; set; }
        public DbSet<ampu_kunena_keywords_map> ampu_kunena_keywords_map { get; set; }
        public DbSet<ampu_kunena_polls_users> ampu_kunena_polls_users { get; set; }
        public DbSet<ampu_kunena_thankyou> ampu_kunena_thankyou { get; set; }
        public DbSet<ampu_kunena_user_read> ampu_kunena_user_read { get; set; }
        public DbSet<ampu_kunena_user_topics> ampu_kunena_user_topics { get; set; }
        public DbSet<ampu_messages_cfg> ampu_messages_cfg { get; set; }
        public DbSet<ampu_user_profiles> ampu_user_profiles { get; set; }
        public DbSet<pro_roles_users> pro_roles_users { get; set; }
    }
}