using Microsoft.Xna.Framework;

namespace Project_Game_development
{
    internal interface IRotatable : IPositional
    {
        public float Rotation { get; set; }
        public Vector2 RotationPoint { get; set; }
    }
}