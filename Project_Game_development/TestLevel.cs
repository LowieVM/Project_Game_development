using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;


namespace Project_Game_development
{
    internal class TestLevel
    {
        private Player player;
        private List<Officer> officers = new List<Officer>();
        private Random random = new Random();
        public TestLevel()
        {
            player = new Player(new Vector2(50, 50));
            for (int i = 0; i < 20; i++)
            {
                officers.Add(new Officer(new Vector2(random.Next(0, 1920), random.Next(0, 1080)), player) { MaxSpeed = 2});
            }
        }
        public void Update(GameTime gameTime)
        {
            if (officers.Count <= 1)
            {
                for (int i = 0; i < 20; i++)
                {
                    officers.Add(new Officer(new Vector2(random.Next(0, 1920), random.Next(0, 1080)), player) { MaxSpeed = 2 });
                }
            }



            player.Update(gameTime);
            foreach (var officer in officers)
            {
                officer.Update(gameTime);
            }

            List<Officer> officersToRemove = new List<Officer>();

            for (int i = officers.Count - 1; i >= 0; i--)
            {
                for (int ii = player.playerShootManager.bulletManager.bullets.Count - 1; ii >= 0; ii--)
                {
                    if (Vector2.Distance(player.playerShootManager.bulletManager.bullets[ii].Position, officers[i].Position) < 20)
                    {
                        officers.RemoveAt(i);
                        player.playerShootManager.bulletManager.bullets.RemoveAt(ii);
                        break;
                    }
                }
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
