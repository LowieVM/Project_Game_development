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
            Vector2 MoveDirection = Vector2.Zero;
            KeyboardState state = Keyboard.GetState();

            if (state.IsKeyDown(Keys.Left) || state.IsKeyDown(Keys.A))
            {
                MoveDirection.X -= 1;
            }
            if (state.IsKeyDown(Keys.Right) || state.IsKeyDown(Keys.D))
            {
                MoveDirection.X += 1;
            }
            if (state.IsKeyDown(Keys.Up) || state.IsKeyDown(Keys.W))
            {
                MoveDirection.Y -= 1;
            }
            if (state.IsKeyDown(Keys.Down) || state.IsKeyDown(Keys.S))
            {
                MoveDirection.Y += 1;
            }
            if (state.IsKeyDown(Keys.D1) || state.IsKeyDown(Keys.NumPad1))
            {
                movable.PlayerState = PlayerState.Walking;
            }
            if (state.IsKeyDown(Keys.D2) || state.IsKeyDown(Keys.NumPad2))
            {
                movable.PlayerState = PlayerState.Running;
            }
            if (state.IsKeyDown(Keys.D3) || state.IsKeyDown(Keys.NumPad3))
            {
                movable.PlayerState = PlayerState.Pistol;
            }
            if (state.IsKeyDown(Keys.D4) || state.IsKeyDown(Keys.NumPad4))
            {
                movable.PlayerState = PlayerState.Shotgun;
            }
            if (state.IsKeyDown(Keys.D5) || state.IsKeyDown(Keys.NumPad5))
            {
                movable.PlayerState = PlayerState.ShotgunReloading;
            }
            if (state.IsKeyDown(Keys.D6) || state.IsKeyDown(Keys.NumPad6))
            {
                movable.PlayerState = PlayerState.MiniGun;
            }
            if (state.IsKeyDown(Keys.D7) || state.IsKeyDown(Keys.NumPad7))
            {
                movable.PlayerState = PlayerState.MiniGunShoot;
            }
            if (state.IsKeyDown(Keys.D8) || state.IsKeyDown(Keys.NumPad8))
            {
                movable.PlayerState = PlayerState.Flamethrower;
            }
            movable.MoveDirection = MoveDirection;
        }
    }
}
