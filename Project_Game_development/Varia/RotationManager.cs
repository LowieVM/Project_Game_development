﻿using Microsoft.Xna.Framework;
using System;

namespace Project_Game_development
{
    internal class RotationManager
    {
        private IPositional target;
        private IRotatable rotatable;
        public RotationManager(IRotatable rotatable)
        {
            this.rotatable = rotatable;
        }
        public RotationManager(IRotatable rotatable, IPositional target) : this(rotatable)
        {
            this.target = target;
        }

        public void SetTarget(IPositional target)
        {
            this.target = target;
        }

        public void Update()
        {
            if (target != null)
            {
                Vector2 playerToTarget = target.Position - rotatable.Position;
                rotatable.Rotation = (float)Math.Atan2(playerToTarget.Y, playerToTarget.X);
            }
        }
    }
}
