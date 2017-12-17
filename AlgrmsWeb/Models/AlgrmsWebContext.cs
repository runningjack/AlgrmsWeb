using AlgrmsWeb.DatabaseInitializer;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AlgrmsWeb.Models
{

    //DbContext
    public class AlgrmsWebContext : IdentityDbContext<ApplicationUser, ApplicationRole, int, ApplicationUserLogin, ApplicationUserRole, ApplicationUserClaim>
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx

        public DbSet<PERMISSION> PERMISSIONS { get; set; }

        public AlgrmsWebContext() : base("name=AlgrmsWebContext")
        {
            Database.SetInitializer<AlgrmsWebContext>(new RBACDatabaseInitializer());
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<AlgrmsWebContext,Migrations.Configuration>("AlgrmsWebContext"));
        }

        public static AlgrmsWebContext Create()
        {
            return new AlgrmsWebContext();
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ApplicationUser>().ToTable("USERS").Property(p => p.Id).HasColumnName("UserId");
            modelBuilder.Entity<ApplicationRole>().ToTable("ROLES").Property(p => p.Id).HasColumnName("RoleId");
            modelBuilder.Entity<ApplicationUserRole>().ToTable("LNK_USER_ROLE");

            modelBuilder.Entity<ApplicationRole>().
            HasMany(c => c.PERMISSIONS).
            WithMany(p => p.ROLES).
            Map(
                m =>
                {
                    m.MapLeftKey("RoleId");
                    m.MapRightKey("PermissionId");
                    m.ToTable("LNK_ROLE_PERMISSION");
                });
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
        public System.Data.Entity.DbSet<AlgrmsWeb.Models.RevenueCharge> RevenueCharges { get; set; }
    }
}
