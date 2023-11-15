using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Game_development
{
    internal class Animation
    {
        public AnimationFrame CurrentFrame { get; set; }
        public int Fps;
        private List<AnimationFrame> frames;
        private int currentFrameNum = 0;
        private double elapsedTime = 0;

        public Animation(int fps)
        {
            frames = new List<AnimationFrame>();
            Fps = fps;
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

        public void GetFramesFromTextureProps(int width, int height, int xSprites, int ySprites)
        {
            int frameWidth = width / xSprites;
            int frameHeight = height / ySprites;

            for (int y = 0; y <= height - frameHeight; y += frameHeight)
            {
                for (int x = 0; x <= width - frameWidth; x += frameWidth)
                {
                    frames.Add(new AnimationFrame(new Rectangle(x, y, frameWidth, frameHeight)));
                }
            }
        }
    }
}
