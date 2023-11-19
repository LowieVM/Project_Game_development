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
        public Vector2 Acceleration { get; set; }
        public Vector2 Position { get; set; }
        public float Rotation { get; set; }
        public Vector2 RotationPoint { get; set; } = new Vector2(20, 13);
        public MoveBehavior MoveBehavior { get; set; }

        public Bullet(Vector2 position, IPositional target)
        {
            InitialSpeed = new Vector2(10, 10);
            MaxSpeed = 10;
            this.Position = position;

            this.texture = GameTextures.BulletTexture;
            animation = new Animation(1, texture, 1, 1);

            MoveBehavior = new MoveBehaviorFollow(target) { ClosestDistance = 0 };
            MoveBehavior.UpdateMoveDirection(this);
        }

        public void Update(GameTime gameTime)
        {
            Position += MoveBehavior.MoveDirection * InitialSpeed;

            Rotation = (float)Math.Atan2(MoveBehavior.MoveDirection.Y, MoveBehavior.MoveDirection.X);

            animation.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(GameTextures.BulletTexture, Position, animation.CurrentFrame.SourceRectangle, Color.White, Rotation, RotationPoint, 0.2f, effect, 0f);
        }

    }
}
