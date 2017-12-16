using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AlgrmsWeb.Models
{
    public class AlgrmsWebContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public AlgrmsWebContext() : base("name=AlgrmsWebContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<AlgrmsWebContext,Migrations.Configuration>("AlgrmsWebContext"));
        }

        public System.Data.Entity.DbSet<AlgrmsWeb.Models.TaxCategory> TaxCategories { get; set; }

        public System.Data.Entity.DbSet<AlgrmsWeb.Models.Issuer> Issuers { get; set; }

        public System.Data.Entity.DbSet<AlgrmsWeb.Models.TaxAgent> TaxAgents { get; set; }

        public System.Data.Entity.DbSet<AlgrmsWeb.Models.TaxRegion> TaxRegions { get; set; }

        public System.Data.Entity.DbSet<AlgrmsWeb.Models.TaxForce> TaxForces { get; set; }
        public System.Data.Entity.DbSet<AlgrmsWeb.Models.Zone> Zones { get; set; }
        public System.Data.Entity.DbSet<AlgrmsWeb.Models.Country> Countries { get; set; }
        public System.Data.Entity.DbSet<AlgrmsWeb.Models.Receptor> Receptors { get; set; }
        public System.Data.Entity.DbSet<AlgrmsWeb.Models.Revenue> Revenues { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            //base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<Country>()
            //.HasMany(c => c.Zones)
            
            //.Map(m =>
            //{
            //    m.ToTable("Zones");
            //    m.MapLeftKey("country_id");
            //    m.MapRightKey("zone_id");
            //});
        }

        public System.Data.Entity.DbSet<AlgrmsWeb.Models.RevenueCharge> RevenueCharges { get; set; }
    }
}
