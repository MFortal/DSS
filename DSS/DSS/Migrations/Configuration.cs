namespace DSS.Migrations
{
    using DSS.Models;
    using DSS.SourceSeed;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<DssContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DssContext context)
        {
            context.Categories.AddOrUpdate(CategoriesInitializer.Initialize());
            context.Subcategories.AddOrUpdate(SubcategoriesInitializer.Initialize());

            context.SaveChanges();
        }
    }
}
