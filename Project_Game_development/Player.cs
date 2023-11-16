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
        private MouseReader mouseReader = new MouseReader();
        private Dictionary<PlayerState, PlayerStateData> playerStateMappings;

        public Player(Texture2D walkTexture, Texture2D runTexture, Texture2D pistolTexture, Texture2D shotgunTexture, Texture2D shotgunReloadTexture, Texture2D minigunTexture, Texture2D minigunShootTexture, Texture2D flamethrowerTexture)
        {
            playerStateMappings = new Dictionary<PlayerState, PlayerStateData>
            {
                { PlayerState.Walking, new PlayerStateData(walkTexture, new Animation(12, walkTexture, 6, 1), new Vector2(17, 31)) },
                { PlayerState.Running, new PlayerStateData(runTexture, new Animation(12, runTexture, 6, 1), new Vector2(45, 45)) },
                { PlayerState.Pistol, new PlayerStateData(pistolTexture, new Animation(1, pistolTexture, 1, 1), new Vector2(26, 31)) },
                { PlayerState.Shotgun, new PlayerStateData(shotgunTexture, new Animation(1, shotgunTexture, 1, 1), new Vector2(34, 26)) },
                { PlayerState.ShotgunReloading, new PlayerStateData(shotgunReloadTexture, new Animation(12, shotgunReloadTexture, 5, 1), new Vector2(34, 26)) },
                { PlayerState.MiniGun, new PlayerStateData(minigunTexture, new Animation(1, minigunTexture, 1, 1), new Vector2(13, 15)) },
                { PlayerState.MiniGunShoot, new PlayerStateData(minigunShootTexture, new Animation(12, minigunShootTexture, 2, 1), new Vector2(13, 15)) },
                { PlayerState.Flamethrower, new PlayerStateData(flamethrowerTexture, new Animation(1, flamethrowerTexture, 1, 1), new Vector2(34, 26)) }
            };

            PlayerState = PlayerState.Pistol;
            currentTexture = playerStateMappings[PlayerState].Texture;
            currentAnimation = playerStateMappings[PlayerState].Animation;
            RotationPoint = playerStateMappings[PlayerState].RotationPoint;


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
