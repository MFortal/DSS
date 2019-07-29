namespace DSS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Сategory",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Image = c.Binary(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Subcategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Image = c.Binary(),
                        CategoryId = c.Int(nullable: false),
                        Categories_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Сategory", t => t.Categories_Id)
                .Index(t => t.Categories_Id);
            
            CreateTable(
                "dbo.Components",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Image = c.Binary(),
                        CountryId = c.Int(nullable: false),
                        CategoryId = c.Int(nullable: false),
                        Subcategory_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Countries", t => t.CountryId, cascadeDelete: true)
                .ForeignKey("dbo.Subcategories", t => t.Subcategory_Id)
                .Index(t => t.CountryId)
                .Index(t => t.Subcategory_Id);
            
            CreateTable(
                "dbo.Cells",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ComponentId = c.Int(nullable: false),
                        PropertyId = c.Int(nullable: false),
                        ValueId = c.Int(),
                        Value = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Components", t => t.ComponentId, cascadeDelete: true)
                .ForeignKey("dbo.Properties", t => t.PropertyId, cascadeDelete: true)
                .ForeignKey("dbo.Values", t => t.ValueId)
                .Index(t => new { t.ComponentId, t.PropertyId }, unique: true)
                .Index(t => t.ValueId);
            
            CreateTable(
                "dbo.Properties",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Unit = c.String(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SubcategoryProperties",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SubcategoryId = c.Int(nullable: false),
                        PropertyId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Properties", t => t.PropertyId, cascadeDelete: true)
                .ForeignKey("dbo.Subcategories", t => t.SubcategoryId, cascadeDelete: true)
                .Index(t => t.SubcategoryId)
                .Index(t => t.PropertyId);
            
            CreateTable(
                "dbo.Values",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Value = c.String(nullable: false),
                        PropertyId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Properties", t => t.PropertyId, cascadeDelete: true)
                .Index(t => t.PropertyId);
            
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Flag = c.Binary(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Components", "Subcategory_Id", "dbo.Subcategories");
            DropForeignKey("dbo.Components", "CountryId", "dbo.Countries");
            DropForeignKey("dbo.Values", "PropertyId", "dbo.Properties");
            DropForeignKey("dbo.Cells", "ValueId", "dbo.Values");
            DropForeignKey("dbo.SubcategoryProperties", "SubcategoryId", "dbo.Subcategories");
            DropForeignKey("dbo.SubcategoryProperties", "PropertyId", "dbo.Properties");
            DropForeignKey("dbo.Cells", "PropertyId", "dbo.Properties");
            DropForeignKey("dbo.Cells", "ComponentId", "dbo.Components");
            DropForeignKey("dbo.Subcategories", "Categories_Id", "dbo.Сategory");
            DropIndex("dbo.Values", new[] { "PropertyId" });
            DropIndex("dbo.SubcategoryProperties", new[] { "PropertyId" });
            DropIndex("dbo.SubcategoryProperties", new[] { "SubcategoryId" });
            DropIndex("dbo.Cells", new[] { "ValueId" });
            DropIndex("dbo.Cells", new[] { "ComponentId", "PropertyId" });
            DropIndex("dbo.Components", new[] { "Subcategory_Id" });
            DropIndex("dbo.Components", new[] { "CountryId" });
            DropIndex("dbo.Subcategories", new[] { "Categories_Id" });
            DropTable("dbo.Countries");
            DropTable("dbo.Values");
            DropTable("dbo.SubcategoryProperties");
            DropTable("dbo.Properties");
            DropTable("dbo.Cells");
            DropTable("dbo.Components");
            DropTable("dbo.Subcategories");
            DropTable("dbo.Сategory");
        }
    }
}
