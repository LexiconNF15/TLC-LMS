using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LearningManagementSystem.Models
{
    public class Course : IValidatableObject
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

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (CourseEnd < CourseStart)
            {
                yield return new ValidationResult("Slutdatum måste vara senare än startdatum!");
            }
            if (CourseStart <= DateTime.Now)
            {
                yield return new ValidationResult("Startdatum har passerat!");
            }
            //if (Group != null)
            //{
                //if (Group.GroupStart != null)
                //{
                //    if (Group.GroupEnd != null)
                //    {
                        //if (CourseStart < Group.GroupStart || CourseEnd > Group.GroupEnd) //Går ej efterson man väljer grupp efter datum...
                        //{
                        //    yield return new ValidationResult("Kursdatum ligger utanför tidsperioden för gruppen!");
                        //}
                //    }
                //}
            //}
        }

    }
}