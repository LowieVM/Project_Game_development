using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Game_development
{
    internal class KeyboardReader
    {
        public void UpdateDirection(Player movable)
        {
            KeyboardState state = Keyboard.GetState();

            if (state.IsKeyDown(Keys.D1) || state.IsKeyDown(Keys.NumPad1))
            {
                movable.State = PlayerState.Walking;
            }
            if (state.IsKeyDown(Keys.D2) || state.IsKeyDown(Keys.NumPad2))
            {
                movable.State = PlayerState.Running;
            }
            if (state.IsKeyDown(Keys.D3) || state.IsKeyDown(Keys.NumPad3))
            {
                movable.State = PlayerState.Pistol;
            }
            if (state.IsKeyDown(Keys.D4) || state.IsKeyDown(Keys.NumPad4))
            {
                movable.State = PlayerState.Shotgun;
            }
            if (state.IsKeyDown(Keys.D5) || state.IsKeyDown(Keys.NumPad5))
            {
                movable.State = PlayerState.ShotgunReloading;
            }
            if (state.IsKeyDown(Keys.D6) || state.IsKeyDown(Keys.NumPad6))
            {
                movable.State = PlayerState.MiniGun;
            }
            if (state.IsKeyDown(Keys.D7) || state.IsKeyDown(Keys.NumPad7))
            {
                movable.State = PlayerState.MiniGunShoot;
            }
            if (state.IsKeyDown(Keys.D8) || state.IsKeyDown(Keys.NumPad8))
            {
                movable.State = PlayerState.Flamethrower;
            }
        }
    }
}
