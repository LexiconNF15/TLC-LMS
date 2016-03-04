﻿using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;

namespace LearningManagementSystem.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        [Display(Name = "Förnamn")]
        public string FirstName { get; set; }
        [Display(Name = "Efternamn")]
        public string LastName { get; set; }
        public int? GroupId { get; set; }

        public virtual Group Group { get; set; }


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

        public System.Data.Entity.DbSet<LearningManagementSystem.Models.Group> Groups { get; set; }

        public System.Data.Entity.DbSet<LearningManagementSystem.Models.Course> Courses { get; set; }

        public System.Data.Entity.DbSet<LearningManagementSystem.Models.Activity> Activities { get; set; }

        public System.Data.Entity.DbSet<LearningManagementSystem.Models.ActivityType> ActivityTypes { get; set; }

        //public System.Data.Entity.DbSet<LearningManagementSystem.Models.ApplicationUser> ApplicationUsers { get; set; }

        //public System.Data.Entity.DbSet<LearningManagementSystem.Models.ApplicationUser> ApplicationUsers { get; set; }

        //public System.Data.Entity.DbSet<LearningManagementSystem.Models.ApplicationUser> ApplicationUsers { get; set; }

        //public System.Data.Entity.DbSet<LearningManagementSystem.Models.ApplicationUser> ApplicationUsers { get; set; }

        //public System.Data.Entity.DbSet<LearningManagementSystem.Models.ApplicationUser> ApplicationUsers { get; set; }
    }
}