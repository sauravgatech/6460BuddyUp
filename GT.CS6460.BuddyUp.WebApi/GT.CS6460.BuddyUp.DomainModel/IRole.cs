using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GT.CS6460.BuddyUp.DomainDto;
using GT.CS6460.BuddyUp.Platform.Common;

namespace GT.CS6460.BuddyUp.DomainModel
{
    public interface IRole
    {
        IEnumerable<DomainDto.Role> Get(string roleCode = "");

        DomainModelResponse Add(DomainDto.Role request);

        DomainModelResponse Update(DomainDto.Role request);

        DomainModelResponse Delete(string roleCode);
    }
}
