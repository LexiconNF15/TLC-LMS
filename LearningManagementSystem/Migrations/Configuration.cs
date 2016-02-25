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
                 LastName = "Andersson"} 

            };

                 foreach (var u in users)
	{
		  userManager.Create(u, "foobar1");
	}

           
          
           

          
                   
               

           
            var groups = new List<Group> {
                new Group {
                    GroupId = 1,
                    GroupName= ".NET Februari",
                    GroupDescription = "En kurs innehållande .Net, C# och Angular JS.", 
                    GroupStart=DateTime.Parse("2016-02-24"),
                    GroupEnd=DateTime.Parse("2016-03-24")},
                new Group {
                    GroupId = 2,
                    GroupName= "JAVA Februari",
                    GroupDescription = "En kurs innehållande JAVA Enterprise, JavaScript, Oracle.", 
                    GroupStart=DateTime.Parse("2016-02-24"),
                    GroupEnd=DateTime.Parse("2016-04-24")},
                new Group {
                    GroupId = 3,
                    GroupName= "IT-Tekniker Mars",
                    GroupDescription = "En kurs innehållande Sharepoint, Office365. ITIL.", 
                    GroupStart=DateTime.Parse("2016-03-01"),
                    GroupEnd=DateTime.Parse("2016-08-31")}                  
                     
            };

            groups.ForEach(g => context.Groups.Add(g));
            context.SaveChanges();  //databasen uppdateras

            var courses = new List<Course> {
                new Course {
                    CourseId = 1,
                    CourseName= "C# intro", 
                    CourseDescription= "Introduktion till C# grundläggande nivå",
                    CourseStart=DateTime.Parse("2016-03-01"),
                    CourseEnd=DateTime.Parse("2016-04-15"),
                    GroupId = 1},
                new Course {
                    CourseId = 2,
                    CourseName= "JAVA intro", 
                    CourseDescription= "Introduktion till JAVA grundläggande nivå",
                    CourseStart=DateTime.Parse("2016-02-25"),
                    CourseEnd=DateTime.Parse("2016-03-25"),
                    GroupId = 2},
                 new Course {
                    CourseId = 3,
                    CourseName= "Sharepoint intro", 
                    CourseDescription= "Introduktion till SHarepoint grundläggande nivå",
                    CourseStart=DateTime.Parse("2016-03-01"),
                    CourseEnd=DateTime.Parse("2016-05-31"),
                    GroupId = 3},
                new Course {
                    CourseId = 4,
                    CourseName= "JAVA intro", 
                    CourseDescription= "Introduktion till JAVA påbyggnads nivå",
                    CourseStart=DateTime.Parse("2016-03-01"),
                    CourseEnd=DateTime.Parse("2016-04-24"),
                    GroupId = 2},
                 new Course {
                    CourseId = 5,
                    CourseName= "Sharepoint intro", 
                    CourseDescription= "Introduktion till Sharepoint påbyggnads nivå",
                    CourseStart=DateTime.Parse("2016-04-01"),
                    CourseEnd=DateTime.Parse("2016-08-31"),
                    GroupId = 3},
                              
             };
            courses.ForEach(c => context.Courses.Add(c));
            context.SaveChanges();  //databasen uppdateras

            var types = new List<ActivityType> {
                new ActivityType {
                    ActivityTypeId = 1 ,
                    ActivityTypeName= "E-learning"}, 
                    new ActivityType {
                    ActivityTypeId = 2 ,
                    ActivityTypeName= "Lecture"}, 
                    new ActivityType {
                    ActivityTypeId = 3 ,
                    ActivityTypeName= "Code-A-Long"}, 
                    new ActivityType {
                    ActivityTypeId = 4 ,
                    ActivityTypeName= "Exercisee"},
                    new ActivityType {
                    ActivityTypeId = 5 ,
                    ActivityTypeName= "Assignment"}, 

                };
            types.ForEach(t => context.ActivityTypes.Add(t));
            context.SaveChanges();  //databasen uppdateras
                    

            var activities = new List<Activity> {
                new Activity {
                    ActivityId = 1 ,
                    ActivityName= "DatabasModellering", 
                    ActivityDescription= "Blablabla",
                    ActivityStart=DateTime.Parse("2016-04-01"),
                    ActivityEnd=DateTime.Parse("2016-08-31"),
                    CourseId = 1,
                    ActivityTypeId = 1},
                    new Activity {
                    ActivityId = 1 ,
                    ActivityName= "C# Collections", 
                    ActivityDescription= "Blablabla",
                    ActivityStart=DateTime.Parse("2016-02-28"),
                    ActivityEnd=DateTime.Parse("2016-03-14"),
                    CourseId = 1,
                    ActivityTypeId = 1},
                    new Activity {
                    ActivityId = 2 ,
                    ActivityName= "JAVA Enterprise", 
                    ActivityDescription= "Blablabla",
                    ActivityStart=DateTime.Parse("2016-04-01"),
                    ActivityEnd=DateTime.Parse("2016-08-31"),
                    CourseId = 2,
                    ActivityTypeId = 2},


        };
            activities.ForEach(a => context.Activities.Add(a));
            context.SaveChanges();  //databasen uppdateras
        }
    
    }
}

