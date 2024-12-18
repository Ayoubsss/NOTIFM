﻿using NOTIFM.Features.DashboardPage;
using NOTIFM.Features.ForgotPasswordPage;
using NOTIFM.Features.SignInPage;
using NOTIFM.Features.SignUpPage;
using NOTIFM.Infrastructure.Services;
using NOTIFM.Infrastructure.Services.RestService;
using NOTIFM.Infrastructure.Services.UserSession;
using System;
using System.Threading.Tasks;
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
            NavigationService.Configure("LoginPage", typeof(LoginPage));
            NavigationService.Configure("SignInPage", typeof(SignInPage));
            NavigationService.Configure("SignUpPage", typeof(SignUpPage));
            NavigationService.Configure("ForgotPasswordPage", typeof(ForgotPasswordPage));
            NavigationService.Configure("DashboardPage", typeof(DashboardPage));
            #endregion
            var mainPage = ((ViewNavigationService)NavigationService).SetRootPage("LoginPage");

            MainPage = mainPage;
        }

        public static INavigationService NavigationService { get; } = new ViewNavigationService();
        public static IUserSessionService UserSessionService { get; } = new UserSessionService();
        public static IHttpService HttpService { get; } = new HttpService();


        protected override void OnStart()
        {
            this.RedirectIfNotLoggedIn();
        }

        protected override void OnResume()
        {
            this.RedirectIfNotLoggedIn();
        }

        private void RedirectIfNotLoggedIn()
        {
            if (UserSessionService.IsLoggedIn())
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    var emailSignedIn = "N/A";
                    await NavigationService.NavigateAsync(nameof(DashboardPage), emailSignedIn);
                });
            }
        }
       
    }
}
