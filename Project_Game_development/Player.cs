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
        public PlayerState PlayerState { get; set; }
        public float Rotation { get; set; } = 0;
        public Vector2 RotationPoint { get; set; }
        public KeyboardReader Keyboard { get; set; }
        public Vector2 InitialSpeed { get; set; } = new Vector2(1, 1);
        public float MaxSpeed { get; set; } = 5;
        public Vector2 MoveDirection { get; set; } = new Vector2(10, 10);
        public Vector2 Acceleration { get; set; } = new Vector2(0.1f, 0.1f);




        public Player(Texture2D walkTexture, Texture2D runTexture, Texture2D pistolTexture, Texture2D shotgunTexture, Texture2D shotgunReloadTexture, Texture2D minigunTexture, Texture2D minigunShootTexture, Texture2D flamethrowerTexture, Texture2D bulletTexture)
        {
            playerStateMappings = new Dictionary<PlayerState, SpriteProperties>
            {
                { PlayerState.Walking, new SpriteProperties(walkTexture, 12, 6, 1, new Vector2(17, 31)) },
                { PlayerState.Running, new SpriteProperties(runTexture, 12, 6, 1, new Vector2(45, 45)) },
                { PlayerState.Pistol, new SpriteProperties(pistolTexture, new Vector2(26, 31)) },
                { PlayerState.Shotgun, new SpriteProperties(shotgunTexture, new Vector2(34, 26)) },
                { PlayerState.ShotgunReloading, new SpriteProperties(shotgunReloadTexture, 12, 5, 1, new Vector2(34, 26)) },
                { PlayerState.MiniGun, new SpriteProperties(minigunTexture, new Vector2(13, 15)) },
                { PlayerState.MiniGunShoot, new SpriteProperties(minigunShootTexture, 12, 2, 1, new Vector2(13, 15)) },
                { PlayerState.Flamethrower, new SpriteProperties(flamethrowerTexture, new Vector2(34, 26)) }
            };

            PlayerState = PlayerState.Pistol;

            mouseReader = new MouseReader();
            rotationManager = new RotationManager(this, mouseReader);
            Keyboard = new KeyboardReader();
            mover = new MoveManager();
            playerShootManager = new PlayerShootManager(this, bulletTexture);
        }


        public void Draw(SpriteBatch spriteBatch)
        {
            playerShootManager.Draw(spriteBatch);
            spriteBatch.Draw(currentTexture, Position, currentAnimation.CurrentFrame.SourceRectangle, Color.White, Rotation, RotationPoint, 1f, effect, 0f);
        }

        public void Update(GameTime gameTime)
        {
            currentTexture = playerStateMappings[PlayerState].Texture;
            currentAnimation = playerStateMappings[PlayerState].Animation;
            RotationPoint = playerStateMappings[PlayerState].RotationPoint;

            playerShootManager.Update(gameTime);
            mouseReader.Update();
            rotationManager.Update();
            currentAnimation.Update(gameTime);
            Keyboard.UpdateDirection(this);
            mover.Move(this);
        }
    }
}
