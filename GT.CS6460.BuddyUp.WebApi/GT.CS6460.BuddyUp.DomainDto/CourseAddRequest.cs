using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GT.CS6460.BuddyUp.DomainDto
{
    /// <summary>
    /// Course Add Request
    /// </summary>
    public class CourseAddRequest
    {
        /// <summary>
        /// Course Code
        /// </summary>
        [Required(ErrorMessage = "Course Code is required"), StringLength(24, ErrorMessage = "Course Code can not be greater than 24 characters.")]
        public string CourseCode { get; set; }

        /// <summary>
        /// Name of Course
        /// </summary>
        [Required(ErrorMessage = "CourseName is required"), StringLength(128, ErrorMessage = "CourseName can not be greater than 128 characters.")]
        public string CourseName { get; set; }

        /// <summary>
        /// Initial Set of User; List of email id
        /// </summary>
        public List<string> userList { get; set; }
    }
}
