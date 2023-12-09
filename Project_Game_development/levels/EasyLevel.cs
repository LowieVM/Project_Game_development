using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Game_development
{
    internal class EasyLevel : Level
    {
        public EasyLevel(GraphicsDevice graphicsDevice) : base(new Environment(graphicsDevice))
        {
            //CurrentEnvironment
            Player player = cManager.CreateAndAddPlayer(new Vector2(50, 50));
            player.Health = 999;
            for (int i = 0; i < 2; i++)
            {
                cManager.CreateAndAddOfficer(new Rectangle(500, 100, 500, 500), cManager.EnemyTeam);
            }
            Officer friendly = cManager.CreateAndAddOfficer(new Vector2(50, 500), cManager.PlayerTeam);
            friendly.Health = 999;
            friendly.MoveBehavior = new MoveBehaviorFollow(cManager.PlayerTeam[0]);
        }
    }
}
