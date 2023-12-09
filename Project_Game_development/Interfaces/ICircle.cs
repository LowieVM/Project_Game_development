using Microsoft.Xna.Framework.Graphics;

namespace Project_Game_development
{
    internal interface ICircle: IRotatable
    {
        public float CircleRadius { get; set; }
    }
}