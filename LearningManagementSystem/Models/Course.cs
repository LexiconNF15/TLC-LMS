using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LearningManagementSystem.Models
{
    public class Course
    {

        public int CourseId { get; set; }
        [Display(Name="Kursnamn")]
        public string CourseName { get; set; }
        [Display(Name = "Beskrivning")]
        public string CourseDescription { get; set; }
        [Display(Name = "Startdatum")]
        public DateTime CourseStart { get; set; }
        [Display(Name = "Slutdatum")]
        public DateTime? CourseEnd { get; set; }

        [Display(Name = "Grupp Id")]
        public int GroupId { get; set; }

        public virtual ICollection<Activity> Activities { get; set; }
        public virtual Group Group { get; set;  }

    }
}