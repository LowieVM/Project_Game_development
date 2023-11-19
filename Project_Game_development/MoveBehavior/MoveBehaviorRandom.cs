using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Game_development
{
    internal class MoveBehaviorRandom : MoveBehavior
    {
        private Vector2 initialDirection;
        private Random random;

        public override Vector2 MoveDirection { get; set; }

        public MoveBehaviorRandom(IPositional initialDirection)
        {
            this.initialDirection = initialDirection.Position;
            this.MoveDirection = initialDirection.Position;
            this.random = new Random();
        }

        public override void UpdateMoveDirection(IMovable movable)
        {
            if (random.NextDouble() < 0.02)
            {
                MoveDirection = new Vector2((float)random.NextDouble() - 0.5f, (float)random.NextDouble() - 0.5f);
                MoveDirection.Normalize();
            }
            else if (random.NextDouble() < 0.005)
            {
                MoveDirection = Vector2.Zero;
            }
        }
    }
}
