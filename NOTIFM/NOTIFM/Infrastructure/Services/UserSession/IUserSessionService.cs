using System;
using System.Collections.Generic;
using System.Text;

namespace NOTIFM.Infrastructure.Services.UserSession
{
    public interface IUserSessionService
    {
        bool IsFirebaseLoggedIn();
    }
}
