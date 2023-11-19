﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Game_development
{
    internal abstract class MoveBehavior
    {
        public abstract Vector2 MoveDirection { get; set; }
        public abstract void UpdateMoveDirection(IMovable movable);
    }
}
