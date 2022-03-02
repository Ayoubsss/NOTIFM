using NOTIFM.Infrastructure;
using NOTIFM.Infrastructure.Services.UserSession;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace NOTIFM.Features.DashboardPage
{
    public class DashboardViewModel : BaseViewModel
    {
        private readonly IUserSessionService _userSessionService;
        private Page _page;

        public DashboardViewModel(Page page)
        {
            this._page = page;
            this._userSessionService = App.UserSessionService;

            if (_userSessionService.IsFirebaseLoggedIn())
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    await _page.DisplayAlert("Info", "Already logged in", "OK");
                });
            }
        }
    }
}
