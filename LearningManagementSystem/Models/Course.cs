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
        [Required]
        [Display(Name="Kursnamn")]
        public string CourseName { get; set; }
        [Required]
        [Display(Name = "Beskrivning")]
        public string CourseDescription { get; set; }
        [Required]
        [Display(Name = "Startdatum")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy/MM/dd}")]
        public DateTime CourseStart { get; set; }
        [Required]
        [Display(Name = "Slutdatum")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy/MM/dd}")]
        public DateTime? CourseEnd { get; set; }

        [Display(Name = "Gruppnr")]
        public int? GroupId { get; set; }

        public virtual ICollection<Activity> Activities { get; set; }
        public virtual Group Group { get; set;  }

    }
}