using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Game_development
{
    internal abstract class ShootManager
    {
        public BulletManager bulletManager { get; set; }
        protected IPositional shooter;
        public IPositional target { get; set; }

        public ShootManager(IPositional shooter, List<IHittable> enemies)
        {
            bulletManager = new BulletManager(enemies);
            target = enemies.FirstOrDefault();
            this.shooter = shooter;
        }

        public virtual void Update(GameTime gameTime)
        {
            bulletManager.Update(gameTime);
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            bulletManager.Draw(spriteBatch);
        }
    }
}
