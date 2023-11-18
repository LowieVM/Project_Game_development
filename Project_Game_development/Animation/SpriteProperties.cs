using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Game_development
{
    internal class SpriteProperties
    {
        public Texture2D Texture { get; set; }
        public Animation Animation { get; set; }
        public Vector2 RotationPoint { get; set; }

        public SpriteProperties(Texture2D texture, int fps, int xSprites, int ySprites, Vector2 rotationPoint)
        {
            Texture = texture;
            Animation = new Animation(fps, texture, xSprites, ySprites);
            RotationPoint = rotationPoint;
        }
        public SpriteProperties(Texture2D texture, Vector2 rotationPoint) : this(texture, 1, 1, 1, rotationPoint)
        {

        }
    }
}
