using NOTIFM.Features.SignInPage;
using NOTIFM.Infrastructure.Services;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NOTIFM
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            #region Application Pages
            NavigationService.Configure("MainPage", typeof(LoginPage));
            NavigationService.Configure("SignInPage", typeof(SignInPage));
            #endregion
            var mainPage = ((ViewNavigationService)NavigationService).SetRootPage("MainPage");

            MainPage = mainPage;
        }

        public static INavigationService NavigationService { get; } = new ViewNavigationService();

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
