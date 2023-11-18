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
        public Vector2 Position { get; set; } = new Vector2(200, 200);
        public Vector2 InitialSpeed { get; set; } = new Vector2(5, 5);
        public float MaxSpeed { get; set; } = 10;
        public Vector2 MoveDirection { get; set; } = new Vector2(0, 0);
        public Vector2 Acceleration { get; set; } = new Vector2(0.1f, 0.1f);
        public float Rotation { get; set; } = 0;
        public Vector2 RotationPoint { get; set; } = new Vector2(0, 0);

        private Dictionary<EnemyState, SpriteProperties> EnemyStateMappings;
        private SpriteEffects effect = SpriteEffects.None;
        private Texture2D currentTexture;
        private Animation currentAnimation;
        private EnemyState currentState;
        public Enemy(Texture2D walkTexture, Texture2D walkPistol, Texture2D pistolTexture, Texture2D dieTexture)
        {
            EnemyStateMappings = new Dictionary<EnemyState, SpriteProperties>
            {
                { EnemyState.Walking, new SpriteProperties(walkTexture, 12, 8, 1, new Vector2(17, 31)) },
                { EnemyState.WalkingPistol, new SpriteProperties(walkPistol, 12, 6, 1, new Vector2(45, 45)) },
                { EnemyState.Pistol, new SpriteProperties(pistolTexture, new Vector2(26, 31)) },
                { EnemyState.Dying, new SpriteProperties(dieTexture, 12, 4, 1, new Vector2(34, 26)) },
            };
            currentState = EnemyState.Pistol;
            currentTexture = EnemyStateMappings[currentState].Texture;
            currentAnimation = EnemyStateMappings[currentState].Animation;
        }

        public void Update(GameTime gameTime)
        {
            currentTexture = EnemyStateMappings[currentState].Texture;
            currentAnimation = EnemyStateMappings[currentState].Animation;
            RotationPoint = EnemyStateMappings[currentState].RotationPoint;
            currentAnimation.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(currentTexture, Position, currentAnimation.CurrentFrame.SourceRectangle, Color.White, Rotation, RotationPoint, 1f, effect, 0f);
        }
    }
}
