using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Project_Game_development
{
    internal class MoveManager
    {
        private List<ICircle> CircleObjects { get; set; }
        private List<IRectangle> RectangleObjects { get; set; } = new List<IRectangle>();
        public List<IHittable> PlayerTeam { get; set; }
        public List<IHittable> EnemyTeam { get; set; }

        public MoveManager(List<IHittable> PlayerTeam, List<IHittable> EnemyTeam, List<IRectangle> rectangleObjects)
        {
            this.PlayerTeam = PlayerTeam;
            this.EnemyTeam = EnemyTeam;
            CircleObjects = PlayerTeam.OfType<ICircle>().Concat(EnemyTeam.OfType<ICircle>()).ToList();
            RectangleObjects = rectangleObjects;
        }
        public void Move(IMovable movable, MoveBehavior moveBehavior)
        {
            CircleObjects = PlayerTeam.OfType<ICircle>().Concat(EnemyTeam.OfType<ICircle>()).ToList();
            moveBehavior.UpdateMoveDirection(movable);


            Vector2 distance = moveBehavior.MoveDirection * movable.InitialSpeed;

            if (distance != Vector2.Zero)
            {
                movable.CurrentAcceleration += movable.Acceleration;
            }
            else
            {
                movable.CurrentAcceleration = new Vector2(1, 1);
            }

            distance *= movable.CurrentAcceleration;
            distance = LimitSpeed(distance, movable.MaxSpeed);


            movable.Position = LimitPosition(movable, movable.Position, distance, 20);
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

        private Vector2 LimitPosition(IMovable movable, Vector2 prevPosition, Vector2 distanceToMove, int playerWidth)
        {
            Vector2 NewPosition = prevPosition + distanceToMove;
            NewPosition.X = MathHelper.Clamp(NewPosition.X, playerWidth, GameSettings.ScreenWidth - playerWidth);
            NewPosition.Y = MathHelper.Clamp(NewPosition.Y, playerWidth, GameSettings.ScreenHeight - playerWidth);

            foreach (var rect in RectangleObjects)
            {
                float closestX = MathHelper.Clamp(NewPosition.X, rect.Rectangle.Left, rect.Rectangle.Right);
                float closestY = MathHelper.Clamp(NewPosition.Y, rect.Rectangle.Top, rect.Rectangle.Bottom);

                Vector2 closestPoint = new Vector2(closestX, closestY);
                float distance = Vector2.Distance(NewPosition, closestPoint);

                if (distance < playerWidth)
                {
                    NewPosition = prevPosition;
                    break;
                }
            }

            foreach (var circle in CircleObjects)
            {
                if (circle != movable)
                {
                    float distance = Vector2.Distance(NewPosition, circle.Position);

                    if (distance < (playerWidth + circle.CircleRadius))
                    {
                        NewPosition = prevPosition;
                        break;
                    }
                }
            }

            return NewPosition;
        }
    }
}
