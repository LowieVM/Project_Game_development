using Microsoft.Xna.Framework;
using System;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Linq;

namespace Project_Game_development
{
    internal class AutoShootManager : ShootManager
    {
        private Random random = new Random();
        private double elapsedTime = 0;
        private int randomTime;

        public AutoShootManager(IPositional shooter, List<IHittable> enemies) : base(shooter, enemies)
        {
            randomTime = random.Next(1,5);
        }

        public override void Update(GameTime gameTime)
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

            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }
    }
}
