using System.Collections.Generic;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace EliteGym.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public string UserType { get; set; }
        //public virtual ICollection<GetMembership> GetMemberships { get; set; }

        public virtual ICollection<Reservation> Reservations { get; set; }


        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<EliteGym.Models.Facility> Facilities { get; set; }

        public System.Data.Entity.DbSet<EliteGym.Models.RoleViewModel> RoleViewModels { get; set; }

        public System.Data.Entity.DbSet<EliteGym.Models.Trainer> Trainers { get; set; }

        public System.Data.Entity.DbSet<EliteGym.Models.Membership> Memberships { get; set; }

        public System.Data.Entity.DbSet<EliteGym.Models.Reservation> Reservations { get; set; }

        public System.Data.Entity.DbSet<EliteGym.Models.Review> Reviews { get; set; }

        //public System.Data.Entity.DbSet<EliteGym.Models.ApplicationUser> ApplicationUsers { get; set; }

        //public System.Data.Entity.DbSet<EliteGym.Models.GetMembership> GetMemberships { get; set; }

        //public System.Data.Entity.DbSet<EliteGym.Models.ApplicationUser> ApplicationUsers { get; set; }

    }
}