using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Game_development
{
    internal class HardLevel : Level
    {
        public HardLevel(GraphicsDevice graphicsDevice) : base(new Environment(graphicsDevice))
        {
            Player player = cManager.CreateAndAddPlayer(new Vector2(1920/2, 1080/2));
            player.Health = 245;

            for (int i = 0; i < 10; i++)
            {
                for (int ii = 0; ii < 2; ii++)
                {
                    Officer officer = cManager.CreateAndAddOfficer(new Vector2((i * 180) + 50, (ii * 1000) + 50), cManager.EnemyTeam);
                    officer.MoveBehavior = new MoveBehaviorKeepDistance(player) { ClosestDistance = 50 };
                }
            }

            for (int i = 0; i < 2; i++)
            {
                for (int ii = 0; ii < 5; ii++)
                {
                    Officer officer = cManager.CreateAndAddOfficer(new Vector2((i * 1850) + 50, (ii * 180) + 100), cManager.EnemyTeam);
                    officer.MoveBehavior = new MoveBehaviorFollow(player) { ClosestDistance = 50 };
                }
            }
        }
    }
}
