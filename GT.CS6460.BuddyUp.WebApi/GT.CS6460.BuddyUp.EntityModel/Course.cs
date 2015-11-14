using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GT.CS6460.BuddyUp.EntityModel
{
    public partial class Course : AuditBase
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CourseId { get; set; }

        [StringLength(24)]
        public string CourseCode { get; set; }

        [StringLength(128)]
        public string CourseName { get; set; }

        [ForeignKey("Questionnaire")]
        public int? QuestionnaireId { get; set; }

        public virtual Questionnaire Questionnaire { get; set; }

        public virtual ICollection<CourseUserRole> CourseUserRoles { get; set; }
    }
}
