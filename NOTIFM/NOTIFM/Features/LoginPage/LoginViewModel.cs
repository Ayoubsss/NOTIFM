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
        public LoginModel LoginModel { get; set; } = new LoginModel();
        private readonly INavigationService _navigationService;
        private Page _page;
        public LoginViewModel(Page page)
        {
            OnEmailEnteredCommand = new Command(OnEmailEntered);
            this._navigationService = App.NavigationService;
            _page = page;
        }

        private async void OnEmailEntered()
        {
            try
            {
                if (!ValidationHelper.IsFormValid(LoginModel))
                {
                    await _page.DisplayAlert("Error", "Enter a valid email", "OK");
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