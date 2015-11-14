using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GT.CS6460.BuddyUp.EntityModel
{
    public partial class Group : AuditBase
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int GroupId { get; set; }

        public string GroupName { get; set; }

        public string Objective { get; set; }

        public string TimeZone { get; set; }

        public virtual ICollection<CourseUserRole> CourseUserRoles { get; set; }
    }
}
