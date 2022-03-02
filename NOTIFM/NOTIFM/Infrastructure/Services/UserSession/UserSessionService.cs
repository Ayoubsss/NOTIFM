using NOTIFM.Common;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace NOTIFM.Infrastructure.Services.UserSession
{
    public class UserSessionService: IUserSessionService
    {
        IFirebaseAuthenticationService auth;

        public UserSessionService()
        {
            auth = DependencyService.Get<IFirebaseAuthenticationService>();
        }

        public bool IsFirebaseLoggedIn()
        {
            return auth.IsSignIn();
        }
    }
}
