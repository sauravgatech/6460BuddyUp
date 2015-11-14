using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GT.CS6460.BuddyUp.EntityModel
{
    public class SessionToken
    {
        [Key]
        [StringLength(128)]
        public string Token { get; set; }
     
        public DateTime CreationTimeUtc { get; set; }
        
        public DateTime LastActivityTimeUtc { get; set; }

        public bool? HasPasswordExpired { get; set; }

        public int UserId { get; set; }
        
        [StringLength(32)]
        public string UserName { get; set; }

        [ForeignKey("UserId")]
        public virtual UserProfile User { get; set; }        
    }
}
