using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Project_Game_development
{
    enum OfficerState { Walking, WalkingPistol, Pistol, Dying }
    internal class Officer : Character<OfficerState>
    {
        public IPositional target { get; set; }

        private AutoShootManager autoShootManager;

        public Officer(Vector2 position, IPositional target) : base(position)
        {
            this.target = target;
            rotationManager.SetTarget(target);

            MoveBehavior = new MoveBehaviorFollow(target);
            autoShootManager = new AutoShootManager(this, target);
        }


        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            rotationManager.Update();
            currentAnimation.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            autoShootManager.Draw(spriteBatch);

            base.Draw(spriteBatch);
        }
    }
}