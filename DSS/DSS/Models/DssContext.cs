﻿using System.Data.Entity;

namespace DSS.Models
{
    public class DssContext : DbContext
    {
        public DssContext() : base("DssContext")
        {
        }

        public DbSet<Cell> Cells { get; set; }
        public DbSet<Component> Components { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Property> Properties { get; set; }
        public DbSet<Subcategory> Subcategories { get; set; }
        public DbSet<SubcategoryProperty> SubcategoryProperties { get; set; }
        public DbSet<Value> Values { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cell>().HasIndex(x => new { x.ComponentId, x.PropertyId }).IsUnique();
        }

        public System.Data.Entity.DbSet<DSS.Models.SearchComponents> SearchComponents { get; set; }
    }
}