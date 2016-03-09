using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LearningManagementSystem.Models
{
    public class DocumentPath
    {
        public int Id { get; set; }
        [StringLength(255)]
        public string DocumentName { get; set; }
        //public FileType FileType { get; set; }
        public string DocumentDescription { get; set; }
        public string FilePath { get; set; }
        public DateTime UploadDate { get; set; }
        public int? GroupId { get; set; }
        public int? CourseId { get; set; }
        public int? ActivityId { get; set; }

        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual ApplicationUser User { get; set; }

       
    }
}