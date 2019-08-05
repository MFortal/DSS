namespace DSS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PropertyUnitNull : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SearchComponents",
                c => new
                    {
                        PropertyName = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.PropertyName);
            
            AddColumn("dbo.Values", "SearchComponents_PropertyName", c => c.String(maxLength: 128));
            AlterColumn("dbo.Properties", "Unit", c => c.String());
            CreateIndex("dbo.Values", "SearchComponents_PropertyName");
            AddForeignKey("dbo.Values", "SearchComponents_PropertyName", "dbo.SearchComponents", "PropertyName");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Values", "SearchComponents_PropertyName", "dbo.SearchComponents");
            DropIndex("dbo.Values", new[] { "SearchComponents_PropertyName" });
            AlterColumn("dbo.Properties", "Unit", c => c.String(nullable: false));
            DropColumn("dbo.Values", "SearchComponents_PropertyName");
            DropTable("dbo.SearchComponents");
        }
    }
}
