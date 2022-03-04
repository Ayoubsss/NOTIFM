using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Firebase.Auth;
using NOTIFM.Common;
using NOTIFM.Droid.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NOTIFM.Droid
{
    public class FirebaseAuthentication : IFirebaseAuthenticationService
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

        public async Task<bool> CreateUser(string username, string email, string password)
        {
            var authResult = await Firebase.Auth.FirebaseAuth.Instance.CreateUserWithEmailAndPasswordAsync(email, password);

            return await Task.FromResult(true);
        }

        public bool IsSignIn()
        {
            var user = Firebase.Auth.FirebaseAuth.Instance.CurrentUser;
            return user != null;
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

        public async Task<string> SignIn(string email, string password)
        {
            try
            {
                var user = await Firebase.Auth.FirebaseAuth.Instance.SignInWithEmailAndPasswordAsync(email, password);
                var token = await user.User.GetIdToken(true).ToAwaitableTask();
                return token.ToString();
            }
            catch (FirebaseAuthInvalidUserException e)
            {
                e.PrintStackTrace();
                return string.Empty;
            }
            catch (FirebaseAuthInvalidCredentialsException e)
            {
                e.PrintStackTrace();
                return string.Empty;
            }
        }

        public async Task ResetPassword(string email)
        {
            await Firebase.Auth.FirebaseAuth.Instance.SendPasswordResetEmailAsync(email);
        }

        void IFirebaseAuthenticationService.SignOut()
        {
            try
            {
                Firebase.Auth.FirebaseAuth.Instance.SignOut();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}