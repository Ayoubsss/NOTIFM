using NOTIFM.Common;
using NOTIFM.Infrastructure;
using NOTIFM.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace NOTIFM.Features.SignUpPage
{
    public class SignUpViewModel: BaseViewModel
    {
        IAuthenticationService auth;
        public SignUpModel SignUpModel { get; set; } = new SignUpModel();

        private readonly INavigationService _navigationService;
        private Page _page;

        public SignUpViewModel(Page page, string email)
        {
            OnSignUpTappedCommand = new Command(OnSignUpTapped);
            this._navigationService = App.NavigationService;
            this.auth = DependencyService.Get<IAuthenticationService>();
            this._page = page;
            SignUpModel.Email = email;
        }

        private async void OnSignUpTapped()
        {
            try
            {
                bool passwordValid = ValidationHelper.IsPasswordValid(SignUpModel.Password);
                bool passwordConfirmationValid = ValidationHelper.IsPasswordValid(SignUpModel.PasswordConfirmation);

                if (passwordValid == false || passwordConfirmationValid == false)
                {
                    Device.BeginInvokeOnMainThread(async () => {
                        await _page.DisplayAlert("Password", "The following requirements must be met:\n\n- At least one upper case letter\n- At least one special character\n- At least one number\n- At least 8 characters", "OK");
                    });
                } else
                {
                    // Additional validation to check if passwords do match
                    if(!SignUpModel.Password.Equals(SignUpModel.PasswordConfirmation)){
                        Device.BeginInvokeOnMainThread(async () => {
                            await _page.DisplayAlert("Password", "Password and confirmation need to match", "OK");
                        });
                    } else
                    {
                        // Sign up logic happens here
                        var isSignedUp = await auth.CreateUser(SignUpModel.Email, SignUpModel.Email, SignUpModel.Password);
                        if (isSignedUp)
                        {
                            Device.BeginInvokeOnMainThread(async () => {
                                await _page.DisplayAlert("Signed Up", "You've successfully signed up. Signing in...", "OK");
                                await _navigationService.NavigateAsync(nameof(DashboardPage));
                            });
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        public ICommand OnSignUpTappedCommand { get; }
    }
}
