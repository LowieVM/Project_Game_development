using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Game_development
{
    internal class Button
    {
        private SpriteFont font;
        private Vector2 startButtonPosition;
        private Rectangle startButtonRectangle;
        public string Text { get; set; }
        private MouseState previousMouseState;

        public Button(string text, Vector2 position)
        {
            this.Text = text;
            previousMouseState = Mouse.GetState();
            font = GameTextures.ArialFont;

            int width = (int)font.MeasureString(text).X;
            int height = (int)font.MeasureString(text).Y;
            startButtonPosition = new Vector2((position.X/2) - (width/2), (position.Y / 2) - (height / 2));
            startButtonRectangle = new Rectangle(
                (int)startButtonPosition.X,
                (int)startButtonPosition.Y,
                width,
                height
            );
        }

        public bool IsButtonClicked()
        {
            bool toReturn;
            MouseState currentMouseState = Mouse.GetState();
            toReturn = startButtonRectangle.Contains(currentMouseState.Position) && currentMouseState.LeftButton == ButtonState.Pressed && previousMouseState.LeftButton == ButtonState.Released;
            previousMouseState = currentMouseState;
            return toReturn;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(font, Text, startButtonPosition, Color.White, 0f, Vector2.Zero, 1, SpriteEffects.None, 0);
        }
    }
}
