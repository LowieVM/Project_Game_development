using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Game_development.Content
{
    internal class Player
    {
        private Texture2D walkTexture;
        private Animation animation;
        private SpriteEffects effect = SpriteEffects.None;
        public Vector2 Position { get; set; }

        public Player(Texture2D texture)
        {
            walkTexture = texture;
            animation = new Animation(15);
            animation.GetFramesFromTextureProps(texture.Width, texture.Height, 6, 1);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(walkTexture, Position, animation.CurrentFrame.SourceRectangle, Color.White, 0f, Vector2.Zero, 1f, effect, 0f);
        }

        public void Update(GameTime gameTime)
        {
            animation.Update(gameTime);
        }

    }
}
