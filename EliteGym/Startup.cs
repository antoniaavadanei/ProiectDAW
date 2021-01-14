using EliteGym.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using System;

[assembly: OwinStartupAttribute(typeof(EliteGym.Startup))]
namespace EliteGym
{
    public partial class Startup
    {
        ApplicationDbContext db = new ApplicationDbContext();
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateDefaultRolesAndUsers();
        }
        public void CreateDefaultRolesAndUsers()
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            IdentityRole role = new IdentityRole();
            if (!roleManager.RoleExists("Administrator"))
            {
                role.Name = "Administrator";
                roleManager.Create(role);

                ApplicationUser user = new ApplicationUser();
                user.UserName = "John";
                user.Email = "john@gmail.com";

                var Check = userManager.Create(user, "John2021");
                if(Check.Succeeded)
                {
                    userManager.AddToRole(user.Id, "Administrator");
                }
                else 
                {
                    var e = new Exception("Could not add Default User");

                    var enumerator = Check.Errors.GetEnumerator();
                    foreach(var error in Check.Errors)
                    {
                        e.Data.Add(enumerator.Current, error);
                    }
                    throw e;
                }
            }
 
        }
    }
}
