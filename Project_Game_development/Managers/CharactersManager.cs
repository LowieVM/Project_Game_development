using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        private MoveManager moveManager = new MoveManager();


        public Player CreateAndAddPlayer(Vector2 position)
        {
            Player player = new Player(position, moveManager, enemyTeam);
            player.CurrentState = PlayerState.Pistol;
            playerTeam.Add(player);
            return player;
        }

        public Officer CreateAndAddOfficer(Vector2 position, List<IHittable> team)
        {
            List<IHittable> otherTeam;
            if (team == enemyTeam)
            {
                otherTeam = playerTeam;
            }
            else
            {
                otherTeam = enemyTeam;
            }
            Officer officer = new Officer(position, moveManager, otherTeam);
            team.Add(officer);
            return officer;
        }

        public Officer CreateAndAddOfficer(Rectangle spawnZone, List<IHittable> team)
        {
            Officer officer = CreateAndAddOfficer(new Vector2(random.Next(spawnZone.Left, spawnZone.Right), random.Next(spawnZone.Top, spawnZone.Bottom)), team);
            return officer;
        }


        public void Update(GameTime gameTime)
        {
            foreach (var goodGuy in playerTeam)
            {
                if (goodGuy is Officer)
                {
                    Officer officer = goodGuy as Officer;
                    if (officer.isAlive)
                    {
                        officer.autoShootManager.target = officer.enemies.FirstOrDefault(enemy => enemy.isAlive);
                    }
                }
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
