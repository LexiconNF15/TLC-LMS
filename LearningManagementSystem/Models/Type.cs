using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LearningManagementSystem.Models
{
    public class Type
    {
        public int TypeId { get; set; }
        public string TypeName { get; set; }

        public virtual ICollection<Activity> Activity { get; set; }

        
     }
    
}