using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;


namespace Project_Game_development
{
    internal class TestLevel
    {
        public CharactersManager cManager { get; set; }
        public TestLevel()
        {
            cManager = new CharactersManager();
            cManager.CreateAndAddPlayer(new Vector2(50, 50));
            cManager.CreateAndAddRandomOfficer(2, new Rectangle(500, 100, 500, 500));
            Officer friendly = new Officer(new Vector2(50, 300), cManager.enemyTeam);
            friendly.Health = 999;
            friendly.MoveBehavior = new MoveBehaviorFollow(cManager.playerTeam[0]);
            cManager.playerTeam.Add(friendly);
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
