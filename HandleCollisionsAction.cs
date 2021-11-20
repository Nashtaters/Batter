using System;
using System.Collections.Generic;
using cse210_batter_csharp.Casting;
using cse210_batter_csharp.Services;

namespace cse210_batter_csharp
{
    public class HandleCollisionsAction : Action
    {
        const int  FLASH_INTERVAL = 10;

        private PhysicsService _physics = new PhysicsService();
        private AudioService _audio = new AudioService();
        private List<FlashBrick> _flashBricks = new List<FlashBrick>();

        public override void Execute(Dictionary<string, List<Actor>> cast)
        {
            BounceLogic(cast);
            CollisionLogic(cast);
            FlashLogic(cast);
        }

        private void BounceLogic(Dictionary<string, List<Actor>> cast)
        {
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
        }

        private void CollisionLogic(Dictionary<string, List<Actor>> cast)
        {
            Actor ball = cast["balls"][0];
            List<Actor> bricks = cast["bricks"];
            
            Actor brickToRemove = null;
            foreach(Actor brick in bricks)
            {
                bool collision = _physics.IsCollision(ball, brick);
                if (collision)
                {
                    _audio.PlaySound(Constants.SOUND_BOUNCE);

                    brickToRemove = brick;

                    Point reverseVelocity = ball.GetVelocity().Reverse();
                    Point newVelocity = new Point(reverseVelocity.GetX()*-1, reverseVelocity.GetY());
                    ball.SetVelocity(newVelocity);
                }
            }
            if (brickToRemove != null)
            {
                FlashBrick flashBrick = new FlashBrick(brickToRemove);
                _flashBricks.Add(flashBrick);
                //cast["bricks"].Remove(brickToRemove);
            }
        }

        private void FlashLogic(Dictionary<string, List<Actor>> cast)
        {
            FlashBrick brickToRemove = null;
            foreach(FlashBrick brickToFlash in _flashBricks)
            {
                int count = brickToFlash.PlusCount();
                if (count == 1)
                {
                    brickToFlash.GetBrick().SetImage("./Assets/brick-4.png");
                }
                else if (count == FLASH_INTERVAL)
                {
                    brickToFlash.GetBrick().SetImage(Constants.IMAGE_BRICK);
                }
                else if (count == FLASH_INTERVAL * 2)
                {
                    brickToFlash.GetBrick().SetImage("./Assets/brick-4.png");
                }
                else if (count > FLASH_INTERVAL * 3)
                {
                    cast["bricks"].Remove(brickToFlash.GetBrick());
                    brickToRemove = brickToFlash;
                }
            }
            _flashBricks.Remove(brickToRemove);
        }
    }
}