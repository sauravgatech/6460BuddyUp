﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GT.CS6460.BuddyUp.DomainDto
{
    /// <summary>
    /// Response when Get User API is called
    /// </summary>
    public class UserGetResponse
    {
        /// <summary>
        /// Email Id of user
        /// </summary>
        public string emailId { get; set; }

        /// <summary>
        /// First Name of User
        /// </summary>
        public string firstName { get; set; }

        /// <summary>
        /// Last Name of User
        /// </summary>
        public string lastName { get; set; }

        /// <summary>
        /// Indicates if user is admin
        /// </summary>
        public bool isAdmin {get; set;}

        /// <summary>
        /// Course details of user
        /// </summary>
        public List<UserCourseDetail> UserCourseDetails { get; set; }
    }

    /// <summary>
    /// Course Details of User
    /// </summary>
    public class UserCourseDetail
    {
        /// <summary>
        /// Code of course
        /// </summary>
        public string courseCode { get; set; }

        /// <summary>
        /// Name of Course
        /// </summary>
        public string CourseName { get; set; }

        /// <summary>
        /// Role of user in the course
        /// </summary>
        public string Role { get; set; }
    }
}