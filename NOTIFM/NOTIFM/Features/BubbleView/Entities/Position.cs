using System;
using System.Collections.Generic;
using System.Text;

namespace NOTIFM.Features.Notifications
{
    public class Position
    {
        public int X { get; set; } = 0;
        public int Y { get; set; } = 0;

        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
