using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
