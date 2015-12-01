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

        [StringLength(24)]
        public string GroupCode { get; set; }

        [StringLength(128)]
        public string GroupName { get; set; }

        [StringLength(512)]
        public string Objective { get; set; }

        [StringLength(24)]
        public string TimeZone { get; set; }

        [ForeignKey("GroupType")]
        public int GroupTypeId { get; set; }

        public virtual GroupType GroupType { get; set; }

        public virtual ICollection<CourseUserRole> CourseUserRoles { get; set; }
    }
}
