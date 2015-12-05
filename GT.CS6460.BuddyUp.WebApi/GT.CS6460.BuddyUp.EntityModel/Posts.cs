using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GT.CS6460.BuddyUp.EntityModel
{
    public partial class Post : AuditBase
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PostId { get; set; }

        [StringLength(512)]
        public string PostText { get; set; }
        
        [StringLength(32)]
        public string UserName { get; set; }

        public DateTime TimePosted { get; set; }

        public int? ParentId { get; set; }

        [ForeignKey("Group")]
        public int GroupId { get; set; }

        public virtual Group Group { get; set; }
    }
}
