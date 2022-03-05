using NOTIFM.Common;
using NOTIFM.Infrastructure;
using NOTIFM.Infrastructure.Services;
using NOTIFM.Infrastructure.Services.UserSession;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace NOTIFM.Features.DashboardPage
{
    public class DashboardViewModel : BaseViewModel
    {
        IAuthenticationService auth;
        private readonly INavigationService _navigationService;
        private Page _page;

        public DashboardViewModel(Page page)
        {
            this._page = page;
            this.auth = DependencyService.Get<IAuthenticationService>();
            this._navigationService = App.NavigationService;

            OnLogoutTappedCommand = new Command(OnLogoutTapped);
        }

        private void OnLogoutTapped()
        {
            try
            {
                auth.SignOut();
                Device.BeginInvokeOnMainThread(async () =>
                {
                    await _navigationService.NavigateAsync(nameof(LoginPage));
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public ICommand OnLogoutTappedCommand { get; }
    }
}
