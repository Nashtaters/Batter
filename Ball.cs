using System;
using cse210_batter_csharp.Casting;

namespace cse210_batter_csharp
{
    public class Ball : Actor
    {
        public Ball(int x, int y)
        {
            SetVelocity(new Point(5, -5));
            SetPosition(new Point(x, y));
            SetWidth(Constants.BALL_WIDTH);
            SetHeight(Constants.BALL_HEIGHT);
            SetImage(Constants.IMAGE_BALL);
            GetImage();
        }
    } 
}