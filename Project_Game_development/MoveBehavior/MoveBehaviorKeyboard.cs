using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Project_Game_development
{
    internal class MoveBehaviorKeyboard : MoveBehavior
    {
        public override Vector2 MoveDirection { get; set; }

        public override void UpdateMoveDirection(IMovable movable)
        {
            Vector2 direction = Vector2.Zero;
            KeyboardState state = Keyboard.GetState();

            if (state.IsKeyDown(Keys.Left) || state.IsKeyDown(Keys.A))
            {
                direction.X -= 1;
            }
            if (state.IsKeyDown(Keys.Right) || state.IsKeyDown(Keys.D))
            {
                direction.X += 1;
            }
            if (state.IsKeyDown(Keys.Up) || state.IsKeyDown(Keys.W))
            {
                direction.Y -= 1;
            }
            if (state.IsKeyDown(Keys.Down) || state.IsKeyDown(Keys.S))
            {
                direction.Y += 1;
            }

            this.MoveDirection = direction;
        }
    }
}
