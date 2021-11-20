using System;
using System.Collections.Generic;
using cse210_batter_csharp.Casting;
using cse210_batter_csharp.Services;

namespace cse210_batter_csharp
{
    public class HandleCollisionsAction : Action
    {

        private PhysicsService _physics = new PhysicsService();
        private AudioService _audio = new AudioService();

        public override void Execute(Dictionary<string, List<Actor>> cast)
        {
            List<Actor> bricks = cast["bricks"];
            Actor ball = cast["balls"][0];

            Actor paddle = cast["paddle"][0];

            bool bounce = _physics.IsCollision(paddle, ball);
            if (bounce)
            {
                _audio.PlaySound(Constants.SOUND_BOUNCE);
                Point reverseVelocity = ball.GetVelocity().Reverse();
                Point newVelocity = new Point(reverseVelocity.GetX()*-1, reverseVelocity.GetY());
                ball.SetVelocity(newVelocity);
            }
            
            Actor brickToRemove = null;
            foreach(Actor brick in bricks)
            {
                bool collision = _physics.IsCollision(ball, brick);
                if (collision)
                {
                    _audio.PlaySound(Constants.SOUND_BOUNCE);

                    brick.SetImage("./Assets/brick-4.png");

                    brickToRemove = brick;

                    Point reverseVelocity = ball.GetVelocity().Reverse();
                    Point newVelocity = new Point(reverseVelocity.GetX()*-1, reverseVelocity.GetY());
                    ball.SetVelocity(newVelocity);
                }
            }
            if (brickToRemove != null)
            {
                cast["bricks"].Remove(brickToRemove);
            }
            
        }
    }
}