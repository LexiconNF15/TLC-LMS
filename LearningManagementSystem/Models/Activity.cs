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
        [Required]
        [Display (Name="Aktivitet")]
        public string ActivityName { get; set; }
        [Required]
        [Display(Name = "Beskrivning")]
        public string ActivityDescription { get; set; }
        [Required]
        [Display(Name = "Startdatum")]
        public DateTime ActivityStart { get; set; }
        [Required]
        [Display(Name = "Slutdatum")]
        public DateTime ActivityEnd { get; set; }
        [Required]
        [Display(Name = "Kursnr")]
        public int CourseId { get; set; }
        [Required]
        [Display(Name = "Aktivitetsnr")]
        public int ActivityTypeId { get; set; }
       
        public virtual ActivityType ActivityType { get; set; }
        public virtual Course Course { get; set; }


       

    }
    
}