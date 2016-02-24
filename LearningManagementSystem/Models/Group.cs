using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LearningManagementSystem.Models
{
    public class Group
    {
        public int GroupId { get; set; }
        public string GroupName { get; set; }
        public string GroupDescription { get; set; }
        public DateTime GroupStart { get; set; }
        public DateTime? GroupEnd { get; set; }

        ///navigation

        public virtual ICollection<Course> Courses { get; set; }

        public virtual ICollection<ApplicationUser> Users { get; set; }

       
        ///
    }
        
}