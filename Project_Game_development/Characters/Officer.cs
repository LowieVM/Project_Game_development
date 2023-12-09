using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Linq;

namespace Project_Game_development
{
    enum OfficerState { Walking, WalkingPistol, Pistol, Dying }
    internal class Officer : Character<OfficerState>
    {

        public AutoShootManager autoShootManager { get; set; }

        public Officer(Vector2 position, MoveManager moveManager, List<IHittable> enemies) : base(position, moveManager, enemies)
        {
            rotationManager.SetTarget(enemies.FirstOrDefault());
            MaxSpeed = 2;

            MoveBehavior = new MoveBehaviorRandom();
            autoShootManager = new AutoShootManager(this, enemies);
        }


        protected override void Die()
        {
            CurrentState = OfficerState.Dying;
            autoShootManager.target = null;
        }


        public override void Update(GameTime gameTime)
        {
            if (CurrentState != OfficerState.Dying && autoShootManager.target != null)
            {
                CurrentState = OfficerState.WalkingPistol;
                rotationManager.SetTarget(autoShootManager.target);
            }
            else if (CurrentState != OfficerState.Dying && autoShootManager.target == null)
            {
                CurrentState = OfficerState.Walking;
            }
            if (CurrentState == OfficerState.Dying && isAlive)
            {
                currentTexture = stateMappings[CurrentState].Texture;
                currentAnimation = stateMappings[CurrentState].Animation;
                RotationPoint = stateMappings[CurrentState].RotationPoint;
                if (!currentAnimation.isLastFrame())
                {
                    currentAnimation.Update(gameTime);
                }
                else
                {
                    isAlive = false;
                }
            }
            else
            {
                base.Update(gameTime);
            }

            autoShootManager.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            autoShootManager.Draw(spriteBatch);

            base.Draw(spriteBatch);
        }
    }
}