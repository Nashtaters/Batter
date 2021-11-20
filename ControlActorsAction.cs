using System;
using System.Collections.Generic;
using cse210_batter_csharp.Casting;
using cse210_batter_csharp.Services;

namespace cse210_batter_csharp
{
    public class ControlActorsAction : Action
    {

        private PhysicsService _physics = new PhysicsService();
        private InputService _input = new InputService();

        public override void Execute(Dictionary<string, List<Actor>> cast)
        {
            Actor paddle = cast["paddle"][0];
            if (_input.IsLeftPressed())
            {
                paddle.SetVelocity(new Point(Constants.PADDLE_SPEED * -1, 0));
            }

            else if (_input.IsRightPressed())
            {
                paddle.SetVelocity(new Point(Constants.PADDLE_SPEED, 0));
            }
        }
    }
}