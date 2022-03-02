using Firebase.Auth;
using Foundation;
using NOTIFM.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UIKit;

namespace NOTIFM.iOS
{
    public class FirebaseAuthentication : IFirebaseAuthenticationService
    {
        public async Task<bool> CreateUser(string username, string email, string password)
        {
            var authResult = await Auth.DefaultInstance
                   .CreateUserAsync(email, password);

            var changeRequest = authResult.User.ProfileChangeRequest();
            changeRequest.DisplayName = username;
            await changeRequest.CommitChangesAsync();

            return await Task.FromResult(true);
        }

        public bool IsSignIn()
        {
            var currentUser = Auth.DefaultInstance.CurrentUser;
            return currentUser != null;
        }

        public async Task ResetPassword(string email)
        {
            await Auth.DefaultInstance.SendPasswordResetAsync(email);
        }

        public async Task<string> SignIn(string email, string password)
        {
            var authResult = await Auth.DefaultInstance
                .SignInWithPasswordAsync(email, password);

            return await authResult.User.GetIdTokenAsync();
        }

        public void SignOut()
        {
            Auth.DefaultInstance.SignOut(out _);
        }
    }
}