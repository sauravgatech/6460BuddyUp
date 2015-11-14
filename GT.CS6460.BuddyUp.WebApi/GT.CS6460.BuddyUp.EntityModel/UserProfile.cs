using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GT.CS6460.BuddyUp.EntityModel
{
    public partial class UserProfile : AuditBase
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }

        [Index(IsUnique=true), StringLength(128)]
        public string EmailId { get; set; }

        [StringLength(128)]
        public string HashedPassword { get; set; }

        public DateTime LastPasswordChangeDate { get; set; }
        
        public bool? PasswordExpired { get; set; }

        [StringLength(128)]
        public string SecurityQuestion { get; set; }

        [StringLength(128)]
        public string HashedAnswer { get; set; }

        [StringLength(64)]
        public string FirstName { get; set; }

        [StringLength(64)]
        public string LastName { get; set; }

        public bool? isAdmin { get; set; }

        public virtual ICollection<CourseUserRole> CourseUserRoles { get; set; }

        public virtual ICollection<SessionToken> SessionTokens { get; set; }

    }
}
