using NOTIFM.Features.BubbleView;
using NOTIFM.Features.Notifications;
using SkiaSharp;
using SkiaSharp.Views.Forms;
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
        private static List<NotificationBubble> NotificationBubbles = new List<NotificationBubble>();
        public DashboardPage(string email = "N/A")
        {
            InitializeComponent();

            // Remove navigation bar
            NavigationPage.SetHasNavigationBar(this, false);

            BindingContext = new DashboardViewModel(this, email);

            // Use the Publish-Subsciber pattern to create custom events
            //
            // Send:      MessagingCenter.Send<NOTIFM.App>((NOTIFM.App)Xamarin.Forms.Application.Current, "TappedView");
            // Subscript: MessagingCenter.Subscribe<App>((App)Application.Current, "TappedView", (sender) => { // code to execute });

            MessagingCenter.Subscribe<App>((App)Application.Current, "TappedView", (sender) => {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    await DisplayAlert(" ", "Test", "OK");
                });
            });
        }


        private void GenerateNotificationBubbleList()
        {
            NotificationBubbles.Clear();

            var mockIconList = new List<Icon>() { 
                new Notifications.Icon() { AppName = "WhatsApp" }, 
                new Notifications.Icon() { AppName = "Facebook" } 
            };

            var mockColor = new Color(0, 255, 0);
            var mockNotificationBubble = new NotificationBubble()
            {
                Category = new Category("Social Media", mockColor),
                Priority = 1,
                Position = new Position(0, 0),
                Icons = mockIconList
            };

            NotificationBubbles.Add(mockNotificationBubble);
        }

        void OnCanvasViewPaintSurface(object sender, SKPaintSurfaceEventArgs args)
        {
            SKImageInfo info = args.Info;
            SKSurface surface = args.Surface;
            SKCanvas canvas = surface.Canvas;

            canvas.Clear();

            float strokeWidth = 50;
            float xRadius = (info.Width - strokeWidth) / 2;
            float yRadius = (info.Height - strokeWidth) / 2;

            SKPaint paint = new SKPaint
            {
                Style = SKPaintStyle.Stroke,
                Color = SKColors.Blue,
                StrokeWidth = strokeWidth
            };
            canvas.DrawOval(info.Width / 2, info.Height / 2, xRadius, yRadius, paint);
        }
    }
}