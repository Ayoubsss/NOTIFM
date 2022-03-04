using NOTIFM.Common;
using NOTIFM.Infrastructure;
using NOTIFM.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace NOTIFM.Features.SignUpPage
{
    public class SignUpViewModel: BaseViewModel
    {
        IFirebaseAuthenticationService auth;
        private readonly INavigationService _navigationService;
        public SignUpModel SignUpModel { get; set; } = new SignUpModel();
        private Page _page;

        public SignUpViewModel(Page page, string email)
        {
            this._navigationService = App.NavigationService;
            this._page = page;
            this.auth = DependencyService.Get<IFirebaseAuthenticationService>();

            SignUpModel.Email = email;
        }
    }
}
