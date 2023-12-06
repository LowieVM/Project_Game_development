using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Game_development
{
    enum GameState{ Playing, GameOver, MainMenu}
    internal class GameManager
    {
        TestLevel currentLevel;
        Button start;
        Button gameOver;
        public GameState gameState { get; set; }
        public GameManager()
        {
            gameState = GameState.MainMenu;
            start = new Button("Start game", new Vector2(GameSettings.ScreenWidth, 200));
            gameOver = new Button("Game over\n\nMain menu", new Vector2(GameSettings.ScreenWidth, GameSettings.ScreenHeight));
        }
        public void Update(GameTime gameTime)
        {
            if (start.IsButtonClicked() && gameState == GameState.MainMenu)
            {
                currentLevel = new TestLevel();
                gameState = GameState.Playing;
            }
            if (gameOver.IsButtonClicked() && gameState == GameState.GameOver)
            {
                gameState = GameState.MainMenu;
            }
            if (gameState == GameState.Playing)
            {
                currentLevel.Update(gameTime);
                if (!currentLevel.cManager.playerTeam[0].isAlive)
                {
                    gameState = GameState.GameOver;
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (gameState == GameState.Playing)
            {
                currentLevel.Draw(spriteBatch);
            }
            if (gameState == GameState.MainMenu)
            {
                start.Draw(spriteBatch);
            }
            if (gameState == GameState.GameOver)
            {
                gameOver.Draw(spriteBatch);
            }
        }
    }
}
