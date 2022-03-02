using NOTIFM.Features.SignInPage;
using NOTIFM.Infrastructure;
using NOTIFM.Infrastructure.Services;
using NOTIFM.Infrastructure.Services.UserSession;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace NOTIFM.Features.LoginPage
{
    public class LoginViewModel : BaseViewModel
    {
        public LoginModel LoginModel { get; set; } = new LoginModel();
        private readonly INavigationService _navigationService;
        private readonly IUserSessionService _userSessionService;
        private Page _page;
        public LoginViewModel(Page page)
        {
            OnEmailEnteredCommand = new Command(OnEmailEntered);

            this._page = page;
            this._navigationService = App.NavigationService;
            this._userSessionService = App.UserSessionService;

            if (_userSessionService.IsFirebaseLoggedIn())
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    await _page.DisplayAlert("Info", "Already logged in", "OK");
                });
            }
        }

        private async void OnEmailEntered()
        {
            try
            {
                if (!ValidationHelper.IsFormValid(LoginModel))
                {
                    Device.BeginInvokeOnMainThread(async () =>
                    {
                        await _page.DisplayAlert("Error", "Enter a valid email", "OK");
                    });
                    return;
                }
                else
                {
                    await _navigationService.NavigateAsync(nameof(SignInPage), LoginModel.Email);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public ICommand OnEmailEnteredCommand { get; }
    }
}