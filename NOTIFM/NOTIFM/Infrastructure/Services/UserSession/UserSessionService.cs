using NOTIFM.Common;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace NOTIFM.Infrastructure.Services.UserSession
{
    public class UserSessionService: IUserSessionService
    {
        IAuthenticationService auth;

        public UserSessionService()
        {
            auth = DependencyService.Get<IAuthenticationService>();
        }

        public bool IsFirebaseLoggedIn()
        {
            return auth.IsSignIn();
        }
    }
}
