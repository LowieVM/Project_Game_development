using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;


namespace Project_Game_development
{
    internal class TestLevel
    {
        CharactersManager cManager;
        public TestLevel()
        {
            cManager = new CharactersManager();
            cManager.CreateAndAddPlayer(new Vector2(50, 50));
            cManager.CreateAndAddRandomOfficer(20, new Rectangle(500, 100, 500, 500));
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
