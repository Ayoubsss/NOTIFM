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
        public DashboardModel DashboardModel { get; set; } = new DashboardModel();
        IAuthenticationService auth;
        private readonly INavigationService _navigationService;
        private Page _page;

        public DashboardViewModel(Page page, string email)
        {
            this._page = page;
            this.auth = DependencyService.Get<IAuthenticationService>();
            this._navigationService = App.NavigationService;
            this.DashboardModel.Email = email;

            tapCommand = new Command(OnTapped);
            OnLogoutTappedCommand = new Command(OnLogoutTapped);
        }

        ICommand tapCommand;
        public ICommand TapCommand
        {
            get { return tapCommand; }
        }

        void OnTapped()
        {
            // Here you can use MessagingCenter and Send a message to test with a screen tap
            MessagingCenter.Send<NOTIFM.App>((NOTIFM.App)Xamarin.Forms.Application.Current, "TappedView");
        }

        private void OnLogoutTapped()
        {
            try
            {
                auth.SignOut();
                Device.BeginInvokeOnMainThread(async () =>
                {
                    await _navigationService.NavigateAsync(nameof(LoginPage), false);
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
