﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GT.CS6460.BuddyUp.DomainDto;
using GT.CS6460.BuddyUp.Platform.Common;

namespace GT.CS6460.BuddyUp.DomainModel
{
    public interface IGroup
    {
        IEnumerable<GroupGetResponse> Get(string groupCode = "");

        DomainModelResponse Add(GroupAddRequest request);

        DomainModelResponse Update(GroupUpdateRequest request);

        DomainModelResponse Delete(string groupCode);

        GroupSummaryForUser GetGroupSummary(string userEmail, string courseCode);
    }
}