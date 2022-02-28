using NOTIFM.Features.SignInPage;
using NOTIFM.Infrastructure;
using NOTIFM.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace NOTIFM.Features.LoginPage
{
    public class LoginViewModel : BaseViewModel
    {
        private readonly INavigationService _navigationService;
        public LoginViewModel()
        {
            OnEmailEnteredCommand = new Command(OnEmailEntered);
            this._navigationService = App.NavigationService;
        }

        private async void OnEmailEntered()
        {
            try
            {
                await _navigationService.NavigateAsync(nameof(SignInPage));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                //await Xamarin.Forms.Shell.Current.DisplayAlert("SignIn", "An error occurs", "OK");
            }
        }

        public ICommand OnEmailEnteredCommand { get; }
    }
}