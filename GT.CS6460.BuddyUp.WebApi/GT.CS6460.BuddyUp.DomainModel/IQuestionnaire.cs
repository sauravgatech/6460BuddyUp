using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GT.CS6460.BuddyUp.DomainDto;
using GT.CS6460.BuddyUp.Platform.Common;

namespace GT.CS6460.BuddyUp.DomainModel
{
    public interface IQuestionnaire
    {
        IEnumerable<QuestionnaireGetResponse> Get(string questionnaireCode = "");

        DomainModelResponse Add(QuestionnaireAddRequest request);

        DomainModelResponse Update(QuestionnaireUpdateRequest request);

        DomainModelResponse Delete(string questionnaireCode);
    }
}
