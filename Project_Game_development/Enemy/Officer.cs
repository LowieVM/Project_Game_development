using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Game_development
{
    enum OfficerState { Walking, WalkingPistol, Pistol, Dying }
    internal class Officer : IRotatable, IMovable
    {
        public Vector2 Position { get; set; } = new Vector2(200, 200);
        public Vector2 InitialSpeed { get; set; } = new Vector2(5, 5);
        public float MaxSpeed { get; set; } = 10;
        public Vector2 MoveDirection { get; set; } = new Vector2(0, 0);
        public Vector2 Acceleration { get; set; } = new Vector2(0.1f, 0.1f);
        public float Rotation { get; set; } = 0;
        public Vector2 RotationPoint { get; set; } = new Vector2(0, 0);

        private Dictionary<OfficerState, SpriteProperties> EnemyStateMappings;
        private SpriteEffects effect = SpriteEffects.None;
        private Texture2D currentTexture;
        private Animation currentAnimation;
        private OfficerState currentState;
        public Officer(Vector2 position)
        {
            EnemyStateMappings = new Dictionary<OfficerState, SpriteProperties>
            {
                { OfficerState.Walking, new SpriteProperties(GameTextures.OfficerWalkTexture, 12, 8, 1, GameTextures.OfficerWalkRotationPoint) },
                { OfficerState.WalkingPistol, new SpriteProperties(GameTextures.OfficerPistolWalkTexture, 12, 6, 1, GameTextures.OfficerPistolWalkRotationPoint) },
                { OfficerState.Pistol, new SpriteProperties(GameTextures.OfficerPistolTexture, GameTextures.OfficerPistolRotationPoint) },
                { OfficerState.Dying, new SpriteProperties(GameTextures.OfficerDieTexture, 12, 4, 1, GameTextures.OfficerDieRotationPoint) },
            };

            Position = position;

            currentState = OfficerState.Pistol;
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
