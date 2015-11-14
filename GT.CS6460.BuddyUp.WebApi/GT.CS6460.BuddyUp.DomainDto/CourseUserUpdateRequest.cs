using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GT.CS6460.BuddyUp.DomainDto
{
    /// <summary>
    /// Course User Add Request
    /// </summary>
    public class CourseUserUpdateRequest
    {
        /// <summary>
        /// Course Code
        /// </summary>
        public string courseCode { get; set; }

        /// <summary>
        /// Email Id
        /// </summary>
        public string email { get; set; }
    }
}
