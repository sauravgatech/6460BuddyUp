using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GT.CS6460.BuddyUp.DomainDto
{
    /// <summary>
    /// Course Get Response
    /// </summary>
    public class CourseGetResponse
    {
        /// <summary>
        /// Course Code
        /// </summary>
        public string CourseCode { get; set; }

        /// <summary>
        /// Course Name
        /// </summary>
        public string CourseName { get; set; }

        /// <summary>
        /// Questionnaire
        /// </summary>
       public Questionnaire Questionnaire { get; set; }
       
        /// <summary>
        /// List of Users
        /// </summary>
       public List<UserGetResponse> Users { get; set; }
    }
}
