using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Game_development
{
    enum PlayerState { Walking, Running, Pistol, Shotgun, ShotgunReloading, MiniGun, MiniGunShoot, Flamethrower }
    internal class Player : IRotatable, IMovable
    {
        private Texture2D currentTexture;
        private Animation currentAnimation;
        private SpriteEffects effect = SpriteEffects.None;
        private RotationManager rotationManager;
        private MouseReader mouseReader;
        private Dictionary<PlayerState, SpriteProperties> playerStateMappings;
        private MoveManager mover;

        private PlayerShootManager playerShootManager;
        public Vector2 Position { get; set; } = new Vector2(50, 50);
        public PlayerState State { get; set; }
        public float Rotation { get; set; } = 0;
        public Vector2 RotationPoint { get; set; }
        public KeyboardReader Keyboard { get; set; }
        public Vector2 InitialSpeed { get; set; } = new Vector2(1, 1);
        public float MaxSpeed { get; set; } = 5;
        public Vector2 Acceleration { get; set; } = new Vector2(0.1f, 0.1f);
        public MoveBehavior MoveBehavior { get; set; }

        public Player(Vector2 position)
        {
            playerStateMappings = ((PlayerState[])Enum.GetValues(typeof(PlayerState))).ToDictionary(state => state, state => GameTextures.GetPlayerProperties(state));

            State = PlayerState.Pistol;

            Position = position;

            mouseReader = new MouseReader();
            rotationManager = new RotationManager(this, mouseReader);
            Keyboard = new KeyboardReader();
            mover = new MoveManager();
            playerShootManager = new PlayerShootManager(this);

            MoveBehavior = new MoveBehaviorKeyboard();
        }


        public void Update(GameTime gameTime)
        {
            currentTexture = playerStateMappings[State].Texture;
            currentAnimation = playerStateMappings[State].Animation;
            RotationPoint = playerStateMappings[State].RotationPoint;

            playerShootManager.Update(gameTime);
            mouseReader.Update();
            rotationManager.Update();
            currentAnimation.Update(gameTime);
            Keyboard.UpdateDirection(this);
            mover.Move(this, MoveBehavior);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            playerShootManager.Draw(spriteBatch);
            spriteBatch.Draw(currentTexture, Position, currentAnimation.CurrentFrame.SourceRectangle, Color.White, Rotation, RotationPoint, 1f, effect, 0f);
        }
    }
}
