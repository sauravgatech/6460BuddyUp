using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace GT.CS6460.BuddyUp.WebAPP.Models
{
    public class JoinACourseQuestionnaireModel
    {
        [Key]
        public string  userId {get; set;}
        public List<QuestionAndAnswerModel> questionAnswerSet;
    }

    public enum QuestionType
    {
        MultipleChoice,
        FillUpTheBlank
    }
    public class QuestionAndAnswerModel
    {
        public QuestionType QuestionType { get; set; }
        [Key]
        public string Question {get; set;}
        public string Choice1 { get; set; }
        public string Choice2 { get; set; }
        public string Choice3 { get; set; }
        public string Choice4 { get; set; }
        public string Answer { get; set; }
    }

    
    public class CreateCourseModel
    {
        [Required]
        [Display(Name = "Course Code")]
        [StringLength(24, ErrorMessage = "The Course Code must be less than 24 characters long.")]
        public string CourseCode { get; set; }

        [Display(Name = "Course Name")]
        [Required]
        [StringLength(128, ErrorMessage = "The Course Name must be less than 128 characters long.")]
        public string CourseName { get; set; }

        [Display(Name = "Group Type")]
        public string GroupType { get; set; }

        [Display(Name = "Preferred Group Size")]
        public int GroupSize { get; set; }

        [Display(Name = "Desired Skill Sets", Description= "Comma separated list of skill sets which would be helpful for group formation.")]
        public string DesiredSkillSets { get; set; }

        [Display(Name = "Create Group with Similar Skill Sets")]
        public bool PreferSimiliarSkillSet { get; set; }

        [Display(Name = "List of Teachers", Description = "Comma separated list of teachers who would be added to course.")]
        public string Teachers { get; set; }

        [Display(Name = "List of TAs", Description = "Comma separated list of TAs who would be added to course.")]
        public string TAs { get; set; }
    }

    public class CourseUser
    {
        [Display(Name="Email ID")]
        public string emailId { get; set; }

        [Display(Name = "User Role")]
        public Role role { get; set; }
    }
}