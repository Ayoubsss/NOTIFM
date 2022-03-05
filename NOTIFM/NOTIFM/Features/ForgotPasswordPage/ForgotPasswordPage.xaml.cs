using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NOTIFM.Features.ForgotPasswordPage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ForgotPasswordPage : ContentPage
    {
        public ForgotPasswordPage()
        {
            InitializeComponent();

            // Remove navigation bar
            NavigationPage.SetHasNavigationBar(this, false);

            resourceImage.Source = ImageSource.FromResource("NOTIFM.Images.registration_background_upper_crop.png");

            BindingContext = new ForgotPasswordViewModel(this);
        }
    }
}