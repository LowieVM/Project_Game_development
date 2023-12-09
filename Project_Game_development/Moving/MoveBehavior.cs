using Microsoft.Xna.Framework;

namespace Project_Game_development
{
    internal abstract class MoveBehavior
    {
        public abstract Vector2 MoveDirection { get; set; }
        public abstract void UpdateMoveDirection(IMovable movable);
    }
}
