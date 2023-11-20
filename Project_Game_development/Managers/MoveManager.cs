using Microsoft.Xna.Framework;

namespace Project_Game_development
{
    internal class MoveManager
    {
        private Vector2 currentAcceleration = new Vector2(1, 1);
        public void Move(IMovable movable, MoveBehavior moveBehavior)
        {
            moveBehavior.UpdateMoveDirection(movable);


            Vector2 distance = moveBehavior.MoveDirection * movable.InitialSpeed;

            if (distance != Vector2.Zero)
            {
                currentAcceleration += movable.Acceleration;
            }
            else
            {
                currentAcceleration = new Vector2(1, 1);
            }

            distance *= currentAcceleration;
            distance = LimitSpeed(distance, movable.MaxSpeed);

            movable.Position = movable.Position + distance;

            movable.Position = LimitPosition(movable.Position + distance, 20);
        }

        private Vector2 LimitSpeed(Vector2 v, float max)
        {
            if (v.Length() > max)
            {
                float ratio = max / v.Length();
                v *= ratio;
            }
            if (!(float.IsNaN(v.X) || float.IsNaN(v.X)))
            {
                return v;
            }
            return Vector2.Zero;
        }

        private Vector2 LimitPosition(Vector2 position, int playerWidth)
        {
            position.X = MathHelper.Clamp(position.X, playerWidth, GameSettings.ScreenWidth - playerWidth);
            position.Y = MathHelper.Clamp(position.Y, playerWidth, GameSettings.ScreenHeight - playerWidth);

            return position;
        }
    }
}
