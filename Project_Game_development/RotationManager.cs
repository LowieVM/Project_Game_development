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
        public IPositional target { get; set; }
        private IRotatable rotatable;
        public RotationManager(IRotatable rotatable, IPositional target)
        {
            this.rotatable = rotatable;
            this.target = target;
        }

        public void Update()
        {
            if (target is MouseReader)
            {
                MouseReader mouse = target as MouseReader;
                mouse.UpdateMouseVector();
            }
            Vector2 playerToTarged = target.Position - rotatable.Position;
            rotatable.Rotation = (float)Math.Atan2(playerToTarged.Y, playerToTarged.X);
        }
    }
}
