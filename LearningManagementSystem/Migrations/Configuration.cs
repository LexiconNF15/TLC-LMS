namespace LearningManagementSystem.Migrations
{
    using LearningManagementSystem.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<LearningManagementSystem.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(LearningManagementSystem.Models.ApplicationDbContext context)
        {
            SeedGroups(context);
            SeedUsers(context);
            SeedCourses(context);
            SeedActivityTypes(context);
            SeedActivities(context);
        }

        private static void SeedActivities(LearningManagementSystem.Models.ApplicationDbContext context)
        {
            var activities = new List<Activity> {
                new Activity {
                    ActivityId = 1 ,
                    ActivityName= "DatabasModellering", 
                    ActivityDescription= "Pluralsite: EF6 med Scott Allen",
                    ActivityStart=DateTime.Parse("2016-04-01"),
                    ActivityEnd=DateTime.Parse("2016-08-31"),
                    CourseId = 1,
                    ActivityTypeId = 1},
                    new Activity {
                    ActivityId = 1 ,
                    ActivityName= "C# Collections", 
                    ActivityDescription= "Pluralsite :Collections med Scott Allen",
                    ActivityStart=DateTime.Parse("2016-02-28"),
                    ActivityEnd=DateTime.Parse("2016-03-14"),
                    CourseId = 1,
                    ActivityTypeId = 1},
                    new Activity {
                    ActivityId = 2 ,
                    ActivityName= "JAVA Enterprise", 
                    ActivityDescription= "Collections",
                    ActivityStart=DateTime.Parse("2016-04-01"),
                    ActivityEnd=DateTime.Parse("2016-08-31"),
                    CourseId = 2,
                    ActivityTypeId = 2},


        };
            activities.ForEach(a => context.Activities.AddOrUpdate(a));
            context.SaveChanges();  //databasen uppdateras
        }

        private static void SeedActivityTypes(LearningManagementSystem.Models.ApplicationDbContext context)
        {
            var types = new List<ActivityType> {
                new ActivityType {
                    ActivityTypeId = 1 ,
                    ActivityTypeName= "E-learning"}, 
                    new ActivityType {
                    ActivityTypeId = 2 ,
                    ActivityTypeName= "F�rel�sning"}, 
                    new ActivityType {
                    ActivityTypeId = 3 ,
                    ActivityTypeName= "Code-A-Long"}, 
                    new ActivityType {
                    ActivityTypeId = 4 ,
                    ActivityTypeName= "�vning"},
                    new ActivityType {
                    ActivityTypeId = 5 ,
                    ActivityTypeName= "Inl�mningsuppgift"}, 

                };
            types.ForEach(t => context.ActivityTypes.AddOrUpdate(t));
            context.SaveChanges();  //databasen uppdateras
        }

        private static void SeedCourses(LearningManagementSystem.Models.ApplicationDbContext context)
        {
            var courses = new List<Course> {
                new Course {
                    CourseId = 1,
                    CourseName= "C# intro", 
                    CourseDescription= "Introduktion till C# grundl�ggande niv�",
                    CourseStart=DateTime.Parse("2016-03-01"),
                    CourseEnd=DateTime.Parse("2016-04-15"),
                    GroupId = 1},
                new Course {
                    CourseId = 2,
                    CourseName= "JAVA intro", 
                    CourseDescription= "Introduktion till JAVA grundl�ggande niv�",
                    CourseStart=DateTime.Parse("2016-02-25"),
                    CourseEnd=DateTime.Parse("2016-03-25"),
                    GroupId = 2},
                 new Course {
                    CourseId = 3,
                    CourseName= "Sharepoint intro", 
                    CourseDescription= "Introduktion till SHarepoint grundl�ggande niv�",
                    CourseStart=DateTime.Parse("2016-03-01"),
                    CourseEnd=DateTime.Parse("2016-05-31"),
                    GroupId = 3},
                new Course {
                    CourseId = 4,
                    CourseName= "JAVA intro", 
                    CourseDescription= "Introduktion till JAVA p�byggnads niv�",
                    CourseStart=DateTime.Parse("2016-03-01"),
                    CourseEnd=DateTime.Parse("2016-04-24"),
                    GroupId = 2},
                 new Course {
                    CourseId = 5,
                    CourseName= "Sharepoint intro", 
                    CourseDescription= "Introduktion till Sharepoint p�byggnads niv�",
                    CourseStart=DateTime.Parse("2016-04-01"),
                    CourseEnd=DateTime.Parse("2016-08-31"),
                    GroupId = 3},
                              
             };
            courses.ForEach(c => context.Courses.AddOrUpdate(c));
            context.SaveChanges();  //databasen uppdateras
        }

        private static void SeedGroups(LearningManagementSystem.Models.ApplicationDbContext context)
        {



            var groups = new List<Group> {
                new Group {
                    GroupId = 1,
                    GroupName= ".NET Februari",
                    GroupDescription = "En kurs inneh�llande .Net, C# och Angular JS.", 
                    GroupStart=DateTime.Parse("2016-02-24"),
                    GroupEnd=DateTime.Parse("2016-03-24")},
                new Group {
                    GroupId = 2,
                    GroupName= "JAVA Februari",
                    GroupDescription = "En kurs inneh�llande JAVA Enterprise, JavaScript, Oracle.", 
                    GroupStart=DateTime.Parse("2016-02-24"),
                    GroupEnd=DateTime.Parse("2016-04-24")},
                new Group {
                    GroupId = 3,
                    GroupName= "IT-Tekniker Mars",
                    GroupDescription = "En kurs inneh�llande Sharepoint, Office365. ITIL.", 
                    GroupStart=DateTime.Parse("2016-03-01"),
                    GroupEnd=DateTime.Parse("2016-08-31")}                  
                     
            };

            groups.ForEach(g => context.Groups.AddOrUpdate(g));
            context.SaveChanges();  //databasen uppdateras
        }

        private static void SeedUsers(LearningManagementSystem.Models.ApplicationDbContext context)
        {
            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStore);

            var users = new List<ApplicationUser> {
                new ApplicationUser { 
                    UserName = "admin@lexicon.se", 
                    Email = "admin@lexicon.se", 
                    GroupId = 1, 
                    FirstName = "Anna", 
                    LastName = "Andersson",
                },  
                new ApplicationUser { 
                    UserName = "user@mail.com", 
                    Email = "user@mail.com", 
                    GroupId = 1, 
                    FirstName = "Ulrika",
                    LastName = "Svensson",
                },
                new ApplicationUser { 
                    UserName = "student@mail.com",
                    Email = "student@mail.com",
                    GroupId = 2, 
                    FirstName = "Sven", 
                    LastName = "Andersson"
                } ,
                new ApplicationUser { 
                    UserName = "student1@mail.com",
                    Email = "student1@mail.com",
                    GroupId = 2, 
                    FirstName = "Olle", 
                    LastName = "Person"
                } ,
                new ApplicationUser { 
                    UserName = "student2@mail.com",
                    Email = "student2@mail.com",
                    GroupId = 2, 
                    FirstName = "Anna", 
                    LastName = "Svensson"
                } ,
                new ApplicationUser { 
                    UserName = "student3@mail.com",
                    Email = "student3@mail.com",
                    GroupId = 2, 
                    FirstName = "Lee", 
                    LastName = "Stevenson"
                } 


            };

            foreach (var u in users)
            {
                userManager.Create(u, "foobar1");
            }
        }

    }
}

