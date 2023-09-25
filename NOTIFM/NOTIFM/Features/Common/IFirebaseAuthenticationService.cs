﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NOTIFM.Common
{
    public interface IFirebaseAuthenticationService
    {
        bool IsSignIn();
        Task<bool> CheckIfEmailExists(string email);
        Task<bool> CreateUser(string username, string email, string password);
        void SignOut();
        Task<string> SignIn(string email, string password);
        Task ResetPassword(string email);
    }
}