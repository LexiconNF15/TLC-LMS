using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LearningManagementSystem.Models
{
    public class Activity
    {
        public int ActivityId { get; set; }
        public string ActivityName { get; set; }
        public string ActivityDescription { get; set; }
        public DateTime ActivityStart { get; set; }
        public DateTime? ActivityEnd { get; set; }
        public int CourseId { get; set; }
        public int TypeId { get; set; }
       
        public virtual Type Type { get; set; }
        public virtual Course Course { get; set; }


       

    }
    
}