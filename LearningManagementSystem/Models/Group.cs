using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LearningManagementSystem.Models
{
    public class Group
    {
        public int GroupId { get; set; }
        [Display(Name= "Gruppnamn")]
        public string GroupName { get; set; }
        [Display(Name = "Beskrivning")]
        public string GroupDescription { get; set; }
        [Display(Name = "Startdatum")]
        public DateTime GroupStart { get; set; }
        [Display(Name = "Slutdatum")]
        public DateTime? GroupEnd { get; set; }

        ///navigation

        public virtual ICollection<Course> Courses { get; set; }

        public virtual ICollection<ApplicationUser> Users { get; set; }

       
        ///
    }
        
}