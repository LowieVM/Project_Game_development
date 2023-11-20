using Microsoft.Xna.Framework.Input;

namespace Project_Game_development
{
    internal class KeyboardReader
    {
        public void UpdateState(Player movable)
        {
            KeyboardState state = Keyboard.GetState();

            if (state.IsKeyDown(Keys.D1) || state.IsKeyDown(Keys.NumPad1))
            {
                movable.CurrentState = PlayerState.Walking;
            }
            if (state.IsKeyDown(Keys.D2) || state.IsKeyDown(Keys.NumPad2))
            {
                movable.CurrentState = PlayerState.Running;
            }
            if (state.IsKeyDown(Keys.D3) || state.IsKeyDown(Keys.NumPad3))
            {
                movable.CurrentState = PlayerState.Pistol;
            }
            if (state.IsKeyDown(Keys.D4) || state.IsKeyDown(Keys.NumPad4))
            {
                movable.CurrentState = PlayerState.Shotgun;
            }
            if (state.IsKeyDown(Keys.D5) || state.IsKeyDown(Keys.NumPad5))
            {
                movable.CurrentState = PlayerState.ShotgunReloading;
            }
            if (state.IsKeyDown(Keys.D6) || state.IsKeyDown(Keys.NumPad6))
            {
                movable.CurrentState = PlayerState.MiniGun;
            }
            if (state.IsKeyDown(Keys.D7) || state.IsKeyDown(Keys.NumPad7))
            {
                movable.CurrentState = PlayerState.MiniGunShoot;
            }
            if (state.IsKeyDown(Keys.D8) || state.IsKeyDown(Keys.NumPad8))
            {
                movable.CurrentState = PlayerState.Flamethrower;
            }
        }
    }
}
