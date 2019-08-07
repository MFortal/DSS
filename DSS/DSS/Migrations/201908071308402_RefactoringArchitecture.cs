namespace DSS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RefactoringArchitecture : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Cells", "PropertyId", "dbo.Properties");
            DropForeignKey("dbo.Cells", "ValueId", "dbo.Values");
            DropIndex("dbo.Cells", new[] { "ComponentId", "PropertyId" });
            DropIndex("dbo.Cells", new[] { "ValueId" });
            AlterColumn("dbo.Cells", "ValueId", c => c.Int(nullable: false));
            CreateIndex("dbo.Cells", new[] { "ComponentId", "ValueId" }, unique: true);
            AddForeignKey("dbo.Cells", "ValueId", "dbo.Values", "Id", cascadeDelete: true);
            DropColumn("dbo.Cells", "PropertyId");
            DropColumn("dbo.Cells", "Value");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Cells", "Value", c => c.String());
            AddColumn("dbo.Cells", "PropertyId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Cells", "ValueId", "dbo.Values");
            DropIndex("dbo.Cells", new[] { "ComponentId", "ValueId" });
            AlterColumn("dbo.Cells", "ValueId", c => c.Int());
            CreateIndex("dbo.Cells", "ValueId");
            CreateIndex("dbo.Cells", new[] { "ComponentId", "PropertyId" }, unique: true);
            AddForeignKey("dbo.Cells", "ValueId", "dbo.Values", "Id");
            AddForeignKey("dbo.Cells", "PropertyId", "dbo.Properties", "Id", cascadeDelete: true);
        }
    }
}
