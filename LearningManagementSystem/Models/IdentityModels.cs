using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

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
        public virtual ICollection<DocumentPath> UploadedDocuments { get; set; }



        //Ta bort?
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // lägg till claims
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

        public System.Data.Entity.DbSet<LearningManagementSystem.Models.DocumentPath> Documents { get; set; }

        //public System.Data.Entity.DbSet<LearningManagementSystem.Models.ApplicationUser> ApplicationUsers { get; set; }
    }
}