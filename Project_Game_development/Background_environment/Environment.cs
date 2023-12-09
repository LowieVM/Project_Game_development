using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Game_development
{
    internal class Environment
    {
        private GraphicsDevice graphics;
        public int[,] gameboard { get; set; } = new int[,]
        {
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 1, 2, 0, 0, 2, 1, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 1, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 1, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 1, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0 },
        };
        public List<Block> blocks = new List<Block>();


        public Environment(GraphicsDevice graphics)
        {
            this.graphics = graphics;
            CreateBlocks();
        }


        private void CreateBlocks()
        {
            int xRatio = gameboard.GetLength(1);
            int yRatio = gameboard.GetLength(0);
            for (int l = 0; l < gameboard.GetLength(0); l++)
            {
                for (int k = 0; k < gameboard.GetLength(1); k++)
                {
                    int xPos = (GameSettings.ScreenWidth / xRatio) * k;
                    int yPos = (GameSettings.ScreenHeight / yRatio) * l;
                    int width = GameSettings.ScreenWidth / xRatio;
                    int height = GameSettings.ScreenHeight / yRatio;
                    blocks.Add(BlockFactory.CreateBlock(gameboard[l, k], xPos, yPos, graphics, width, height));
                }
            }
        }
    }
}
