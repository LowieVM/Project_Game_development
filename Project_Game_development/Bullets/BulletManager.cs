using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Game_development
{
    internal class BulletManager
    {
        private List<Bullet> bullets = new List<Bullet>();
        private Texture2D bulletTexture;

        public BulletManager(Texture2D bulletTexture)
        {
            this.bulletTexture = bulletTexture;
        }

        public void CreateBullet(Vector2 position, Vector2 target)
        {
            bullets.Add(new Bullet(bulletTexture, position, target));
        }

        public void Update(GameTime gameTime)
        {
            for (int i = 0; i < bullets.Count; i++)
            {
                bullets[i].Update(gameTime);

                if (IsBulletOutOfBounds(bullets[i].Position, 1920, 1080))
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

        private bool IsBulletOutOfBounds(Vector2 position, int screenWidth, int screenHeight)
        {
            if (position.X < 0 || position.X > screenWidth || position.Y < 0 || position.Y > screenHeight)
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
