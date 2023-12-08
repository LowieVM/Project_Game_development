using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;


namespace Project_Game_development
{
    internal abstract class Level
    {
        public CharactersManager cManager { get; set; }
        public Level()
        {
            cManager = new CharactersManager();
        }
        public void Update(GameTime gameTime)
        {
            cManager.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            cManager.Draw(spriteBatch);
        }
    }
}
