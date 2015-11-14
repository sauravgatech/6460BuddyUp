using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GT.CS6460.BuddyUp.DomainDto
{
    /// <summary>
    /// Course update request
    /// </summary>
    public class CourseUpdateRequest
    {
        /// <summary>
        /// Course Code
        /// </summary>
        [Required(ErrorMessage = "Course Code is required"), StringLength(24, ErrorMessage = "Course Code can not be greater than 24 characters.")]
        public string CourseCode { get; set; }

        /// <summary>
        /// Course Name
        /// </summary>
        [StringLength(128, ErrorMessage = "CourseName can not be greater than 128 characters.")]
        public string CourseName { get; set; }

        /// <summary>
        /// Questionnaire
        /// </summary>
        public Questionnaire Questionnaire { get; set; }

    }
}
