using NOTIFM.Common;
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
        IAuthenticationService auth;
        public LoginModel LoginModel { get; set; } = new LoginModel();
        private readonly INavigationService _navigationService;
        private Page _page;
        public LoginViewModel(Page page)
        {
            OnEmailEnteredCommand = new Command(OnEmailEntered);

            this._page = page;
            this._navigationService = App.NavigationService;
            this.auth = DependencyService.Get<IAuthenticationService>();
        }

        private async void OnEmailEntered()
        {
            try
            {
                if (!ValidationHelper.IsFormValid(LoginModel))
                {
                    Device.BeginInvokeOnMainThread(async () =>
                    {
                        await _page.DisplayAlert(" ", "Enter a valid email", "OK");
                    });
                }
                else
                {
                    var result = await auth.CheckIfEmailExists(LoginModel.Email);

                    
                    if (!result)
                    {
                        Device.BeginInvokeOnMainThread(async () =>
                        {
                            await _navigationService.NavigateAsync(nameof(SignUpPage), LoginModel.Email);
                        });
                    }
                    else
                    {
                        Device.BeginInvokeOnMainThread(async () =>
                        {
                            await _navigationService.NavigateAsync(nameof(SignInPage), LoginModel.Email);
                        });
                    }
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