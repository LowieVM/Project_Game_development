using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Game_development
{
    enum EnemyState { Walking, WalkingPistol, Pistol, Dying }
    internal class Enemy : IRotatable, IMovable
    {
        public Vector2 Position { get; set; }
        public Vector2 InitialSpeed { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public float MaxSpeed { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Vector2 MoveDirection { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Vector2 Acceleration { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public float Rotation { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Vector2 RotationPoint { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        private Dictionary<EnemyState, SpriteProperties> EnemyStateMappings;
        public Enemy(Texture2D walkTexture, Texture2D walkPistol, Texture2D pistolTexture, Texture2D dieTexture)
        {
            EnemyStateMappings = new Dictionary<EnemyState, SpriteProperties>
            {
                { EnemyState.Walking, new SpriteProperties(walkTexture, 12, 8, 1, new Vector2(17, 31)) },
                { EnemyState.WalkingPistol, new SpriteProperties(walkPistol, 12, 6, 1, new Vector2(45, 45)) },
                { EnemyState.Pistol, new SpriteProperties(pistolTexture, new Vector2(26, 31)) },
                { EnemyState.Dying, new SpriteProperties(dieTexture, 12, 4, 1, new Vector2(34, 26)) },
            };
        }

        public void Update()
        {

        }

        public void Draw()
        {

        }
    }
}
