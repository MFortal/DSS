using DSS.Common;
using DSS.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;

namespace DSS.SourceSeed
{
    public static class UsersRolesInitializer
    {      
        public static void Initialize(ApplicationDbContext db)
        {            
            var roleStore = new RoleStore<IdentityRole>(db);
            var roleManager = new RoleManager<IdentityRole>(roleStore);

            var identityRoles = new List<IdentityRole>();
            identityRoles.Add(new IdentityRole() { Name = DefaultRoles.Admin});
            identityRoles.Add(new IdentityRole() { Name = DefaultRoles.User });

            foreach (IdentityRole role in identityRoles)
            {
                if (!roleManager.RoleExists(role.Name))
                {
                    roleManager.Create(role);
                }                
            }

            // Initialize default user
            var userStore = new UserStore<ApplicationUser>(db);
            var userManager = new UserManager<ApplicationUser>(userStore);
            ApplicationUser admin = new ApplicationUser
            {
                UserName = "admin@admin.com",
                Email = "admin@admin.com"
            };            
            if (userManager.FindByName(admin.UserName) == null)
            {
                userManager.Create(admin, "1Admin!");
                userManager.AddToRole(admin.Id, DefaultRoles.Admin);
            }                       
        }
    }
}