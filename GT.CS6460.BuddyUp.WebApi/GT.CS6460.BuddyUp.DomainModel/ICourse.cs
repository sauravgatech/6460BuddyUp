using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GT.CS6460.BuddyUp.DomainDto;
using GT.CS6460.BuddyUp.Platform.Common;

namespace GT.CS6460.BuddyUp.DomainModel
{
    public interface ICourse
    {
        IEnumerable<CourseGetResponse> Get(string courseCode = "");

        DomainModelResponse Add(CourseAddRequest request);

        DomainModelResponse Update(CourseUpdateRequest request);

        DomainModelResponse Delete(string courseCode);
    }
}
