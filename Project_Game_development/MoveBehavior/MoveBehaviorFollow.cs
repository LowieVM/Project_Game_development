﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Game_development
{
    internal class MoveBehaviorFollow : MoveBehavior
    {
        public IPositional target { get; set; }
        public override Vector2 MoveDirection { get; set; }

        public MoveBehaviorFollow(IPositional target)
        {
            this.target = target;
        }
        public override void UpdateMoveDirection(IMovable movable)
        {
            Vector2 direction = Vector2.Zero;

            if (Vector2.Distance(movable.Position, target.Position) > 50)
            {
                direction = Vector2.Normalize(target.Position - movable.Position);
            }
            MoveDirection = direction;
        }
    }
}
