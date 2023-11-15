using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Game_development
{
    enum PlayerState { Walking, Runing, Pistol, Shotgun, ShotgunReloading, MiniGun, MiniGuNReloading, Flamethrower }
    internal class Player
    {
        private Texture2D walkTexture;
        private Texture2D runTexture;
        private Texture2D currentTexture;

        private Animation walkAnimation;
        private Animation runAnimation;
        private Animation currentAnimation;
        private SpriteEffects effect = SpriteEffects.None;
        public Vector2 Position { get; set; }

        public Player(Texture2D walkTexture, Texture2D runTexture)
        {
            this.walkTexture = walkTexture;
            this.runTexture = runTexture;

            walkAnimation = new Animation(12);
            runAnimation = new Animation(12);

            walkAnimation.GetFramesFromTextureProps(walkTexture.Width, walkTexture.Height, 6, 1);
            runAnimation.GetFramesFromTextureProps(runTexture.Width, runTexture.Height, 6, 1);

            currentTexture = this.runTexture;
            currentAnimation = runAnimation;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(currentTexture, Position, currentAnimation.CurrentFrame.SourceRectangle, Color.White, 0f, Vector2.Zero, 1f, effect, 0f);
        }

        public void Update(GameTime gameTime)
        {
            currentAnimation.Update(gameTime);
        }

    }
}
