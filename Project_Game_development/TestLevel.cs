using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Game_development
{
    internal class TestLevel
    {
        private Player player;
        private List<Officer> officers = new List<Officer>();
        public TestLevel()
        {
            player = new Player(new Vector2(50,50));
            officers.Add(new Officer(new Vector2(500, 500), player));
        }
        public void Update(GameTime gameTime)
        {
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
