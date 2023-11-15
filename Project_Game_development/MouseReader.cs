using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Game_development
{
    internal class MouseReader
    {
        public Vector2 GetMouseVector()
        {
            MouseState state = Mouse.GetState();
            return new Vector2(state.X, state.Y);
        }
    }
}
