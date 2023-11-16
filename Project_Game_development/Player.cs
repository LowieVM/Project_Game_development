using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Game_development
{
    enum PlayerState { Walking, Running, Pistol, Shotgun, ShotgunReloading, MiniGun, MiniGunShoot, Flamethrower }
    internal class Player : IRotatable
    {
        private Texture2D currentTexture;
        private Animation currentAnimation;

        private SpriteEffects effect = SpriteEffects.None;
        public Vector2 Position { get; set; } = new Vector2(50, 50);
        public PlayerState PlayerState { get; set; }
        public float Rotation { get; set; } = 0;
        public Vector2 RotationPoint { get; set; }
        private RotationManager rotationManager;
        private MouseReader mouseReader;
        private Dictionary<PlayerState, SpriteProperties> playerStateMappings;

        public Player(Texture2D walkTexture, Texture2D runTexture, Texture2D pistolTexture, Texture2D shotgunTexture, Texture2D shotgunReloadTexture, Texture2D minigunTexture, Texture2D minigunShootTexture, Texture2D flamethrowerTexture)
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
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(currentTexture, Position, currentAnimation.CurrentFrame.SourceRectangle, Color.White, Rotation, RotationPoint, 1f, effect, 0f);
        }

        public void Update(GameTime gameTime)
        {
            currentTexture = playerStateMappings[PlayerState].Texture;
            currentAnimation = playerStateMappings[PlayerState].Animation;
            RotationPoint = playerStateMappings[PlayerState].RotationPoint;

            rotationManager.Update();
            currentAnimation.Update(gameTime);
        }
    }
}
