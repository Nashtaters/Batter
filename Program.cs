using System;
using cse210_batter_csharp.Services;
using cse210_batter_csharp.Casting;
using cse210_batter_csharp.Scripting;
using System.Collections.Generic;

namespace cse210_batter_csharp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create the cast
            Dictionary<string, List<Actor>> cast = new Dictionary<string, List<Actor>>();

            // Bricks
            cast["bricks"] = new List<Actor>();
        
            int x_position = 5;
            int y_position = 0;
            for (int i = 0; i < 100; i++)
            {
                if (x_position > 800)
                {
                    x_position = 5;
                    y_position += 29;  
                }
                else
                {
                    Brick brick = new Brick(x_position, y_position);
                    cast["bricks"].Add(brick);
                    x_position += 53;
                }
            }

            // The Ball (or balls if desired)
            cast["balls"] = new List<Actor>();

            Ball ball = new Ball(Constants.BALL_X, Constants.BALL_Y);
            cast["balls"].Add(ball);

            // The paddle
            cast["paddle"] = new List<Actor>();

            Paddle paddle = new Paddle(Constants.PADDLE_X, Constants.PADDLE_Y);
            cast["paddle"].Add(paddle);

            // Create the script
            Dictionary<string, List<Action>> script = new Dictionary<string, List<Action>>();

            OutputService outputService = new OutputService();
            InputService inputService = new InputService();
            PhysicsService physicsService = new PhysicsService();
            AudioService audioService = new AudioService();

            script["output"] = new List<Action>();
            script["input"] = new List<Action>();
            script["update"] = new List<Action>();
            
            MoveActorsAction geoff = new MoveActorsAction();
            script["update"].Add(geoff);

            DrawActorsAction drawActorsAction = new DrawActorsAction(outputService);
            script["output"].Add(drawActorsAction);

            // TODO: Add additional actions here to handle the input, move the actors, handle collisions, etc.

            // Start up the game
            outputService.OpenWindow(Constants.MAX_X, Constants.MAX_Y, "Batter", Constants.FRAME_RATE);
            audioService.StartAudio();
            audioService.PlaySound(Constants.SOUND_START);

            Director theDirector = new Director(cast, script);
            theDirector.Direct();

            audioService.StopAudio();
        }
    }
}
