using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Project_Game_development
{
    enum PlayerState { Walking, Running, Pistol, Shotgun, ShotgunReloading, MiniGun, MiniGunShoot, Flamethrower }
    internal class Player : Character<PlayerState>
    {
        public KeyboardReader Keyboard { get; set; }

        public PlayerShootManager playerShootManager { get; set; }
        private MouseReader mouseReader;

        public Player(Vector2 position) : base(position)
        {
            mouseReader = new MouseReader();
            rotationManager.SetTarget(mouseReader);

            MoveBehavior = new MoveBehaviorKeyboard();
            playerShootManager = new PlayerShootManager(this);
            Keyboard = new KeyboardReader();
        }


        protected override void Die()
        {
            isAlive = false;
        }

        private void DrawGameOverScreen(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(GameTextures.ArialFont, "Game Over", new Vector2(200, 200), Color.White, 0f, Vector2.Zero, 1, SpriteEffects.None, 0);
        }


        public override void Update(GameTime gameTime)
        {
            if (isAlive)
            {
                base.Update(gameTime);

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
            else
            {
                DrawGameOverScreen(spriteBatch);
            }
        }
    }
}