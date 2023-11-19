using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Project_Game_development
{
    internal class MouseReader : IPositional
    {
        public Vector2 Position { get; set; }
        public void Update()
        {
            MouseState state = Mouse.GetState();
            Position = new Vector2(state.X, state.Y);
        }
    }
}
