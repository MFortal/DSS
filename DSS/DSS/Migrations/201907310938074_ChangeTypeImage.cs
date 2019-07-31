namespace DSS.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class ChangeTypeImage : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Categories", "Image", c => c.String());
            AlterColumn("dbo.Subcategories", "Image", c => c.String());
            AlterColumn("dbo.Components", "Image", c => c.String());
            AlterColumn("dbo.Countries", "Flag", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Countries", "Flag", c => c.Binary());
            AlterColumn("dbo.Components", "Image", c => c.Binary());
            AlterColumn("dbo.Subcategories", "Image", c => c.Binary());
            AlterColumn("dbo.Categories", "Image", c => c.Binary());
        }
    }
}
