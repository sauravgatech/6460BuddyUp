using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GT.CS6460.BuddyUp.DomainDto;
using GT.CS6460.BuddyUp.Platform.Common;

namespace GT.CS6460.BuddyUp.DomainModel
{
    public interface ISecurity// : IDisposable
    {
        Token Login(AuthenticationRequest AuthenticationRequest);

        bool ValidateToken(string token);

        DomainModelResponse Logout(string token);

        DomainModelResponse ResetPassword(AuthenticationRequest AuthenticationRequest, string newPassword);

        DomainModelResponse ResetPassword(AuthenticationRequest AuthenticationRequest, string newPassword, bool resetByAdmin);
    }
}
