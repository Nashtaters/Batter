using System;
using cse210_batter_csharp.Casting;

namespace cse210_batter_csharp
{
    public class Brick : Actor
    {
        public Brick(int x, int y)
        {
            SetVelocity(new Point(0, 0));
            SetPosition(new Point(x, y));
            SetWidth(Constants.BRICK_WIDTH);
            SetHeight(Constants.BRICK_HEIGHT);
            SetImage(Constants.IMAGE_BRICK);
            GetImage();
        }
    } 
}