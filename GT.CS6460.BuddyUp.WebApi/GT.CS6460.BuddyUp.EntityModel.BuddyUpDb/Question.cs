using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GT.CS6460.BuddyUp.EntityModel.BuddyUpDb
{
    public partial class Question : AuditBase
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int QuestionId { get; set; }

        [StringLength(128)]
        public string Question { get; set; }

        [ForeignKey("QuestionType")]
        public int QuestionTypeId { get; set; }
    }
}
