﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Project_Game_development
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        private Texture2D playerWalkTexture;
        private Texture2D playerRunTexture;
        private Texture2D playerPistolTexture;
        private Texture2D playerShotgunTexture;
        private Texture2D playerShotgunReloadTexture;
        private Texture2D playerMinigunTexture;
        private Texture2D playerMinigunShootTexture;
        private Texture2D playerFlamethrowerTexture;

        private Texture2D officerWalkTexture;
        private Texture2D officerPistolWalkTexture;
        private Texture2D officerPistolTexture;
        private Texture2D offcerDieTexture;

        private Texture2D bulletTexture;

        private Player player;


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            graphics.PreferredBackBufferWidth = GameSettings.ScreenWidth;
            graphics.PreferredBackBufferHeight = GameSettings.ScreenHeight;
            graphics.IsFullScreen = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            base.Initialize();
            player = new Player(playerWalkTexture, playerRunTexture, playerPistolTexture, playerShotgunTexture, playerShotgunReloadTexture, playerMinigunTexture, playerMinigunShootTexture, playerFlamethrowerTexture, bulletTexture);
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            playerWalkTexture = Content.Load<Texture2D>("player_walk_strip6");
            playerRunTexture = Content.Load<Texture2D>("player_run_strip6");
            playerPistolTexture = Content.Load<Texture2D>("player_9mmhandgun");
            playerShotgunTexture = Content.Load<Texture2D>("player_pumpgun_stand");
            playerShotgunReloadTexture = Content.Load<Texture2D>("player_pumgun_reload_strip5");
            playerMinigunTexture = Content.Load<Texture2D>("player_chaingun");
            playerMinigunShootTexture = Content.Load<Texture2D>("player_chaingun_shoot_strip2");
            playerFlamethrowerTexture = Content.Load<Texture2D>("player_flamethrower");

            bulletTexture = Content.Load<Texture2D>("bullet");

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            player.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            player.Draw(spriteBatch);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}