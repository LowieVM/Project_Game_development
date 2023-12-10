using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Game_development
{
    internal class NormalLevel : Level
    {
        public NormalLevel(GraphicsDevice graphicsDevice) : base(new Environment(graphicsDevice))
        {
            Player player = cManager.CreateAndAddPlayer(new Vector2(50, 50));
            player.Health = 499;
            for (int i = 0; i < 5; i++)
            {
                cManager.CreateAndAddOfficer(new Rectangle(500, 100, 500, 500), cManager.EnemyTeam);
            }
            for (int i = 0; i < 5; i++)
            {
                Officer officer = cManager.CreateAndAddOfficer(new Rectangle(1300, 500, 500, 500), cManager.EnemyTeam);
                officer.MoveBehavior = new MoveBehaviorFollow(player) { ClosestDistance = 100 };
            }
            for (int i = 0; i < 5; i++)
            {
                Officer officer = cManager.CreateAndAddOfficer(new Rectangle(200, 500, 500, 500), cManager.EnemyTeam);
                officer.MoveBehavior = new MoveBehaviorKeepDistance(player) { ClosestDistance = 200 };
            }
            Officer friendly = cManager.CreateAndAddOfficer(new Vector2(50, 500), cManager.PlayerTeam);
            friendly.Health = 999;
            friendly.MoveBehavior = new MoveBehaviorFollow(cManager.PlayerTeam[0]);
        }
    }
}
