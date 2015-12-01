using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Principal;

namespace GT.CS6460.BuddyUp.DomainDto
{
    /// <summary>
    /// Token Response after authentication
    /// </summary>
    public class Token //: IPrincipal
    {
        /// <summary>
        /// Token with the prefix "GTToken "
        /// </summary>
        public string token { get; set; }
        /// <summary>
        /// Maximum Session Time in minutes
        /// </summary>
        public int maxSessionTime { get; set; }
        /// <summary>
        /// Remaining time in the session
        /// </summary>
        public int remainingTime { get; set; }
        /// <summary>
        /// Has Password expired
        /// </summary>
        public bool passwordExpired { get; set; }
        /// <summary>
        /// Message to the user
        /// </summary>
        public string message { get; set; }

        /// <summary>
        /// User Details 
        /// </summary>
        public UserGetResponse user { get; set; }

        //public IIdentity Identity
        //{
        //    get { return user; }
        //}

        public bool IsInRole(string role)
        {
            if (null == this.user || null == this.user.UserCourseDetails) return false;
            return this.user.UserCourseDetails.Any(r => r.RoleCode.Equals(role, StringComparison.OrdinalIgnoreCase)); //== role);
        }

    }
}
