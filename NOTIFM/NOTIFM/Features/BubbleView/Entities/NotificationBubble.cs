using NOTIFM.Features.BubbleView.Enums;
using NOTIFM.Features.Notifications;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace NOTIFM.Features.BubbleView
{
    public class NotificationBubble
    {
        public Category Category { get; set; }

        // Priority defines the size of the bubble
        public int Priority { get; set; }
        public Position Position { get; set; }
        public NotificationBubbleState State { get; set; } = NotificationBubbleState.Active;
        public IEnumerable<Icon> Icons { get; set; }
    }
}
