using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Project_Game_development
{
    internal class PlayerShootManager : ShootManager
    {
        private MouseState mouseState;
        private bool wasLeftButtonPressed = false;

        public PlayerShootManager(IPositional shooter, List<IHittable> enemies) : base(shooter, enemies)
        {

        }

        public override void Update(GameTime gameTime)
        {
            mouseState = Mouse.GetState();
            if (mouseState.LeftButton == ButtonState.Pressed && !wasLeftButtonPressed)
            {
                Vector2 mousePosition = new Vector2(mouseState.X, mouseState.Y);
                bulletManager.CreateBullet(shooter.Position, new GamePosition() { Position = mousePosition});
            }
            wasLeftButtonPressed = (mouseState.LeftButton == ButtonState.Pressed);

            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }
    }
}
