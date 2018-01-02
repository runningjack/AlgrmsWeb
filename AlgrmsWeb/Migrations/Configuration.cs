using AlgrmsWeb.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace AlgrmsWeb.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<Models.AlgrmsWebContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Models.AlgrmsWebContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //


            context.Countries.AddOrUpdate(
                c=> c.country_id, new Country { country_id = 156,iso_code_3 = "",country_name = "", created_at = DateTime.Now, phone_code=234, updated_at =DateTime.Now,
            });
            context.Zones.AddOrUpdate(
                z => z.zone_id,
                new Zone {country_id = 156, state_name = "Lagos",code="LG" },
                new Zone {country_id = 156, state_name = "Ogun", code = "OG" },
                new Zone {country_id = 156, state_name = "Abuja", code = "FCT" },
                new Zone {country_id = 156, state_name = "ABIA", code = "AB" }
                );
            context.TaxCategories.AddOrUpdate(
                t=>t.category_code,new TaxCategory {category_code = "1000",title = "Permit", description ="Revenue category for license or permit", created_at = DateTime.Now, updated_at = DateTime.Now },
                new TaxCategory { category_code = "2000", title = "Rate", description = "Revenue category for rate", created_at = DateTime.Now, updated_at = DateTime.Now },
                new TaxCategory { category_code = "3000", title = "Levy", description = "Revenue category for license or permit", created_at = DateTime.Now, updated_at = DateTime.Now }
                );
        }
    }
}