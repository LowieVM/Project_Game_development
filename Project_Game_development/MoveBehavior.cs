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
        public IPositional target { get; set; }
        public IMovable movable { get; set; }

        public MoveBehavior(IPositional target)
        {
            this.target = target;
        }
        public Vector2 GetDirection(IMovable movable)
        {
            this.movable = movable;
            return DirectionTo();
        }

        private Vector2 DirectionTo()
        {
            Vector2 direction = Vector2.Zero;
            
            if (Vector2.Distance(movable.Position, target.Position) > 50)
            {
                direction = Vector2.Normalize(target.Position - movable.Position);
            }
            return direction;
        }
    }
}
