using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Game_development
{
    internal class EasyLevel : Level
    {
        public EasyLevel()
        {
            cManager.CreateAndAddPlayer(new Vector2(50, 50));
            cManager.CreateAndAddRandomOfficer(2, new Rectangle(500, 100, 500, 500));
            Officer friendly = new Officer(new Vector2(50, 300), cManager.enemyTeam);
            friendly.Health = 999;
            friendly.MoveBehavior = new MoveBehaviorFollow(cManager.playerTeam[0]);
            cManager.playerTeam.Add(friendly);
        }
    }
}
