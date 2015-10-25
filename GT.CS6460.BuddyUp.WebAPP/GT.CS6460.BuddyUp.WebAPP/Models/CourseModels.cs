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
}