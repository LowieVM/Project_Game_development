using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Project_Game_development
{
    enum PlayerState { Walking, Running, Pistol, Shotgun, ShotgunReloading, MiniGun, MiniGunShoot, Flamethrower }
    internal class Player : Character<PlayerState>
    {
        public KeyboardReader Keyboard { get; set; }

        public PlayerShootManager playerShootManager { get; set; }
        private MouseReader mouseReader;

        public Player(Vector2 position, List<IHittable> enemies) : base(position, enemies)
        {
            mouseReader = new MouseReader();
            rotationManager.SetTarget(mouseReader);

            MoveBehavior = new MoveBehaviorKeyboard();
            playerShootManager = new PlayerShootManager(this, enemies);
            Keyboard = new KeyboardReader();
            Health = 100;
            LayerDepth = 0.49f;
        }


        protected override void Die()
        {
            isAlive = false;
        }


        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            if (isAlive)
            {
                Keyboard.UpdateState(this);
                mouseReader.Update();
                playerShootManager.Update(gameTime);
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (isAlive)
            {
                playerShootManager.Draw(spriteBatch);
                base.Draw(spriteBatch);
            }
        }
    }
}