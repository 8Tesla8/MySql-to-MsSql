namespace WebAppDb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFewDbDetails : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Albums",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        title = c.String(),
                        previd = c.Int(nullable: false),
                        created = c.DateTime(),
                        modified = c.DateTime(),
                        createdByUser_Id = c.String(maxLength: 128),
                        language_id = c.Int(),
                        modifiedByUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Users", t => t.createdByUser_Id)
                .ForeignKey("dbo.Languages", t => t.language_id)
                .ForeignKey("dbo.Users", t => t.modifiedByUser_Id)
                .Index(t => t.createdByUser_Id)
                .Index(t => t.language_id)
                .Index(t => t.modifiedByUser_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        prevId = c.Int(nullable: false),
                        name = c.Int(nullable: false),
                        registerDate = c.DateTime(),
                        lastVisitDate = c.DateTime(),
                        block = c.Boolean(nullable: false),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.IdentityUserLogins",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.IdentityUserRoles",
                c => new
                    {
                        RoleId = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                        IdentityRole_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.RoleId, t.UserId })
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.IdentityRoles", t => t.IdentityRole_Id)
                .Index(t => t.UserId)
                .Index(t => t.IdentityRole_Id);
            
            CreateTable(
                "dbo.Images",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true),
                        title = c.String(),
                        filePath = c.String(),
                        created = c.DateTime(),
                        state = c.Boolean(nullable: false),
                        album_id = c.Int(),
                        createdByUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Albums", t => t.album_id)
                .ForeignKey("dbo.Users", t => t.createdByUser_Id)
                .Index(t => t.album_id)
                .Index(t => t.createdByUser_Id);
            
            CreateTable(
                "dbo.Languages",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        title = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Banners",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        title = c.String(),
                        url = c.String(),
                        state = c.Boolean(nullable: false),
                        site_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Sites", t => t.site_id)
                .Index(t => t.site_id);
            
            CreateTable(
                "dbo.Sites",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        title = c.String(),
                        countContent = c.Int(nullable: false),
                        language_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Languages", t => t.language_id)
                .Index(t => t.language_id);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        title = c.String(),
                        previd = c.Int(nullable: false),
                        createdTime = c.DateTime(),
                        published = c.Boolean(nullable: false),
                        createdByUser_Id = c.String(maxLength: 128),
                        language_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Users", t => t.createdByUser_Id)
                .ForeignKey("dbo.Languages", t => t.language_id)
                .Index(t => t.createdByUser_Id)
                .Index(t => t.language_id);
            
            CreateTable(
                "dbo.IdentityRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Contents",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        title = c.String(),
                        introtext = c.String(),
                        fulltext = c.String(),
                        state = c.Boolean(nullable: false),
                        created = c.DateTime(),
                        modified = c.DateTime(),
                        published = c.DateTime(),
                        checkIn = c.DateTime(),
                        checkOut = c.DateTime(),
                        category_id = c.Int(),
                        createdByUser_Id = c.String(maxLength: 128),
                        modifiedByUser_Id = c.String(maxLength: 128),
                        site_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Categories", t => t.category_id)
                .ForeignKey("dbo.Users", t => t.createdByUser_Id)
                .ForeignKey("dbo.Users", t => t.modifiedByUser_Id)
                .ForeignKey("dbo.Sites", t => t.site_id)
                .Index(t => t.category_id)
                .Index(t => t.createdByUser_Id)
                .Index(t => t.modifiedByUser_Id)
                .Index(t => t.site_id);
            
            CreateTable(
                "dbo.Menus",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        previd = c.Int(nullable: false),
                        parentidPrev = c.Int(),
                        parentid = c.Int(),
                        title = c.String(),
                        state = c.Boolean(nullable: false),
                        menuType_id = c.Long(),
                        site_id = c.Int(),
                        сontent_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.MenuTypes", t => t.menuType_id)
                .ForeignKey("dbo.Sites", t => t.site_id)
                .ForeignKey("dbo.Contents", t => t.сontent_id)
                .Index(t => t.menuType_id)
                .Index(t => t.site_id)
                .Index(t => t.сontent_id);
            
            CreateTable(
                "dbo.MenuTypes",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true),
                        title = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.CategoryToRole",
                c => new
                    {
                        RoleId = c.Int(nullable: false),
                        CategoryId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.RoleId, t.CategoryId })
                .ForeignKey("dbo.Categories", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.IdentityRoles", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.RoleId)
                .Index(t => t.CategoryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRoles", "IdentityRole_Id", "dbo.IdentityRoles");
            DropForeignKey("dbo.Menus", "сontent_id", "dbo.Contents");
            DropForeignKey("dbo.Menus", "site_id", "dbo.Sites");
            DropForeignKey("dbo.Menus", "menuType_id", "dbo.MenuTypes");
            DropForeignKey("dbo.Contents", "site_id", "dbo.Sites");
            DropForeignKey("dbo.Contents", "modifiedByUser_Id", "dbo.Users");
            DropForeignKey("dbo.Contents", "createdByUser_Id", "dbo.Users");
            DropForeignKey("dbo.Contents", "category_id", "dbo.Categories");
            DropForeignKey("dbo.Categories", "language_id", "dbo.Languages");
            DropForeignKey("dbo.Categories", "createdByUser_Id", "dbo.Users");
            DropForeignKey("dbo.CategoryToRole", "CategoryId", "dbo.IdentityRoles");
            DropForeignKey("dbo.CategoryToRole", "RoleId", "dbo.Categories");
            DropForeignKey("dbo.Banners", "site_id", "dbo.Sites");
            DropForeignKey("dbo.Sites", "language_id", "dbo.Languages");
            DropForeignKey("dbo.Albums", "modifiedByUser_Id", "dbo.Users");
            DropForeignKey("dbo.Albums", "language_id", "dbo.Languages");
            DropForeignKey("dbo.Images", "createdByUser_Id", "dbo.Users");
            DropForeignKey("dbo.Images", "album_id", "dbo.Albums");
            DropForeignKey("dbo.Albums", "createdByUser_Id", "dbo.Users");
            DropForeignKey("dbo.IdentityUserRoles", "UserId", "dbo.Users");
            DropForeignKey("dbo.IdentityUserLogins", "User_Id", "dbo.Users");
            DropForeignKey("dbo.IdentityUserClaims", "UserId", "dbo.Users");
            DropIndex("dbo.CategoryToRole", new[] { "CategoryId" });
            DropIndex("dbo.CategoryToRole", new[] { "RoleId" });
            DropIndex("dbo.Menus", new[] { "сontent_id" });
            DropIndex("dbo.Menus", new[] { "site_id" });
            DropIndex("dbo.Menus", new[] { "menuType_id" });
            DropIndex("dbo.Contents", new[] { "site_id" });
            DropIndex("dbo.Contents", new[] { "modifiedByUser_Id" });
            DropIndex("dbo.Contents", new[] { "createdByUser_Id" });
            DropIndex("dbo.Contents", new[] { "category_id" });
            DropIndex("dbo.Categories", new[] { "language_id" });
            DropIndex("dbo.Categories", new[] { "createdByUser_Id" });
            DropIndex("dbo.Sites", new[] { "language_id" });
            DropIndex("dbo.Banners", new[] { "site_id" });
            DropIndex("dbo.Images", new[] { "createdByUser_Id" });
            DropIndex("dbo.Images", new[] { "album_id" });
            DropIndex("dbo.IdentityUserRoles", new[] { "IdentityRole_Id" });
            DropIndex("dbo.IdentityUserRoles", new[] { "UserId" });
            DropIndex("dbo.IdentityUserLogins", new[] { "User_Id" });
            DropIndex("dbo.IdentityUserClaims", new[] { "UserId" });
            DropIndex("dbo.Albums", new[] { "modifiedByUser_Id" });
            DropIndex("dbo.Albums", new[] { "language_id" });
            DropIndex("dbo.Albums", new[] { "createdByUser_Id" });
            DropTable("dbo.CategoryToRole");
            DropTable("dbo.MenuTypes");
            DropTable("dbo.Menus");
            DropTable("dbo.Contents");
            DropTable("dbo.IdentityRoles");
            DropTable("dbo.Categories");
            DropTable("dbo.Sites");
            DropTable("dbo.Banners");
            DropTable("dbo.Languages");
            DropTable("dbo.Images");
            DropTable("dbo.IdentityUserRoles");
            DropTable("dbo.IdentityUserLogins");
            DropTable("dbo.IdentityUserClaims");
            DropTable("dbo.Users");
            DropTable("dbo.Albums");
        }
    }
}
