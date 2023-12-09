using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Game_development
{
    enum GameState{ Playing, GameOver, MainMenu, Won}
    enum Dificulty { Easy, Normal, Hard }
    internal class GameManager
    {
        public Level CurrentLevel { get; set; }
        private Button start;
        private Button gameOver;
        private Button mainMenu;
        private Button easy;
        private Button normal;
        private Button hard;
        private Button currentDificulty;
        private Button youWon;
        private string difficultyText = "difficulty: ";
        public GameState gameState { get; set; }
        public GameManager()
        {
            CurrentLevel = new EasyLevel();
            gameState = GameState.MainMenu;
            start = new Button("Start game", new Vector2(GameSettings.ScreenWidth, 200));
            gameOver = new Button("Game over", new Vector2(GameSettings.ScreenWidth, 200));
            youWon = new Button("You won!", new Vector2(GameSettings.ScreenWidth, 200));
            mainMenu = new Button("Main menu", new Vector2(GameSettings.ScreenWidth, 500));
            easy = new Button("Easy", new Vector2(GameSettings.ScreenWidth, 650));
            normal = new Button("Normal", new Vector2(GameSettings.ScreenWidth, 800));
            hard = new Button("Hard", new Vector2(GameSettings.ScreenWidth, 950));
            currentDificulty = new Button(difficultyText + "Easy", new Vector2(GameSettings.ScreenWidth, 350));
        }
        public void Update(GameTime gameTime)
        {
            if (gameState == GameState.MainMenu)
            {
                if (easy.IsButtonClicked())
                {
                    currentDificulty.Text = difficultyText + easy.Text;
                    CurrentLevel = new EasyLevel();
                }
                else if (normal.IsButtonClicked())
                {
                    currentDificulty.Text = difficultyText + normal.Text;
                    CurrentLevel = new NormalLevel();
                }
                else if (hard.IsButtonClicked())
                {
                    currentDificulty.Text = difficultyText + hard.Text;
                    CurrentLevel = new HardLevel();
                }
            }
            if (start.IsButtonClicked() && gameState == GameState.MainMenu)
            {
                gameState = GameState.Playing;
            }
            if (mainMenu.IsButtonClicked() && (gameState == GameState.GameOver || gameState == GameState.Won))
            {
                gameState = GameState.MainMenu;
            }
            if (gameState == GameState.Playing)
            {
                CurrentLevel.Update(gameTime);
                if (!CurrentLevel.cManager.PlayerTeam[0].isAlive)
                {
                    gameState = GameState.GameOver;
                }
                else if (CurrentLevel.cManager.EnemyTeam.Find(enemy => enemy.isAlive) == null)
                {
                    gameState = GameState.Won;
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (gameState == GameState.Playing)
            {
                CurrentLevel.Draw(spriteBatch);
            }
            else if (gameState == GameState.MainMenu)
            {
                start.Draw(spriteBatch);
                easy.Draw(spriteBatch);
                normal.Draw(spriteBatch);
                hard.Draw(spriteBatch);
                currentDificulty.Draw(spriteBatch);
            }
            else if (gameState == GameState.GameOver)
            {
                gameOver.Draw(spriteBatch);
                mainMenu.Draw(spriteBatch);
                currentDificulty.Text = difficultyText + easy.Text;
                CurrentLevel = new EasyLevel();
            }
            else if (gameState == GameState.Won)
            {
                youWon.Draw(spriteBatch);
                mainMenu.Draw(spriteBatch);
                currentDificulty.Text = difficultyText + easy.Text;
                CurrentLevel = new EasyLevel();
            }
        }
    }
}
