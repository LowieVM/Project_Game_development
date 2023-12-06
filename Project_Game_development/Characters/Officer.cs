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

        public Officer(Vector2 position, List<IHittable> enemies) : base(position, enemies)
        {
            rotationManager.SetTarget(enemies.FirstOrDefault());

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
            if (isAlive && autoShootManager.target != null)
            {
                CurrentState = OfficerState.WalkingPistol;
            }
            else if (isAlive && autoShootManager.target == null)
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