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
        public List<IHittable> PlayerTeam { get; set; }
        public List<IHittable> EnemyTeam { get; set; }
        private Random random = new Random();
        private MoveManager moveManager;

        public CharactersManager()
        {
            PlayerTeam = new List<IHittable>();
            EnemyTeam = new List<IHittable>();
            moveManager = new MoveManager(PlayerTeam, EnemyTeam, new List<IRectangle>());
        }

        public Player CreateAndAddPlayer(Vector2 position)
        {
            Player player = new Player(position, moveManager, EnemyTeam);
            player.CurrentState = PlayerState.Pistol;
            PlayerTeam.Add(player);
            return player;
        }

        public Officer CreateAndAddOfficer(Vector2 position, List<IHittable> team)
        {
            List<IHittable> otherTeam;
            if (team == EnemyTeam)
            {
                otherTeam = PlayerTeam;
            }
            else
            {
                otherTeam = EnemyTeam;
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
            foreach (var goodGuy in PlayerTeam)
            {
                if (goodGuy is Officer)
                {
                    Officer officer = goodGuy as Officer;
                    if (officer.isAlive)
                    {
                        officer.autoShootManager.target = officer.Enemies.FirstOrDefault(enemy => enemy.isAlive);
                    }
                }
                goodGuy.Update(gameTime);
            }

            foreach (var enemy in EnemyTeam)
            {
                if (enemy.TimeSinceDeath > 10)
                {
                    EnemyTeam.Remove(enemy);
                    break;
                }
                enemy.Update(gameTime);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var goodGuy in PlayerTeam)
            {
                goodGuy.Draw(spriteBatch);
            }

            foreach (var officer in EnemyTeam)
            {
                officer.Draw(spriteBatch);
            }
        }
    }
}
