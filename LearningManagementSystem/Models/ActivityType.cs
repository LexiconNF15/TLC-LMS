using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LearningManagementSystem.Models
{
    public class ActivityType
    {
        public int ActivityTypeId { get; set; }
        [Display(Name = "Aktivitetstyp")]
        public string ActivityTypeName { get; set; }

        public virtual ICollection<Activity> Activity { get; set; }

        
     }
    
}