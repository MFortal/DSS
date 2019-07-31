namespace DSS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ColumnProperty : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Components", "Subcategory_Id", "dbo.Subcategories");
            DropIndex("dbo.Components", new[] { "Subcategory_Id" });
            RenameColumn(table: "dbo.Components", name: "Subcategory_Id", newName: "SubcategoryId");
            AlterColumn("dbo.Components", "SubcategoryId", c => c.Int(nullable: false));
            CreateIndex("dbo.Components", "SubcategoryId");
            AddForeignKey("dbo.Components", "SubcategoryId", "dbo.Subcategories", "Id", cascadeDelete: true);
            DropColumn("dbo.Components", "CategoryId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Components", "CategoryId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Components", "SubcategoryId", "dbo.Subcategories");
            DropIndex("dbo.Components", new[] { "SubcategoryId" });
            AlterColumn("dbo.Components", "SubcategoryId", c => c.Int());
            RenameColumn(table: "dbo.Components", name: "SubcategoryId", newName: "Subcategory_Id");
            CreateIndex("dbo.Components", "Subcategory_Id");
            AddForeignKey("dbo.Components", "Subcategory_Id", "dbo.Subcategories", "Id");
        }
    }
}
