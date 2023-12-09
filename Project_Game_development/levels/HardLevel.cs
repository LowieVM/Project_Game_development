using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Game_development
{
    internal class HardLevel : Level
    {
        public HardLevel()
        {
            cManager.CreateAndAddPlayer(new Vector2(50, 50));
            for (int i = 0; i < 20; i++)
            {
                cManager.CreateAndAddOfficer(new Rectangle(500, 100, 500, 500), cManager.enemyTeam);
            }
        }
    }
}
