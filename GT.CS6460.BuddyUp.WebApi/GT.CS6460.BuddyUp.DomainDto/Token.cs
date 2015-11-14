using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GT.CS6460.BuddyUp.DomainDto
{
    /// <summary>
    /// Token Response after authentication
    /// </summary>
    public class Token
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

    }
}
