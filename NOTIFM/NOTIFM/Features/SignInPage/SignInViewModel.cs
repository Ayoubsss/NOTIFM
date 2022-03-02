using NOTIFM.Common;
using NOTIFM.Infrastructure;
using NOTIFM.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace NOTIFM.Features.SignInPage
{
    public class SignInViewModel: BaseViewModel
    {
        IAuthenticationService auth;
        public SignInModel SignInModel { get; set; } = new SignInModel();

        //private readonly INavigationService _navigationService;
        private Page _page;
        public SignInViewModel(Page page, string email)
        {
            OnPasswordEnteredCommand = new Command(OnPasswordEntered);
            //this._navigationService = App.NavigationService;
            auth = DependencyService.Get<IAuthenticationService>();
            _page = page;
            SignInModel.Email = email;
        }

        private async void OnPasswordEntered()
        {
            try
            {
                if (!ValidationHelper.IsFormValid(SignInModel))
                {
                    await _page.DisplayAlert("Error", "Enter a password", "OK");
                    return;
                }
                else
                {
                    string token = await auth.SignIn(SignInModel.Email, SignInModel.Password);

                    if (token != string.Empty)
                    {
                        Device.BeginInvokeOnMainThread(async () => {
                            await _page.DisplayAlert("Logged In", "Sucessfully logged in", "OK");
                        });
                    }
                    else
                    {
                        Device.BeginInvokeOnMainThread(async () => {
                            await _page.DisplayAlert("Error", "Failed to log in", "OK");
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public ICommand OnPasswordEnteredCommand { get; }
    }
}