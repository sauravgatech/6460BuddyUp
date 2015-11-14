﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GT.CS6460.BuddyUp.DomainDto
{
    /// <summary>
    /// Request DTO to update user
    /// </summary>
    public class UserUpdateRequest
    {
        /// <summary>
        /// Email Id of the user to be updated
        /// </summary>
        [Required(ErrorMessage = "Email Id can not be null or empty"), StringLength(128, ErrorMessage = "Email ID can not be greater than 128 characters")]
        public string emailId { get; set; }

        /// <summary>
        /// First Name of user
        /// </summary>
        [StringLength(64, ErrorMessage = "firstName can not be greater than 64 characters")]
        public string firstName { get; set; }

        /// <summary>
        /// Last Name of the user
        /// </summary>
        [StringLength(128, ErrorMessage = "lastName can not be greater than 64 characters")]
        public string lastName { get; set; }
    }
}