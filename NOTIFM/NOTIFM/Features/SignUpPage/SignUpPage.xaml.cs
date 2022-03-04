using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NOTIFM.Features.SignUpPage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignUpPage : ContentPage
    {
        public SignUpPage(string email)
        {
            InitializeComponent();

            // Remove navigation bar
            NavigationPage.SetHasNavigationBar(this, false);

            resourceImage.Source = ImageSource.FromResource("NOTIFM.Images.registration_background_upper_crop.png");

            BindingContext = new SignUpViewModel(this, email);
        }
    }
}