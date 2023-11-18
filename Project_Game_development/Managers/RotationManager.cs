using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Game_development
{
    internal class RotationManager
    {
        private IPositional target;
        private IRotatable rotatable;
        public RotationManager(IRotatable rotatable, IPositional target)
        {
            this.rotatable = rotatable;
            this.target = target;
        }

        public void SetTarget(IPositional target)
        {
            this.target = target;
        }

        public void Update()
        {
            Vector2 playerToTarget = target.Position - rotatable.Position;
            rotatable.Rotation = (float)Math.Atan2(playerToTarget.Y, playerToTarget.X);
        }
    }
}
