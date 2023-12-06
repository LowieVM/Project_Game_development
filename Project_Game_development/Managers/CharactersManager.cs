using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Game_development
{
    internal class CharactersManager
    {
        public List<IHittable> playerTeam { get; set; } = new List<IHittable>();
        public List<IHittable> enemyTeam { get; set; } = new List<IHittable>();
        private Random random = new Random();


        public Player CreateAndAddPlayer(Vector2 position)
        {
            Player player = new Player(position, enemyTeam);
            player.CurrentState = PlayerState.Pistol;
            playerTeam.Add(player);
            return player;
        }

        public Officer CreateAndAddOfficer(Vector2 position)
        {
            Officer officer = new Officer(position, playerTeam) { MaxSpeed = 2 };
            officer.CurrentState = OfficerState.Pistol;
            enemyTeam.Add(officer);
            return officer;
        }

        public void CreateAndAddRandomOfficer(int amount, Rectangle spawnZone)
        {
            for (int i = 0; i < amount; i++)
            {
                CreateAndAddOfficer(new Vector2(random.Next(spawnZone.Left, spawnZone.Right), random.Next(spawnZone.Top, spawnZone.Bottom)));
            }
        }


        public void Update(GameTime gameTime)
        {
            foreach (var goodGuy in playerTeam)
            {
                goodGuy.Update(gameTime);
            }

            foreach (var enemy in enemyTeam)
            {
                if (enemy.TimeSinceDeath > 10)
                {
                    enemyTeam.Remove(enemy);
                    break;
                }
                enemy.Update(gameTime);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var goodGuy in playerTeam)
            {
                goodGuy.Draw(spriteBatch);
            }

            foreach (var officer in enemyTeam)
            {
                officer.Draw(spriteBatch);
            }
        }
    }
}
