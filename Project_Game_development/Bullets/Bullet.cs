using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Project_Game_development
{
    internal class Bullet : MovableObject
    {
        private SpriteEffects effect = SpriteEffects.None;

        public Bullet(Vector2 position, IPositional target) : base(position)
        {
            RotationPoint = GameTextures.BulletRotationPoint;
            InitialSpeed = new Vector2(10, 10);
            MaxSpeed = 10;

            currentTexture = GameTextures.BulletTexture;
            currentAnimation = new Animation(1, currentTexture, 1, 1);

            MoveBehavior = new MoveBehaviorFollow(target) { ClosestDistance = 0 };
            MoveBehavior.UpdateMoveDirection(this);
        }

        public override void Update(GameTime gameTime)
        {
            Position += MoveBehavior.MoveDirection * InitialSpeed;

            Rotation = (float)Math.Atan2(MoveBehavior.MoveDirection.Y, MoveBehavior.MoveDirection.X);

            currentAnimation.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(currentTexture, Position, currentAnimation.CurrentFrame.SourceRectangle, Color.White, Rotation, RotationPoint, 0.2f, effect, 0.4f);
        }

    }
}
