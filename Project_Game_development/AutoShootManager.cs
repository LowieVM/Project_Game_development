using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace Project_Game_development
{
    internal class AutoShootManager
    {
        private BulletManager bulletManager;
        private IPositional enemy;
        public IPositional target { get; set; }
        private Random random;
        private double elapsedTime = 0;
        private int randomTime;

        public AutoShootManager(IPositional enemy)
        {
            bulletManager = new BulletManager();
            this.enemy = enemy;
            random = new Random();
            randomTime = random.Next(1,5);
        }
        public AutoShootManager(IPositional enemy, IPositional target) : this(enemy)
        {
            this.target = target;
        }

        public void Update(GameTime gameTime)
        {
            if (target != null)
            {
                elapsedTime += gameTime.ElapsedGameTime.TotalSeconds;

                if (elapsedTime >= randomTime)
                {
                    bulletManager.CreateBullet(enemy.Position, new GamePosition() { Position = target.Position });
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
