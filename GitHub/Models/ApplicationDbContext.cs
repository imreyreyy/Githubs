using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace GitHub.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Gigs> Gigs { get; set; }

        public DbSet<Genre> Genre { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}