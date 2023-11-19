﻿using Microsoft.Xna.Framework;
using System;

namespace Project_Game_development
{
    internal abstract class Character : IRotatable, IMovable
    {
        public float Rotation { get; set; }
        public Vector2 RotationPoint { get; set; }
        public Vector2 Position { get; set; }
        public Vector2 InitialSpeed { get; set; }
        public float MaxSpeed { get; set; }
        public Vector2 Acceleration { get; set; }
        public MoveBehavior MoveBehavior { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Character()
        {

        }
    }
}
