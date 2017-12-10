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
        }

        public System.Data.Entity.DbSet<AlgrmsWeb.Models.TaxCategory> TaxCategoryModels { get; set; }

        public System.Data.Entity.DbSet<AlgrmsWeb.Models.Issuer> Issuers { get; set; }

        public System.Data.Entity.DbSet<AlgrmsWeb.Models.TaxAgent> TaxAgents { get; set; }

        public System.Data.Entity.DbSet<AlgrmsWeb.Models.TaxRegion> TaxRegions { get; set; }

        public System.Data.Entity.DbSet<AlgrmsWeb.Models.TaxForce> TaxForces { get; set; }
    }
}
