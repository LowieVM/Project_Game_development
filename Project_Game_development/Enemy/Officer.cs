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
        public Vector2 InitialSpeed { get; set; } = new Vector2(0.5f, 0.5f);
        public float MaxSpeed { get; set; } = 3;
        public Vector2 Acceleration { get; set; } = new Vector2(0.1f, 0.1f);
        public float Rotation { get; set; } = 0;
        public Vector2 RotationPoint { get; set; } = new Vector2(0, 0);

        private IPositional target;

        private Dictionary<OfficerState, SpriteProperties> EnemyStateMappings;
        private SpriteEffects effect = SpriteEffects.None;
        private Texture2D currentTexture;
        private Animation currentAnimation;
        private OfficerState currentState;
        private MoveManager mover;
        private RotationManager rotationManager;

        public MoveBehavior MoveBehavior { get; set; }
        public Officer(Vector2 position, IPositional target)
        {
            EnemyStateMappings = ((OfficerState[])Enum.GetValues(typeof(OfficerState))).ToDictionary(state => state, state => GameTextures.GetOfficerProperties(state));


            Position = position;

            currentState = OfficerState.WalkingPistol;
            currentTexture = EnemyStateMappings[currentState].Texture;
            currentAnimation = EnemyStateMappings[currentState].Animation;

            this.target = target;
            mover = new MoveManager();
            rotationManager = new RotationManager(this, target);

            MoveBehavior = new MoveBehaviorFollow(target);

        }

        public void Update(GameTime gameTime)
        {
            rotationManager.Update();

            //moveBehavior.UpdateDirection(this, target);

            mover.Move(this, MoveBehavior);

            currentTexture = EnemyStateMappings[currentState].Texture;
            currentAnimation = EnemyStateMappings[currentState].Animation;
            RotationPoint = EnemyStateMappings[currentState].RotationPoint;
            currentAnimation.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(currentTexture, Position, currentAnimation.CurrentFrame.SourceRectangle, Color.White, Rotation, RotationPoint, 1.2f, effect, 0f);
        }
    }
}
