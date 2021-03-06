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
                    ActivityId = 1,
                    ActivityName= "DatabasModellering", 
                    ActivityDescription= "Pluralsite: EF6 med Scott Allen",
                    ActivityStart=DateTime.Parse("2016-04-01"),
                    ActivityEnd=DateTime.Parse("2016-05-10"),
                    CourseId = 1,
                    ActivityTypeId = 1},
                    new Activity {
                    ActivityId = 2,
                    ActivityName= "C# Collections", 
                    ActivityDescription= "Pluralsite :Collections med Scott Allen",
                    ActivityStart=DateTime.Parse("2016-03-25"),
                    ActivityEnd=DateTime.Parse("2016-03-30"),
                    CourseId = 1,
                    ActivityTypeId = 3},
                    new Activity {
                    ActivityId = 3,
                    ActivityName= "JAVA Enterprise", 
                    ActivityDescription= "Collections",
                    ActivityStart=DateTime.Parse("2016-04-01"),
                    ActivityEnd=DateTime.Parse("2016-05-10"),
                    CourseId = 2,
                    ActivityTypeId = 2}, 
                    new Activity {
                    ActivityId = 4,
                    ActivityName= "AngularJS intro", 
                    ActivityDescription= "Pluralsite : Basic AngularJS Simon Ward",
                    ActivityStart=DateTime.Parse("2016-04-11"),
                    ActivityEnd=DateTime.Parse("2016-04-15"),
                    CourseId = 1,
                    ActivityTypeId = 3},
                    new Activity {
                    ActivityId = 5,
                    ActivityName= "JAVA Netbeans", 
                    ActivityDescription= "Use NetBeans",
                    ActivityStart=DateTime.Parse("2016-05-11"),
                    ActivityEnd=DateTime.Parse("2016-06-14"),
                    CourseId = 2,
                    ActivityTypeId = 1},
                    new Activity {
                    ActivityId = 6,
                    ActivityName= "Razor Fundamentals", 
                    ActivityDescription= "CodeSchool : Rapid development with Razor",
                    ActivityStart=DateTime.Parse("2016-04-16"),
                    ActivityEnd=DateTime.Parse("2016-05-14"),
                    CourseId = 1,
                    ActivityTypeId = 1},
                    new Activity {
                    ActivityId = 7,
                    ActivityName= "JAVA Projekt", 
                    ActivityDescription= "Create consoleprojekt for Airfarebookings",
                    ActivityStart=DateTime.Parse("2016-06-15"),
                    ActivityEnd=DateTime.Parse("2016-07-12"),
                    CourseId = 2,
                    ActivityTypeId = 4},
                    new Activity {
                    ActivityId = 8,
                    ActivityName= "Sharepoint Fundamentals", 
                    ActivityDescription= "CodeSchool : Sharepoint at first glance",
                    ActivityStart=DateTime.Parse("2016-04-05"),
                    ActivityEnd=DateTime.Parse("2016-05-30"),
                    CourseId = 3,
                    ActivityTypeId = 1},
                    new Activity {
                    ActivityId = 9,
                    ActivityName= "ITIL", 
                    ActivityDescription= "ITIL certifieringstest",
                    ActivityStart=DateTime.Parse("2016-07-15"),
                    ActivityEnd=DateTime.Parse("2016-07-19"),
                    CourseId = 3,
                    ActivityTypeId = 4},


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
                    ActivityTypeName= "Föreläsning"}, 
                    new ActivityType {
                    ActivityTypeId = 3 ,
                    ActivityTypeName= "Code-A-Long"}, 
                    new ActivityType {
                    ActivityTypeId = 4 ,
                    ActivityTypeName= "Övning"},
                    new ActivityType {
                    ActivityTypeId = 5 ,
                    ActivityTypeName= "Inlämningsuppgift"}, 

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
                    CourseDescription= "Introduktion till C# grundläggande nivå",
                    CourseStart=DateTime.Parse("2016-03-25"),
                    CourseEnd=DateTime.Parse("2016-07-15"),
                    GroupId = 1},
                new Course {
                    CourseId = 2,
                    CourseName= "JAVA intro", 
                    CourseDescription= "Introduktion till JAVA grundläggande nivå",
                    CourseStart=DateTime.Parse("2016-03-25"),
                    CourseEnd=DateTime.Parse("2016-07-12"),
                    GroupId = 2},
                 new Course {
                    CourseId = 3,
                    CourseName= "Sharepoint intro", 
                    CourseDescription= "Introduktion till Sharepoint grundläggande nivå",
                    CourseStart=DateTime.Parse("2016-04-01"),
                    CourseEnd=DateTime.Parse("2016-07-30"),
                    GroupId = 4},
                new Course {
                    CourseId = 4,
                    CourseName= "JAVA Fortsättning", 
                    CourseDescription= "Introduktion till JAVA påbyggnadsnivå",
                    CourseStart=DateTime.Parse("2016-07-17"),
                    CourseEnd=DateTime.Parse("2016-08-24"),
                    GroupId = 2},
                 new Course {
                    CourseId = 5,
                    CourseName= "Sharepoint fortsättning", 
                    CourseDescription= "Introduktion till Sharepoint påbyggnadsnivå",
                    CourseStart=DateTime.Parse("2016-08-01"),
                    CourseEnd=DateTime.Parse("2016-09-30"),
                    GroupId = 4},
                 new Course {
                    CourseId = 6,
                    CourseName= "C# fortsättning", 
                    CourseDescription= "C# fortsättnings nivå 1",
                    CourseStart=DateTime.Parse("2016-07-16"),
                    CourseEnd=DateTime.Parse("2016-08-19"),
                    GroupId = 1},
                              
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
                    GroupDescription = "Innehåller:.Net, C# och Angular JS.", 
                    GroupStart=DateTime.Parse("2016-03-24"),
                    GroupEnd=DateTime.Parse("2016-08-24")},
                new Group {
                    GroupId = 2,
                    GroupName= "JAVA Mars",
                    GroupDescription = "Innehåller:JAVA Enterprise, JavaScript, Oracle.", 
                    GroupStart=DateTime.Parse("2016-03-24"),
                    GroupEnd=DateTime.Parse("2016-08-24")},
                new Group {
                    GroupId = 3,
                    GroupName= "IT-Tekniker Mars",
                    GroupDescription = "Office365. ITIL, ISTQB Foundation", 
                    GroupStart=DateTime.Parse("2016-04-01"),
                    GroupEnd=DateTime.Parse("2016-08-31")}, 
                new Group {
                    GroupId = 4,
                    GroupName= "Sharepoint-Tekniker April",
                    GroupDescription = "Innehåller: Sharepoint, Office365, ITIL.", 
                    GroupStart=DateTime.Parse("2016-04-01"),
                    GroupEnd=DateTime.Parse("2016-09-30")},
                new Group {
                    GroupId = 5,
                    GroupName= ".NET Juni",
                    GroupDescription = "Innehåller: Sharepoint, Office365. ITIL.", 
                    GroupStart=DateTime.Parse("2016-06-01"),
                    GroupEnd=DateTime.Parse("2016-10-30")}, 
                     
            };

            groups.ForEach(g => context.Groups.AddOrUpdate(g));
            context.SaveChanges();  //databasen uppdateras
        }

        private static void SeedUsers(LearningManagementSystem.Models.ApplicationDbContext context)
        {
            var roleStore = new RoleStore<IdentityRole>(context);   //vanligtvis i controllern
            var roleManager = new RoleManager<IdentityRole>(roleStore);

            foreach (string roleName in new[] {"Teacher","Student"})
            {

                if (!context.Roles.Any(r => r.Name == roleName))
                {
                    var role = new IdentityRole { Name = roleName };
                    roleManager.Create(role);
                    // var result = roleManager.Create(role);
                }

            }
            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStore);

            var users = new List<ApplicationUser> {
                new ApplicationUser { 
                    UserName = "teacher@mail.com", 
                    Email = "teacher@mail.com", 
                    //GroupId = null, 
                    FirstName = "Ulrika",
                    LastName = "Svensson",
                },
                new ApplicationUser { 
                    UserName = "anette@mail.com", 
                    Email = "anette@mail.com", 
                    //GroupId = null, 
                    FirstName = "Anette",
                    LastName = "Gustavsson",
                },
                new ApplicationUser { 
                    UserName = "student@mail.com",
                    Email = "student@mail.com",
                    GroupId = 2, 
                    FirstName = "Sven", 
                    LastName = "Andersson",
                } ,
                new ApplicationUser { 
                    UserName = "olle@mail.com",
                    Email = "olle@mail.com",
                    GroupId = 2, 
                    FirstName = "Olle", 
                    LastName = "Person",
                } ,
                new ApplicationUser { 
                    UserName = "anna@mail.com",
                    Email = "anna@mail.com",
                    GroupId = 2, 
                    FirstName = "Anna", 
                    LastName = "Svensson",
                } ,
                new ApplicationUser { 
                    UserName = "lee@mail.com",
                    Email = "lee@mail.com",
                    GroupId = 2, 
                    FirstName = "Lee", 
                    LastName = "Stevenson"
                }  ,
                 new ApplicationUser { 
                    UserName = "adrian@mail.com",
                    Email = "adrian@mail.com",
                    GroupId = 2, 
                    FirstName = "Adrian", 
                    LastName = "Lejon",
                } ,
                new ApplicationUser { 
                    UserName = "oscar@mail.com",
                    Email = "oscar@mail.com",
                    GroupId = 1, 
                    FirstName = "Oscar", 
                    LastName = "Von Shinkel",
                } ,
                new ApplicationUser { 
                    UserName = "anders@mail.com",
                    Email = "anders@mail.com",
                    GroupId = 4, 
                    FirstName = "Anders", 
                    LastName = "Warg",
                } ,
                new ApplicationUser { 
                    UserName = "susanne@mail.com",
                    Email = "susanne@mail.com",
                    GroupId = 1, 
                    FirstName = "Susanne", 
                    LastName = "Holmgren",
                }, //
                new ApplicationUser { 
                    UserName = "ove@mail.com",
                    Email = "ove@mail.com",
                    GroupId = 2, 
                    FirstName = "Ove", 
                    LastName = "Sundeberg",
                } ,
                new ApplicationUser { 
                    UserName = "carmen@mail.com",
                    Email = "carmen@mail.com",
                    GroupId = 2, 
                    FirstName = "Carmen", 
                    LastName = "Sanchez",
                } ,
                new ApplicationUser { 
                    UserName = "bosse@mail.com",
                    Email = "bosse@mail.com",
                    GroupId = 2, 
                    FirstName = "Bo", 
                    LastName = "Albrektson"
                }  ,
                 new ApplicationUser { 
                    UserName = "klara@mail.com",
                    Email = "klara@mail.com",
                    GroupId = 2, 
                    FirstName = "Klara", 
                    LastName = "Swan",
                } ,
                new ApplicationUser { 
                    UserName = "sara@mail.com",
                    Email = "sara@mail.com",
                    GroupId = 4, 
                    FirstName = "Sara", 
                    LastName = "Af Silverstolpe",
                } ,
                new ApplicationUser { 
                    UserName = "torsten@mail.com",
                    Email = "torsten@mail.com",
                    GroupId = 4, 
                    FirstName = "Torsten", 
                    LastName = "Pample",
                } ,
                new ApplicationUser { 
                    UserName = "lenita@mail.com",
                    Email = "lenita@mail.com",
                    GroupId = 1, 
                    FirstName = "Lenita", 
                    LastName = "Gonzales",
                } 

            };

            foreach (var u in users)
            {
                userManager.Create(u, "foobar1");
            }


            var teacherUser = userManager.FindByName("teacher@mail.com");
            userManager.AddToRole(teacherUser.Id, "Teacher");

            var studentUser = userManager.FindByName("student@mail.com");
            userManager.AddToRole(studentUser.Id, "Student");

             var studentUser1 = userManager.FindByName("olle@mail.com");
            userManager.AddToRole(studentUser1.Id, "Student");

             var studentUser2 = userManager.FindByName("lee@mail.com");
            userManager.AddToRole(studentUser2.Id, "Student");

            var studentUser3 = userManager.FindByName("anna@mail.com");
            userManager.AddToRole(studentUser3.Id, "Student");

            var studentUser4 = userManager.FindByName("oscar@mail.com");
            userManager.AddToRole(studentUser4.Id, "Student");

            var studentUser5 = userManager.FindByName("adrian@mail.com");
            userManager.AddToRole(studentUser5.Id, "Student");

            var studentUser6 = userManager.FindByName("anders@mail.com");
            userManager.AddToRole(studentUser6.Id, "Student");

            var studentUser7 = userManager.FindByName("susanne@mail.com");
            userManager.AddToRole(studentUser7.Id, "Student");//

            var teacherUser1 = userManager.FindByName("anette@mail.com");
            userManager.AddToRole(teacherUser1.Id, "Teacher");

            var studentUser8 = userManager.FindByName("ove@mail.com");
            userManager.AddToRole(studentUser8.Id, "Student");

            var studentUser9 = userManager.FindByName("lenita@mail.com");
            userManager.AddToRole(studentUser9.Id, "Student");

            var studentUser10 = userManager.FindByName("bosse@mail.com");
            userManager.AddToRole(studentUser10.Id, "Student");

            var studentUser11 = userManager.FindByName("carmen@mail.com");
            userManager.AddToRole(studentUser11.Id, "Student");

            var studentUser12 = userManager.FindByName("klara@mail.com");
            userManager.AddToRole(studentUser12.Id, "Student");

            var studentUser13 = userManager.FindByName("sara@mail.com");
            userManager.AddToRole(studentUser13.Id, "Student");

            var studentUser14 = userManager.FindByName("torsten@mail.com");
            userManager.AddToRole(studentUser14.Id, "Student");

           
        }

    }
}

