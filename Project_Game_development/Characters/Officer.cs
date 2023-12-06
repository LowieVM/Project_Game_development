using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Project_Game_development
{
    enum OfficerState { Walking, WalkingPistol, Pistol, Dying }
    internal class Officer : Character<OfficerState>
    {
        public IPositional target { get; set; }

        public AutoShootManager autoShootManager { get; set; }

        public Officer(Vector2 position, IPositional target) : base(position)
        {
            this.target = target;
            rotationManager.SetTarget(target);

            MoveBehavior = new MoveBehaviorRandom();
            autoShootManager = new AutoShootManager(this, target);
        }


        protected override void Die()
        {
            CurrentState = OfficerState.Dying;
            autoShootManager.target = null;
        }


        public override void Update(GameTime gameTime)
        {
            if (CurrentState == OfficerState.Dying)
            {
                currentTexture = stateMappings[CurrentState].Texture;
                currentAnimation = stateMappings[CurrentState].Animation;
                RotationPoint = stateMappings[CurrentState].RotationPoint;
                if (!currentAnimation.isLastFrame())
                {
                    currentAnimation.Update(gameTime);
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