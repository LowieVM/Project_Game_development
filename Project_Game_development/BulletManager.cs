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

                if (IsBulletOutOfBounds(bullets[i]))
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

        private bool IsBulletOutOfBounds(Bullet bullet)
        {
            return false;
        }
    }
}
