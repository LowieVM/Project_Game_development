using Microsoft.Xna.Framework;

namespace Project_Game_development
{
    internal class MoveBehaviorKeepDistance : MoveBehavior
    {
        public IPositional target { get; set; }
        public int ClosestDistance { get; set; }
        public override Vector2 MoveDirection { get; set; }

        public MoveBehaviorKeepDistance(IPositional target)
        {
            this.target = target;
        }

        public override void UpdateMoveDirection(IMovable movable)
        {
            Vector2 direction = Vector2.Zero;

            if (Vector2.Distance(movable.Position, target.Position) < ClosestDistance)
            {
                direction = Vector2.Normalize(movable.Position - target.Position);
            }
            MoveDirection = direction;
        }
    }
}
