using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LearningManagementSystem.Models
{
    public class Course : IValidatableObject
    {

        public int CourseId { get; set; }
        [Required]
        [Display(Name = "Kursnamn")]
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
        public int GroupId { get; set; }

        // virtual ICollection<Activity> Activities { get; set; }

        [ForeignKey("GroupId")]
        public virtual Group Group { get; set; }
        public virtual ICollection<Activity> Activities { get; set; }

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
            if (GroupId > 0)
            {
                ApplicationDbContext db = new ApplicationDbContext();
                var CGroup = db.Groups.Where(g => g.GroupId == GroupId).FirstOrDefault();
                //if (Group.GroupStart != null)
                //{
                //    if (Group.GroupEnd != null)
                //    {

                if ((CourseStart < CGroup.GroupStart) || (CourseEnd > CGroup.GroupEnd)) //Går ej efterson man väljer grupp efter datum...
                        {
                            yield return new ValidationResult("Kursdatum ligger utanför tidsperioden för gruppen!");
                        }
                //    }
                //}
            }
        }
    }
}
