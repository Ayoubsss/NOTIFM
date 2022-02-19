using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace NOTIFM
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();

            resourceImage.Source = ImageSource.FromResource("NOTIFM.Images.registration_background_upper_crop.png");
        }
    }
}
