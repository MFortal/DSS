namespace DSS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteImageFromSubCategory : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Subcategories", "Image");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Subcategories", "Image", c => c.String());
        }
    }
}
