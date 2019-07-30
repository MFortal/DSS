namespace DSS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration1 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Сategory", newName: "Categories");
            DropForeignKey("dbo.Subcategories", "Categories_Id", "dbo.Сategory");
            DropIndex("dbo.Subcategories", new[] { "Categories_Id" });
            DropColumn("dbo.Subcategories", "CategoryId");
            RenameColumn(table: "dbo.Subcategories", name: "Categories_Id", newName: "CategoryId");
            AlterColumn("dbo.Subcategories", "CategoryId", c => c.Int(nullable: false));
            CreateIndex("dbo.Subcategories", "CategoryId");
            AddForeignKey("dbo.Subcategories", "CategoryId", "dbo.Categories", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Subcategories", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Subcategories", new[] { "CategoryId" });
            AlterColumn("dbo.Subcategories", "CategoryId", c => c.Int());
            RenameColumn(table: "dbo.Subcategories", name: "CategoryId", newName: "Categories_Id");
            AddColumn("dbo.Subcategories", "CategoryId", c => c.Int(nullable: false));
            CreateIndex("dbo.Subcategories", "Categories_Id");
            AddForeignKey("dbo.Subcategories", "Categories_Id", "dbo.Сategory", "Id");
            RenameTable(name: "dbo.Categories", newName: "Сategory");
        }
    }
}
