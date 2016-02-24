using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LearningManagementSystem.Models
{
    public class ActivityType
    {
        public int ActivityTypeId { get; set; }
        public string ActivityTypeName { get; set; }

        public virtual ICollection<Activity> Activity { get; set; }

        
     }
    
}