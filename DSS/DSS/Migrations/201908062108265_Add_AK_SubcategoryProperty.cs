namespace DSS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_AK_SubcategoryProperty : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.SubcategoryProperties", new[] { "SubcategoryId" });
            DropIndex("dbo.SubcategoryProperties", new[] { "PropertyId" });
            CreateIndex("dbo.SubcategoryProperties", new[] { "SubcategoryId", "PropertyId" }, unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.SubcategoryProperties", new[] { "SubcategoryId", "PropertyId" });
            CreateIndex("dbo.SubcategoryProperties", "PropertyId");
            CreateIndex("dbo.SubcategoryProperties", "SubcategoryId");
        }
    }
}
