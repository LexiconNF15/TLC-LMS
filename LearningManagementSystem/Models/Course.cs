using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LearningManagementSystem.Models
{
    public class Course
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public string CourseDescription { get; set; }
        public DateTime CourseStart { get; set; }
        public DateTime? CourseEnd { get; set; }
        
        public int GroupId { get; set; }

        public virtual ICollection<Activity> Activities { get; set; }
        public virtual Group Group { get; set;  }

    }
}