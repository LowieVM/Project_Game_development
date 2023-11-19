using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Game_development
{
    internal class MoveManager
    {
        private Vector2 currentAcceleration = new Vector2(1, 1);
        public void Move(IMovable movable, MoveBehavior moveBehavior)
        {
            moveBehavior.UpdateMoveDirection(movable);


            Vector2 distance = moveBehavior.MoveDirection * movable.InitialSpeed;

            if (distance.X != 0 || distance.Y != 0)
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
                v.X *= ratio;
                v.Y *= ratio;
            }
            return v;
        }

        private Vector2 LimitPosition(Vector2 position, int playerWidth)
        {
            if (position.X < playerWidth)
            {
                position.X = playerWidth;
            }
            else if (position.X > GameSettings.ScreenWidth - playerWidth)
            {
                position.X = GameSettings.ScreenWidth - playerWidth;
            }

            if (position.Y < playerWidth)
            {
                position.Y = playerWidth;
            }
            else if (position.Y > GameSettings.ScreenHeight - playerWidth)
            {
                position.Y = GameSettings.ScreenHeight - playerWidth;
            }

            return position;
        }
    }
}
