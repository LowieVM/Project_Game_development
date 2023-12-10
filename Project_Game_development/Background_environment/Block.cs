using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SharpDX.Direct2D1.Effects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Game_development
{
    internal class Block : IPositional
    {
        public Vector2 Position { get; set; }
        protected Texture2D currentTexture;
        public Rectangle BoundingBox { get; set; }
        public bool Passable { get; set; }
        public Color Color { get; set; }

        public Block(int x, int y, Texture2D texture, int width, int height)
        {
            currentTexture = texture;
            Position = new Vector2(x, y);
            BoundingBox = new Rectangle(x, y, width, height);
            Passable = false;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            //spriteBatch.Draw(currentTexture, BoundingBox, Color.White);
            spriteBatch.Draw(currentTexture, Position, null, Color.White, 0, Vector2.Zero, 2f, SpriteEffects.None, 1f);
        }
    }
}
