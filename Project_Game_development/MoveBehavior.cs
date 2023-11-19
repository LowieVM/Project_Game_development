using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Game_development
{
    internal class MoveBehavior
    {
        public void UpdateDirection(IMovable movable, IPositional target)
        {
            movable.MoveDirection = Vector2.Normalize(target.Position - movable.Position);
            if (Vector2.Distance(movable.Position, target.Position) < 50)
            {
                movable.MoveDirection = Vector2.Zero;
            }
        }
    }
}
