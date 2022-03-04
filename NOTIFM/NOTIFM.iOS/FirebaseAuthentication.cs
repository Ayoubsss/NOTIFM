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
    public class FirebaseAuthentication : IAuthenticationService
    {
        public class FirebaseCreateAuthRequest
        {
            public string identifier { get; set; }

            public string continueUri { get; set; }
        }

        public class FirebaseCreateAuthResponse
        {
            public string kind { get; set; }

            public List<string> allProviders { get; set; }

            public bool registered { get; set; }

            public string sessionId { get; set; }

            public List<string> signinMethods { get; set; }
        }
        public async Task<bool> CheckIfEmailExists(string email)
        {
            try
            {
                FirebaseCreateAuthResponse response = await App.HttpService.PostHttpRequest<FirebaseCreateAuthRequest, FirebaseCreateAuthResponse>("https://identitytoolkit.googleapis.com/v1/accounts:createAuthUri?key=AIzaSyB-VysImu93mT6IYChFXG4EqMh8iuc2xjw", new FirebaseCreateAuthRequest
                {
                    identifier = email,
                    continueUri = "http://localhost:8080/app"
                });

                return response.registered;
            }
            catch (Exception e)
            {
                return false;
            }
        }

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