using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LearningManagementSystem.Models
{
    public class Activity
    {
        public int ActivityId { get; set; }
         [Display (Name="Aktivitet")]
        public string ActivityName { get; set; }
         [Display(Name = "Beskrivning")]
        public string ActivityDescription { get; set; }
         [Display(Name = "Startdatum")]
        public DateTime ActivityStart { get; set; }
         [Display(Name = "Slutdatum")]
        public DateTime? ActivityEnd { get; set; }
         [Display(Name = "Id för kurs")]
        public int CourseId { get; set; }
         [Display(Name = "Id för aktivitetstyp")]
        public int ActivityTypeId { get; set; }
       
        public virtual ActivityType ActivityType { get; set; }
        public virtual Course Course { get; set; }


       

    }
    
}