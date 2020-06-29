﻿using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace GitHub.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Gigs> Gigs { get; set; }

        public DbSet<Genre> Genre { get; set; }

        public DbSet<Attendance> Attendance { get; set; }

        public DbSet<Relationship> Relationships { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Attendance>()
                .HasRequired(a => a.Gig)
                .WithMany()
                .WillCascadeOnDelete(false);


            modelBuilder.Entity<ApplicationUser>()
                .HasMany(u=>u.Followers)
                .WithRequired(f=>f.Followee)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ApplicationUser>()
              .HasMany(a => a.Followers)
              .WithRequired(f=>f.Follower)
              .WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);
        }
    }
}