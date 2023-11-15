using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Game_development
{
    enum PlayerState { Walking, Running, Pistol, Shotgun, ShotgunReloading, MiniGun, MiniGunShoot, Flamethrower }
    internal class Player
    {
        private Texture2D walkTexture;
        private Texture2D runTexture;
        private Texture2D pistolTexture;
        private Texture2D shotgunTexture;
        private Texture2D shotgunReloadTexture;
        private Texture2D minigunTexture;
        private Texture2D minigunShootTexture;
        private Texture2D flamethrowerTexture;
        private Texture2D currentTexture;

        private Animation walkAnimation;
        private Animation runAnimation;
        private Animation pistolAnimation;
        private Animation shotgunAnimation;
        private Animation shotgunReloadAnimation;
        private Animation minigunAnimation;
        private Animation minigunShootAnimation;
        private Animation flamethrowerAnimation;
        private Animation currentAnimation;
        private SpriteEffects effect = SpriteEffects.None;
        public Vector2 Position { get; set; }
        public PlayerState PlayerState { get; set; }

        public Player(Texture2D walkTexture, Texture2D runTexture, Texture2D pistolTexture, Texture2D shotgunTexture, Texture2D shotgunReloadTexture, Texture2D minigunTexture, Texture2D minigunShootTexture, Texture2D flamethrowerTexture)
        {
            this.walkTexture = walkTexture;
            this.runTexture = runTexture;
            this.pistolTexture = pistolTexture;
            this.shotgunTexture = shotgunTexture;
            this.shotgunReloadTexture = shotgunReloadTexture;
            this.minigunTexture = minigunTexture;
            this.minigunShootTexture = minigunShootTexture;
            this.flamethrowerTexture = flamethrowerTexture;

            walkAnimation = new Animation(12);
            runAnimation = new Animation(12);
            pistolAnimation = new Animation(1);
            shotgunAnimation = new Animation(1);
            shotgunReloadAnimation = new Animation(12);
            minigunAnimation = new Animation(1);
            minigunShootAnimation = new Animation(12);
            flamethrowerAnimation = new Animation(1);

            walkAnimation.GetFramesFromTextureProps(walkTexture.Width, walkTexture.Height, 6, 1);
            runAnimation.GetFramesFromTextureProps(runTexture.Width, runTexture.Height, 6, 1);
            pistolAnimation.GetFramesFromTextureProps(pistolTexture.Width, pistolTexture.Height, 1, 1);
            shotgunAnimation.GetFramesFromTextureProps(shotgunTexture.Width, shotgunTexture.Height, 1, 1);
            shotgunReloadAnimation.GetFramesFromTextureProps(shotgunReloadTexture.Width, shotgunReloadTexture.Height, 5, 1);
            minigunAnimation.GetFramesFromTextureProps(minigunTexture.Width, minigunTexture.Height, 1, 1);
            minigunShootAnimation.GetFramesFromTextureProps(minigunShootTexture.Width, minigunShootTexture.Height, 2, 1);
            flamethrowerAnimation.GetFramesFromTextureProps(flamethrowerTexture.Width, flamethrowerTexture.Height, 1, 1);

            PlayerState = PlayerState.Pistol;
            currentTexture = this.pistolTexture;
            currentAnimation = pistolAnimation;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(currentTexture, Position, currentAnimation.CurrentFrame.SourceRectangle, Color.White, 0f, Vector2.Zero, 1f, effect, 0f);
        }

        public void Update(GameTime gameTime)
        {
            switch (PlayerState)
            {
                case PlayerState.Walking:
                    currentTexture = walkTexture;
                    currentAnimation = walkAnimation;
                    break;
                case PlayerState.Running:
                    currentTexture = runTexture;
                    currentAnimation = runAnimation;
                    break;
                case PlayerState.Pistol:
                    currentTexture = pistolTexture;
                    currentAnimation = pistolAnimation;
                    break;
                case PlayerState.Shotgun:
                    currentTexture = shotgunTexture;
                    currentAnimation = shotgunAnimation;
                    break;
                case PlayerState.ShotgunReloading:
                    currentTexture = shotgunReloadTexture;
                    currentAnimation = shotgunReloadAnimation;
                    break;
                case PlayerState.MiniGun:
                    currentTexture = minigunTexture;
                    currentAnimation = minigunAnimation;
                    break;
                case PlayerState.MiniGunShoot:
                    currentTexture = minigunShootTexture;
                    currentAnimation = minigunShootAnimation;
                    break;
                case PlayerState.Flamethrower:
                    currentTexture = flamethrowerTexture;
                    currentAnimation = flamethrowerAnimation;
                    break;
                default:
                    break;
            }


            currentAnimation.Update(gameTime);
        }

    }
}
