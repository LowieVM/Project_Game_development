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
            EnemyStateMappings = ((OfficerState[])Enum.GetValues(typeof(OfficerState))).ToDictionary(state => state, state => GameTextures.GetOfficerProperties(state));


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
