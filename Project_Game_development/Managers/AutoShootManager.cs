using Microsoft.Xna.Framework;
using System;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Linq;

namespace Project_Game_development
{
    internal class AutoShootManager
    {
        public BulletManager bulletManager { get; set; }
        private IPositional shooter;
        public IPositional target { get; set; }
        private Random random;
        private double elapsedTime = 0;
        private int randomTime;

        public AutoShootManager(IPositional shooter, List<IHittable> enemies)
        {
            bulletManager = new BulletManager(enemies);
            this.target = enemies.FirstOrDefault();
            this.shooter = shooter;
            random = new Random();
            randomTime = random.Next(1,5);
        }

        public void Update(GameTime gameTime)
        {
            if (target != null)
            {
                elapsedTime += gameTime.ElapsedGameTime.TotalSeconds;

                if (elapsedTime >= randomTime)
                {
                    bulletManager.CreateBullet(shooter.Position, new GamePosition() { Position = target.Position });
                    elapsedTime = 0;
                    randomTime = random.Next(1, 5);
                }
            }

            bulletManager.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            bulletManager.Draw(spriteBatch);
        }
    }
}
