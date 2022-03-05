using NOTIFM.Common;
using NOTIFM.Infrastructure;
using NOTIFM.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace NOTIFM.Features.ForgotPasswordPage
{
    public class ForgotPasswordViewModel: BaseViewModel
    {
        IAuthenticationService auth;
        public ForgotPasswordModel ForgotPasswordModel { get; set; } = new ForgotPasswordModel();

        private readonly INavigationService _navigationService;
        private Page _page;
        public ForgotPasswordViewModel(Page page)
        {
            OnResetPasswordTappedCommand = new Command(OnResetPassword);
            this._navigationService = App.NavigationService;
            this.auth = DependencyService.Get<IAuthenticationService>();
            this._page = page;
        }

        private async void OnResetPassword()
        {
            try
            {
                if (!ValidationHelper.IsFormValid(ForgotPasswordModel))
                {
                    await _page.DisplayAlert(" ", "Enter a valid email", "OK");
                    return;
                }
                else
                {
                    await auth.ResetPassword(ForgotPasswordModel.Email);

                    Device.BeginInvokeOnMainThread(async () => {
                        await _page.DisplayAlert("Reset Password", "Your password reset link has been sent\n\nPlease verify your email inbox", "OK");
                        await _navigationService.NavigateAsync(nameof(LoginPage));
                    });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public ICommand OnResetPasswordTappedCommand { get; }
    }
}
