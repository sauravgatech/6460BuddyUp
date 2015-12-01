using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GT.CS6460.BuddyUp.DomainDto
{
    public class GroupGetResponse
    {
        /// <summary>
        /// Group Code
        /// </summary>
        public string GroupCode { get; set; }

        /// <summary>
        /// Name of Group
        /// </summary>
        public string GroupName { get; set; }

        /// <summary>
        /// Group Type Code
        /// </summary>
        public string GroupTypeCode { get; set; }

        /// <summary>
        /// Group Objective
        /// </summary>
        public string Objective { get; set; }

        /// <summary>
        /// Timezone in which group would be most active
        /// </summary>
        public string TimeZone { get; set; }

        /// <summary>
        /// Course in which group exist
        /// </summary>
        public string CourseCode { get; set; }

        /// <summary>
        /// List of users of group
        /// </summary>
        public List<string> UserList { get; set; }
    }
}
