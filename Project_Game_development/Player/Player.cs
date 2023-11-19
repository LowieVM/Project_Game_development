using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Project_Game_development
{
    enum PlayerState { Walking, Running, Pistol, Shotgun, ShotgunReloading, MiniGun, MiniGunShoot, Flamethrower }
    internal class Player : IRotatable, IMovable
    {
        public PlayerState CurrentState { get; set; }
        public Vector2 Position { get; set; } = new Vector2(50, 50);
        public float Rotation { get; set; }
        public Vector2 RotationPoint { get; set; }
        public Vector2 InitialSpeed { get; set; } = new Vector2(1, 1);
        public float MaxSpeed { get; set; } = 5;
        public Vector2 Acceleration { get; set; } = new Vector2(0.1f, 0.1f);
        public MoveBehavior MoveBehavior { get; set; }
        public KeyboardReader Keyboard { get; set; }

        private Dictionary<PlayerState, SpriteProperties> playerStateMappings;
        private Texture2D currentTexture;
        private Animation currentAnimation;
        private RotationManager rotationManager;
        private MoveManager mover;
        private PlayerShootManager playerShootManager;
        private MouseReader mouseReader;

        public Player(Vector2 position)
        {
            playerStateMappings = ((PlayerState[])Enum.GetValues(typeof(PlayerState))).ToDictionary(state => state, state => GameTextures.GetPlayerProperties(state));
            CurrentState = PlayerState.Pistol;
            Position = position;

            mouseReader = new MouseReader();
            rotationManager = new RotationManager(this, mouseReader);
            mover = new MoveManager();
            MoveBehavior = new MoveBehaviorKeyboard();
            playerShootManager = new PlayerShootManager(this);
            Keyboard = new KeyboardReader();
        }


        public void Update(GameTime gameTime)
        {
            currentTexture = playerStateMappings[CurrentState].Texture;
            currentAnimation = playerStateMappings[CurrentState].Animation;
            RotationPoint = playerStateMappings[CurrentState].RotationPoint;

            Keyboard.UpdateDirection(this);
            mover.Move(this, MoveBehavior);
            mouseReader.Update();
            rotationManager.Update();
            playerShootManager.Update(gameTime);
            currentAnimation.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            playerShootManager.Draw(spriteBatch);
            spriteBatch.Draw(currentTexture, Position, currentAnimation.CurrentFrame.SourceRectangle, Color.White, Rotation, RotationPoint, 1f, SpriteEffects.None, 0f);
        }
    }
}
