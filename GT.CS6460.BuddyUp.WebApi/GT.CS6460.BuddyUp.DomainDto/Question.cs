using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GT.CS6460.BuddyUp.DomainDto
{
    /// <summary>
    /// Question Class
    /// </summary>
    public class Question
    {
        /// <summary>
        /// Question Code
        /// </summary>
        public string questionCode { get; set; }
        /// <summary>
        /// Question Text
        /// </summary>
        [Required(ErrorMessage="QuestionText is required"), StringLength(128, ErrorMessage="String length can not be greater than 128 characters")]
        public string questionText { get; set; }

        /// <summary>
        /// Type of Question - MultipleChoice / FillUpTheBlank
        /// </summary>
        public string questionType { get; set; }

        /// <summary>
        /// List of Answer Choices
        /// </summary>
        public virtual List<string> answerChoices { get; set; }
    }
}
