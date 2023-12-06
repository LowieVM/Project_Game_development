using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;


namespace Project_Game_development
{
    internal class TestLevel
    {
        private Player player;
        private List<IHittable> playerTeam = new List<IHittable>();
        private List<IHittable> officers = new List<IHittable>();
        private Random random = new Random();
        public TestLevel()
        {
            player = new Player(new Vector2(50, 50), officers);
            playerTeam.Add(player);
            for (int i = 0; i < 20; i++)
            {
                officers.Add(new Officer(new Vector2(random.Next(0, 1920), random.Next(0, 1080)), playerTeam) { MaxSpeed = 2});
            }
        }
        public void Update(GameTime gameTime)
        {
            if (officers.Count <= 1)
            {
                for (int i = 0; i < 20; i++)
                {
                    officers.Add(new Officer(new Vector2(random.Next(0, 1920), random.Next(0, 1080)), playerTeam) { MaxSpeed = 2 });
                }
            }

            player.Update(gameTime);
            foreach (var officer in officers)
            {
                officer.Update(gameTime);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            player.Draw(spriteBatch);
            foreach (var officer in officers)
            {
                officer.Draw(spriteBatch);
            }
        }
    }
}
