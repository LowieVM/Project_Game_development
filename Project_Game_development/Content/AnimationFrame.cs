using Microsoft.Xna.Framework;

namespace Project_Game_development.Content
{
    internal class AnimationFrame
    {
        public Rectangle SourceRectangle { get; set; }

        public AnimationFrame(Rectangle rectangle)
        {
            SourceRectangle = rectangle;
        }
    }
}
