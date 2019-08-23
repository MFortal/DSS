namespace DSS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIsEnum : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Properties", "IsEnum", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Properties", "IsEnum");
        }
    }
}
