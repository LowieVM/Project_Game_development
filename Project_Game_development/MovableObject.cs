using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Game_development
{
    internal abstract class MovableObject : IMovable, IRotatable
    {
        public Vector2 Position { get; set; }
        public float Rotation { get; set; }
        public Vector2 RotationPoint { get; set; }
        public Vector2 InitialSpeed { get; set; }
        public float MaxSpeed { get; set; }
        public Vector2 Acceleration { get; set; }
        public Vector2 CurrentAcceleration { get; set; }
        public MoveBehavior MoveBehavior { get; set; }
        protected Texture2D currentTexture;
        protected Animation currentAnimation;

        protected MovableObject(Vector2 position)
        {
            Position = position;
        }

        public virtual void Update(GameTime gameTime)
        {

        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            
        }
    }
}
