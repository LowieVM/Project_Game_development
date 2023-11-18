using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Game_development
{
    internal class PlayerShootManager
    {
        private BulletManager bulletManager;
        private MouseState mouseState;
        private bool wasLeftButtonPressed = false;
        private IPositional player;

        public PlayerShootManager(IPositional player)
        {
            bulletManager = new BulletManager();
            this.player = player;
        }

        public void Update(GameTime gameTime)
        {
            mouseState = Mouse.GetState();
            if (mouseState.LeftButton == ButtonState.Pressed && !wasLeftButtonPressed)
            {
                Vector2 mousePosition = new Vector2(mouseState.X, mouseState.Y);
                bulletManager.CreateBullet(player.Position, mousePosition);
            }
            wasLeftButtonPressed = (mouseState.LeftButton == ButtonState.Pressed);

            bulletManager.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            bulletManager.Draw(spriteBatch);
        }
    }
}
