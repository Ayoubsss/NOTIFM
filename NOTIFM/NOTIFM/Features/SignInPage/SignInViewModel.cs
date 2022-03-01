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

        public SignInModel SignInModel { get; set; } = new SignInModel();

        //private readonly INavigationService _navigationService;
        private Page _page;
        public SignInViewModel(Page page)
        {
            OnPasswordEnteredCommand = new Command(OnPasswordEntered);
            //this._navigationService = App.NavigationService;
            _page = page;
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
                    await _page.DisplayAlert("Success", "Logging you in...", "OK");
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