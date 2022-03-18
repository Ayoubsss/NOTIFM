using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NOTIFM.Features.DashboardPage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DashboardPage : ContentPage
    {
        public DashboardPage(string email = "N/A")
        {
            InitializeComponent();

            // Remove navigation bar
            NavigationPage.SetHasNavigationBar(this, false);

            BindingContext = new DashboardViewModel(this, email);
        }
    }
}