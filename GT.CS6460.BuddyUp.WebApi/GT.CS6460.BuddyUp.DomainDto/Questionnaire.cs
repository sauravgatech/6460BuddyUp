using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GT.CS6460.BuddyUp.DomainDto
{
    /// <summary>
    /// Questionnaire
    /// </summary>
    public class Questionnaire
    {
        /// <summary>
        /// Questionnaire Code
        /// </summary>
        public string QuestionnaireCode { get; set; }
        /// <summary>
        /// List of questions
        /// </summary>
        List<Question> questions { get; set; }
    }
}
