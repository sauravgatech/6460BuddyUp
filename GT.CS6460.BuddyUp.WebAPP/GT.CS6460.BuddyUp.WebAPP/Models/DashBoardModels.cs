using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GT.CS6460.BuddyUp.WebAPP.Models
{
    public enum GroupType
    {
        StudyGroup,
        ProjectGroup
    }
    public class GroupDetailModel
    {
        [Key, Required]
        [Display(Name="Group Name")]
        public string GroupName { get; set; }

        [Display(Name = "Objective")]
        public string Objective { get; set; }

        [Display(Name = "Other Group Details")]
        public OtherGroupDetailModel OtherGroupDetail { get; set; }

        public List<Post> Discussion { get; set; }
    }

    public class Comment
    {
        [Key]
        public string UserName { get; set; }
        public DateTime CommentDate { get; set; }

        public string Post { get; set; }
    }

    public class Post
    {
        [Key]
        public Comment MainPost { get; set; }
        public List<Comment> Replies { get; set; }
    }

    public class OtherGroupDetailModel
    {
        [Key, Display(Name = "Group Type")]
        public GroupType GroupType { get; set; }

        [Display(Name = "Time Zone")]
        public string TimeZone { get; set; }

        [Display(Name = "Group Members")]
        public List<GroupMembers> GroupMembers { get; set; }
    }

    public class GroupMembers
    {
        [Key]
        public string Name { get; set; }
        public string About { get; set; }
        public List<string> SkillSets { get; set; }
        public List<string> Interests { get; set; }
    }

    public class GroupSummary
    {
        [Key, Required]
        public string GroupName { get; set; }
        public string TimeZone { get; set; }
        public string Objective { get; set; }

    }
    public class GroupListModel
    {
        public List<GroupSummary> SuggestedGroups { get; set; }
        [Key, Required]
        public List<GroupSummary> AllGroups { get; set; }
    }
}