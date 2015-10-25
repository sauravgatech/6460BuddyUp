using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GT.CS6460.BuddyUp.EntityModel.BuddyUpDb
{
    public partial class Course : AuditBase
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CourseId { get; set; }

        [StringLength(24)]
        public int CourseCode { get; set; }

        [StringLength(128)]
        public string CourseName { get; set; }



    }
}
