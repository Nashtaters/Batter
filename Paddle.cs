using System;
using cse210_batter_csharp.Casting;

namespace cse210_batter_csharp
{
    public class Paddle : Actor
    {
        public Paddle(int x, int y)
        {
            SetVelocity(new Point(0, 0));
            SetPosition(new Point(x, y));
            SetWidth(Constants.PADDLE_WIDTH);
            SetHeight(Constants.PADDLE_HEIGHT);
            SetImage(Constants.IMAGE_PADDLE);
            GetImage();
        }
    } 
}