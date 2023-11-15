using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Game_development
{
    internal class PlayerStateData
    {
        public Texture2D Texture { get; set; }
        public Animation Animation { get; set; }
        public Vector2 RotationPoint { get; set; }

        public PlayerStateData(Texture2D texture, Animation animation, Vector2 rotationPoint)
        {
            Texture = texture;
            Animation = animation;
            RotationPoint = rotationPoint;
        }
    }
}
