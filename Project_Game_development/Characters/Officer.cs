﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Project_Game_development
{
    enum OfficerState { Walking, WalkingPistol, Pistol, Dying }
    internal class Officer : Character<OfficerState>
    {
        public IPositional target { get; set; }

        public AutoShootManager autoShootManager { get; set; }

        public Officer(Vector2 position, List<IHittable> enemies) : base(position, enemies)
        {
            this.target = target;
            rotationManager.SetTarget(target);

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
            else if (isAlive)
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