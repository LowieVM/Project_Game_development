using Microsoft.Xna.Framework;

namespace Project_Game_development
{
    internal class MoveBehaviorFollow : MoveBehavior
    {
        public IPositional target { get; set; }
        public override Vector2 MoveDirection { get; set; }
        public int ClosestDistance { get; set; } = 50;

        public MoveBehaviorFollow(IPositional target)
        {
            this.target = target;
        }
        public override void UpdateMoveDirection(IMovable movable)
        {
            Vector2 direction = Vector2.Zero;

            if (Vector2.Distance(movable.Position, target.Position) > ClosestDistance)
            {
                direction = Vector2.Normalize(target.Position - movable.Position);
            }
            MoveDirection = direction;
        }
    }
}
