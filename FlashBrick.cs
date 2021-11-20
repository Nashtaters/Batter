using System;
using cse210_batter_csharp.Casting;

namespace cse210_batter_csharp
{
    public class FlashBrick
    {
        Actor _brick = null;
        int _flashCount = 0;

        public FlashBrick(Actor brick)
        {
            _brick = brick;
        }

        public int PlusCount()
        {
            return ++_flashCount;
        }

        public int GetCount()
        {
            return _flashCount;
        }

        public Actor GetBrick()
        {
            return _brick;
        }
    }
}