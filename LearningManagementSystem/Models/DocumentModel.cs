using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LearningManagementSystem.Models
{
    public class Document
    {
        public int DocumentId { get; set; }
        [StringLength(255)]
        public string DocumentName { get; set; }
        //public FileType FileType { get; set; }
        public string Description { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }

        public string UploaderId { get; set; }
        public DateTime UploadDate { get; set; }
       
        public int? GroupId { get; set; }
        public int? CourseId { get; set; }
        public int? ActivityId { get; set; }

    
        [ForeignKey("UploaderId")]
        public virtual ApplicationUser Uploader { get; set; }

       
    }
}