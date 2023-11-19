using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Project_Game_development
{
    internal class Animation
    {
        public AnimationFrame CurrentFrame { get; private set; }
        public int Fps;
        private List<AnimationFrame> frames;
        private int currentFrameNum = 0;
        private double elapsedTime = 0;

        public Animation(int fps, Texture2D texture, int xSprites, int ySprites)
        {
            frames = new List<AnimationFrame>();
            Fps = fps;
            GetFrames(texture, xSprites, ySprites);
        }

        public void AddFrame(AnimationFrame frame)
        {
            frames.Add(frame);
        }

        public void Update(GameTime gameTime)
        {
            CurrentFrame = frames[currentFrameNum];
            elapsedTime += gameTime.ElapsedGameTime.TotalSeconds;

            if (elapsedTime >= 1.0 / Fps)
            {
                currentFrameNum++;
                elapsedTime = 0;
            }

            if (currentFrameNum >= frames.Count)
            {
                currentFrameNum = 0;
            }
        }

        public void GetFrames(Texture2D texture, int xSprites, int ySprites)
        {
            int frameWidth = texture.Width / xSprites;
            int frameHeight = texture.Height / ySprites;

            for (int y = 0; y <= texture.Height - frameHeight; y += frameHeight)
            {
                for (int x = 0; x <= texture.Width - frameWidth; x += frameWidth)
                {
                    frames.Add(new AnimationFrame(new Rectangle(x, y, frameWidth, frameHeight)));
                }
            }
        }
    }
}
