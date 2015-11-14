using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GT.CS6460.BuddyUp.EntityModel
{
    public partial class Role : AuditBase
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RoleId { get; set; }

        [StringLength(24)]
        public String RoleCode { get; set; }

        [StringLength(128)]
        public string RoleDescription { get; set; }

        public virtual ICollection<CourseUserRole> CourseUserRoles { get; set; }

    }
}
