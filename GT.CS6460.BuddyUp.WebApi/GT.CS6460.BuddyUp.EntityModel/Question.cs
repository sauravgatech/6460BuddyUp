using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GT.CS6460.BuddyUp.EntityModel
{
    public partial class Question : AuditBase
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int QuestionId { get; set; }

        [StringLength(128)]
        public string QuestionText { get; set; }

        [ForeignKey("QuestionType")]
        public int QuestionTypeId { get; set; }

        public virtual QuestionType QuestionType { get; set; }

        public virtual ICollection<AnswerChoice> AnswerChoices { get; set; }
    }
}
