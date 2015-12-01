using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GT.CS6460.BuddyUp.EntityModel
{
    public partial class CourseUserRole : AuditBase
    {

        [Key, ForeignKey("Role"), Column(Order = 1)]
        public int RoleId { get; set; }

        [Key, ForeignKey("UserProfile"), Column(Order = 2)]
        public int UserId { get; set; }

        [Key, ForeignKey("Course"), Column(Order = 3)]
        public int CourseId { get; set; }

        [ForeignKey("Group")]
        public int? GroupId { get; set; }

        public string AnswerSet { get; set; }

        public virtual Role Role { get; set; }

        public virtual UserProfile UserProfile { get; set; }

        public virtual Course Course { get; set; }

        public virtual Group Group { get; set; }
    }
}
