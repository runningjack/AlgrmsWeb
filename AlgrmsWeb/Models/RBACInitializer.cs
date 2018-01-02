namespace AlgrmsWeb.DatabaseInitializer
{
    using Microsoft.AspNet.Identity;
    using AlgrmsWeb.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Threading.Tasks;

    public class RBACDatabaseInitializer : CreateDatabaseIfNotExists<AlgrmsWebContext>
    {
        private readonly string c_SysAdmin = "System Administrator";
        private readonly string c_DefaultUser = "Default User";

        protected override void Seed(AlgrmsWebContext context)
        {
            //Create Default Roles...
            IList<ApplicationRole> defaultRoles = new List<ApplicationRole>();
            defaultRoles.Add(new ApplicationRole { Name = c_SysAdmin, RoleDescription = "Allows system administration of Users/Roles/Permissions", LastModified = DateTime.ParseExact(DateTime.Now.ToString(), "yyyy-MM-dd", null), IsSysAdmin = true });
            defaultRoles.Add(new ApplicationRole { Name = c_DefaultUser, RoleDescription = "Default role with limited permissions", LastModified = DateTime.ParseExact(DateTime.Now.ToString(), "yyyy-MM-dd", null), IsSysAdmin = false });

            ApplicationRoleManager RoleManager = new ApplicationRoleManager(new ApplicationRoleStore(context));
            foreach (ApplicationRole role in defaultRoles)
            {                
                RoleManager.Create(role);
            }              
            
            //Create User...
            var user = new ApplicationUser { UserName = "Admin", Email = "admin@somedomain.com", Firstname = "System", Lastname = "Administrator", LastModified = DateTime.ParseExact(DateTime.Now.ToString(), "yyyy-MM-dd", null), Inactive = false, EmailConfirmed = true };

            ApplicationUserManager UserManager = new ApplicationUserManager(new ApplicationUserStore(context));
            var result = UserManager.Create(user, "Pa55w0rd");

            if (result.Succeeded)
            {
                //Add User to Admin Role...
                UserManager.AddToRole(user.Id, c_SysAdmin);                
            }


            //Create Default User...
            user = new ApplicationUser { UserName = "DefaultUser", Email = "defaultuser@somedomain.com", Firstname = "Default", Lastname = "User", LastModified = DateTime.ParseExact(DateTime.Now.ToString(), "yyyy-MM-dd", null), Inactive = false, EmailConfirmed = true };
            result = UserManager.Create(user, "S4l3su53r");            

            if (result.Succeeded)
            {
                //Add User to Admin Role...
                UserManager.AddToRole(user.Id, c_DefaultUser);
            }

            //Create User with NO Roles...
            user = new ApplicationUser { UserName = "Guest", Email = "guest@somedomain.com", Firstname = "Guest", Lastname = "User", LastModified = DateTime.ParseExact(DateTime.Now.ToString(), "yyyy-MM-dd", null), Inactive = false, EmailConfirmed=true };
            result = UserManager.Create(user, "Gu3st12");
            base.Seed(context);


            context.Countries.AddOrUpdate(
               c => c.country_id, new Country
               {
                   country_id = 156,
                   iso_code_3 = "NG",
                   country_name = "Nigeria",
                   created_at = DateTime.ParseExact(DateTime.Now.ToString(), "yyyy-MM-dd", null),
                   phone_code = 234,
                   updated_at = DateTime.ParseExact(DateTime.Now.ToString(), "yyyy-MM-dd", null),
               });
            context.Zones.AddOrUpdate(
                z => z.zone_id,
                new Zone { country_id = 156, state_name = "Lagos", code = "LG" },
                new Zone { country_id = 156, state_name = "Ogun", code = "OG" },
                new Zone { country_id = 156, state_name = "Abuja", code = "FCT" },
                new Zone { country_id = 156, state_name = "ABIA", code = "AB" }
                );
            context.TaxCategories.AddOrUpdate(
                t => t.category_code, new TaxCategory { category_code = "1000", title = "Permit", description = "Revenue category for license or permit", created_at = DateTime.ParseExact(DateTime.Now.ToString(), "yyyy-MM-dd", null), updated_at = DateTime.ParseExact(DateTime.Now.ToString(), "yyyy-MM-dd", null) },
                new TaxCategory { category_code = "2000", title = "Rate", description = "Revenue category for rate", created_at = DateTime.ParseExact(DateTime.ParseExact(DateTime.Now.ToString(), "yyyy-MM-dd", null).ToString(), "yyyy-MM-dd", null), updated_at = DateTime.ParseExact(DateTime.Now.ToString(), "yyyy-MM-dd", null) },
                new TaxCategory { category_code = "3000", title = "Levy", description = "Revenue category for license or permit", created_at = DateTime.ParseExact(DateTime.Now.ToString(), "yyyy-MM-dd", null), updated_at = DateTime.ParseExact(DateTime.Now.ToString(), "yyyy-MM-dd", null) }
                );
            context.SaveChanges();
            //base.Seed(context);

            //Create a permission...
            PERMISSION _permission = new PERMISSION();
            _permission.PermissionDescription = "Home-Reports";
            ApplicationRoleManager.AddPermission(_permission);

            //Add Permission to DefaultUser Role...
            ApplicationRoleManager.AddPermission2Role(context.Roles.Where(p=>p.Name == c_DefaultUser).First().Id, context.PERMISSIONS.First().PermissionId);
        }        
    }
}
