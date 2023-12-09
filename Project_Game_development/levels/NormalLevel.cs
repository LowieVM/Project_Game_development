using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Game_development
{
    internal class NormalLevel : Level
    {
        public NormalLevel()
        {
            cManager.CreateAndAddPlayer(new Vector2(50, 50));
            for (int i = 0; i < 20; i++)
            {
                cManager.CreateAndAddOfficer(new Rectangle(500, 100, 500, 500), cManager.enemyTeam);
            }
            Officer friendly = cManager.CreateAndAddOfficer(new Vector2(50, 500), cManager.playerTeam);
            friendly.Health = 999;
            friendly.MoveBehavior = new MoveBehaviorFollow(cManager.playerTeam[0]);
        }
    }
}
