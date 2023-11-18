using Microsoft.Xna.Framework;

namespace Project_Game_development
{
    internal class AnimationFrame
    {
        public Rectangle SourceRectangle { get; private set; }

        public AnimationFrame(Rectangle rectangle)
        {
            SourceRectangle = rectangle;
        }
    }
}
