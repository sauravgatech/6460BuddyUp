using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GT.CS6460.BuddyUp.EntityModel.BuddyUpDb
{
    public partial class CourseUserRole : AuditBase
    {
        [Key, ForeignKey("Course")]
        public int RoleId { get; set; }

        [Key, ForeignKey("UserProfile")]
        public int UserId { get; set; }

        [Key, ForeignKey("Role")]
        public int CourseId { get; set; }


    }
}
