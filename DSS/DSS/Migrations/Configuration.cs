namespace DSS.Migrations
{
    using Models;
    using SourceSeed;
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
            context.Countries.AddOrUpdate(CountriesInitializer.Initialize());
            context.Components.AddOrUpdate(ComponentsInitializer.Initialize());
            context.Properties.AddOrUpdate(PropertiesInitializer.Initialize());
            context.SubcategoryProperties.AddOrUpdate(SubcategoryPropertiesInitializer.Initialize());
            context.Values.AddOrUpdate(ValuesInitializer.Initialize());

            context.SaveChanges();
            context.Cells.AddOrUpdate(CellsInitializer.Initialize(context));       
            context.SaveChanges();
        }
    }
}
