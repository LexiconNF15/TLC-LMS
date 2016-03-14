using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LearningManagementSystem.Models
{
    public class Group : IValidatableObject
    {
        public int GroupId { get; set; }
        [Required]
        [Display(Name= "Gruppnamn")]
        public string GroupName { get; set; }
        [Required]
        [Display(Name = "Beskrivning")]
        public string GroupDescription { get; set; }
        [Required]
        [Display(Name = "Startdatum")]
        //[DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0: yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy/MM/dd}")]
        public DateTime GroupStart { get; set; }
        [Required]
        [Display(Name = "Slutdatum")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy/MM/dd}")]
        public DateTime? GroupEnd { get; set; }

        ///navigation

        public virtual ICollection<Course> Courses { get; set; }

        public virtual ICollection<ApplicationUser> Users { get; set; }

        public virtual ICollection<Document> Documents { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (GroupEnd < GroupStart)
            {
                yield return new ValidationResult("Slutdatum måste vara senare än startdatum!");
            }
            if (GroupStart <= DateTime.Now)
            {
                yield return new ValidationResult("Startdatum har passerat!");
            }
        }
       
        ///
    }
        
}