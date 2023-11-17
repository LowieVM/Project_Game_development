using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Game_development
{
    internal class Bullet : IMovable, IRotatable
    {
        private Texture2D texture;
        private Animation animation;
        private SpriteEffects effect = SpriteEffects.None;
        public Vector2 InitialSpeed { get; set; }
        public float MaxSpeed { get; set; }
        public Vector2 MoveDirection { get; set; }
        public Vector2 Acceleration { get; set; }
        public Vector2 Position { get; set; }
        public float Rotation { get; set; }
        public Vector2 RotationPoint { get; set; } = new Vector2(20, 13);

        public Bullet(Texture2D texture, Vector2 position, Vector2 target)
        {
            InitialSpeed = new Vector2(10, 10);
            MaxSpeed = 10;
            this.Position = position;
            this.MoveDirection = Vector2.Normalize(target - Position);

            this.texture = texture;
            animation = new Animation(1, texture, 1, 1);
        }

        public void Update(GameTime gameTime)
        {
            Position += MoveDirection * InitialSpeed;

            Rotation = (float)Math.Atan2(MoveDirection.Y, MoveDirection.X);

            animation.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, Position, animation.CurrentFrame.SourceRectangle, Color.White, Rotation, RotationPoint, 1f, effect, 0f);
        }

    }
}
