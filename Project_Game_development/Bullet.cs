using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Game_development
{
    internal class Bullet : IMovable, IRotatable
    {
        public Vector2 InitialSpeed { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public float MaxSpeed { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Vector2 MoveDirection { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Vector2 Acceleration { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Vector2 Position { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public float Rotation { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Vector2 RotationPoint { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
