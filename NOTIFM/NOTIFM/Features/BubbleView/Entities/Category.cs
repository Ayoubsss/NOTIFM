using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace NOTIFM.Features.Notifications
{
    public class Category
    {
        public string Title { get; set; }
        public Color Color { get; set; }

        public Category(string title, Color color) {
            Title = title;
            Color = color;
        }
    }
}
