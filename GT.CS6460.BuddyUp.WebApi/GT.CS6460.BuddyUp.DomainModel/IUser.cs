using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GT.CS6460.BuddyUp.DomainDto;
using GT.CS6460.BuddyUp.Platform.Common;

namespace GT.CS6460.BuddyUp.DomainModel
{
    public interface IUser
    {
        IEnumerable<UserGetResponse> Get(string emailId = "");

        DomainModelResponse Add(UserAddRequest request);

        DomainModelResponse Update(UserUpdateRequest request);

        DomainModelResponse Delete(string emailId);

        DomainModelResponse AddUserToCourse(UpdateUserCourse request);

        DomainModelResponse AddUserToGroup(UpdateUserGroup request);
    }
}
