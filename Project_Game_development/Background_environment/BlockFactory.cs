using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SharpDX.Direct3D9;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Game_development
{
    internal class BlockFactory
    {
        public static Block CreateBlock(int type, int x, int y, GraphicsDevice graphics, int width, int height)
        {
            Block newBlock = null;
            if (type == 0)
            {
                newBlock = new Block(x, y, Color.Red, graphics, width, height);
            }
            if (type == 1)
            {
                newBlock = new Block(x, y, Color.Green, graphics, width, height);
            }
            if (type == 2)
            {
                newBlock = new Block(x, y, Color.Orange, graphics, width, height);
            }
            return newBlock;
        }

    }
}
