namespace DSS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DropSearchComponentModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Values", "SearchComponents_PropertyName", "dbo.SearchComponents");
            DropIndex("dbo.Values", new[] { "SearchComponents_PropertyName" });
            DropColumn("dbo.Values", "SearchComponents_PropertyName");
            DropTable("dbo.SearchComponents");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.SearchComponents",
                c => new
                    {
                        PropertyName = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.PropertyName);
            
            AddColumn("dbo.Values", "SearchComponents_PropertyName", c => c.String(maxLength: 128));
            CreateIndex("dbo.Values", "SearchComponents_PropertyName");
            AddForeignKey("dbo.Values", "SearchComponents_PropertyName", "dbo.SearchComponents", "PropertyName");
        }
    }
}
