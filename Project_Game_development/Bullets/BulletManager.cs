using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Project_Game_development
{
    internal class BulletManager
    {
        public List<Bullet> bullets { get; set; } = new List<Bullet>();

        public BulletManager()
        {

        }

        public void CreateBullet(Vector2 position, IPositional target)
        {
            bullets.Add(new Bullet(position, target));
        }

        public void Update(GameTime gameTime)
        {
            for (int i = 0; i < bullets.Count; i++)
            {
                bullets[i].Update(gameTime);

                if (IsBulletOutOfBounds(bullets[i].Position))
                {
                    bullets.RemoveAt(i);
                    i--;
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var bullet in bullets)
            {
                bullet.Draw(spriteBatch);
            }
        }

        private bool IsBulletOutOfBounds(Vector2 position)
        {
            if (position.X < 0 || position.X > GameSettings.ScreenWidth || position.Y < 0 || position.Y > GameSettings.ScreenHeight)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
