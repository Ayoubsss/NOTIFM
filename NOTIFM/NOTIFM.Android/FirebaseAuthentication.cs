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