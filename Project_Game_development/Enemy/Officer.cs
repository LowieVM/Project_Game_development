using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Project_Game_development
{
    enum OfficerState { Walking, WalkingPistol, Pistol, Dying }
    internal class Officer : IRotatable, IMovable
    {
        public OfficerState CurrentState { get; set; }
        public Vector2 Position { get; set; } = new Vector2(200, 200);
        public float Rotation { get; set; }
        public Vector2 RotationPoint { get; set; }
        public Vector2 InitialSpeed { get; set; } = new Vector2(0.5f, 0.5f);
        public float MaxSpeed { get; set; } = 3;
        public Vector2 Acceleration { get; set; } = new Vector2(0.1f, 0.1f);
        public MoveBehavior MoveBehavior { get; set; }
        public IPositional target { get; set; }

        private Dictionary<OfficerState, SpriteProperties> EnemyStateMappings;
        private Texture2D currentTexture;
        private Animation currentAnimation;
        private RotationManager rotationManager;
        private MoveManager mover;
        private AutoShootManager autoShootManager;

        public Officer(Vector2 position, IPositional target)
        {
            EnemyStateMappings = ((OfficerState[])Enum.GetValues(typeof(OfficerState))).ToDictionary(state => state, state => GameTextures.GetOfficerProperties(state));
            CurrentState = OfficerState.WalkingPistol;
            Position = position;
            this.target = target;
            
            rotationManager = new RotationManager(this, target);
            mover = new MoveManager();
            MoveBehavior = new MoveBehaviorFollow(target);
            autoShootManager = new AutoShootManager(this, target);
        }


        public void Update(GameTime gameTime)
        {
            currentTexture = EnemyStateMappings[CurrentState].Texture;
            currentAnimation = EnemyStateMappings[CurrentState].Animation;
            RotationPoint = EnemyStateMappings[CurrentState].RotationPoint;

            mover.Move(this, MoveBehavior);
            rotationManager.Update();
            autoShootManager.Update(gameTime);
            currentAnimation.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            autoShootManager.Draw(spriteBatch);
            spriteBatch.Draw(currentTexture, Position, currentAnimation.CurrentFrame.SourceRectangle, Color.White, Rotation, RotationPoint, 1.2f, SpriteEffects.None, 0f);
        }
    }
}
