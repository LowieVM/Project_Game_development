using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Reflection.Metadata;

namespace Project_Game_development
{
    internal static class GameTextures
    {
        public static void LoadContent(ContentManager content)
        {
            PlayerWalkTexture = content.Load<Texture2D>("player_walk_strip6");
            PlayerRunTexture = content.Load<Texture2D>("player_run_strip6");
            PlayerPistolTexture = content.Load<Texture2D>("player_9mmhandgun");
            PlayerShotgunTexture = content.Load<Texture2D>("player_pumpgun_stand");
            PlayerShotgunReloadTexture = content.Load<Texture2D>("player_pumgun_reload_strip5");
            PlayerMinigunTexture = content.Load<Texture2D>("player_chaingun");
            PlayerMinigunShootTexture = content.Load<Texture2D>("player_chaingun_shoot_strip2");
            PlayerFlamethrowerTexture = content.Load<Texture2D>("player_flamethrower");

            OfficerWalkTexture = content.Load<Texture2D>("officer_walk_strip");
            OfficerPistolWalkTexture = content.Load<Texture2D>("officer_shoot_strip");
            OfficerPistolTexture = content.Load<Texture2D>("officer_pistol");
            OfficerDieTexture = content.Load<Texture2D>("officer_die_strip");

            BulletTexture = content.Load<Texture2D>("bullet");

            ArialFont = content.Load<SpriteFont>("ArialFont");
        }


        public static SpriteProperties GetProperties<TState>(TState state) where TState : Enum
        {
            return state switch
            {
                PlayerState playerState => GetPlayerProperties(playerState),
                OfficerState officerState => GetOfficerProperties(officerState),
                _ => throw new TypeAccessException($"{typeof(TState)} is not a valid type"),
            };
        }

        public static SpriteProperties GetPlayerProperties(PlayerState state)
        {
            switch (state)
            {
                case PlayerState.Walking:
                    return new SpriteProperties(PlayerWalkTexture, 12, 6, 1, PlayerWalkRotationPoint);
                case PlayerState.Running:
                    return new SpriteProperties(PlayerRunTexture, 12, 6, 1, PlayerRunRotationPoint);
                case PlayerState.Pistol:
                    return new SpriteProperties(PlayerPistolTexture, PlayerPistolRotationPoint);
                case PlayerState.Shotgun:
                    return new SpriteProperties(PlayerShotgunTexture, PlayerShotgunRotationPoint);
                case PlayerState.ShotgunReloading:
                    return new SpriteProperties(PlayerShotgunReloadTexture, 12, 5, 1, PlayerShotgunReloadRotationPoint);
                case PlayerState.MiniGun:
                    return new SpriteProperties(PlayerMinigunTexture, PlayerMinigunRotationPoint);
                case PlayerState.MiniGunShoot:
                    return new SpriteProperties(PlayerMinigunShootTexture, 12, 2, 1, PlayerMinigunShootRotationPoint);
                case PlayerState.Flamethrower:
                    return new SpriteProperties(PlayerFlamethrowerTexture, PlayerFlamethrowerRotationPoint);
                default:
                    throw new ArgumentOutOfRangeException($"{state}: no Sprite(Properties) for this PlayerState");
            }
        }

        public static SpriteProperties GetOfficerProperties(OfficerState state)
        {
            switch (state)
            {
                case OfficerState.Walking:
                    return new SpriteProperties(OfficerWalkTexture, 12, 8, 1, OfficerWalkRotationPoint);
                case OfficerState.WalkingPistol:
                    return new SpriteProperties(OfficerPistolWalkTexture, 10, 6, 1, OfficerPistolWalkRotationPoint);
                case OfficerState.Pistol:
                    return new SpriteProperties(OfficerPistolTexture, OfficerPistolRotationPoint);
                case OfficerState.Dying:
                    return new SpriteProperties(OfficerDieTexture, 4, 4, 1, OfficerDieRotationPoint);
                default:
                    throw new ArgumentOutOfRangeException($"{state}: no Sprite(Properties) for this OfficerState");
            }
        }


        public static Texture2D PlayerWalkTexture { get; set; }
        public static Texture2D PlayerRunTexture { get; set; }
        public static Texture2D PlayerPistolTexture { get; set; }
        public static Texture2D PlayerShotgunTexture { get; set; }
        public static Texture2D PlayerShotgunReloadTexture { get; set; }
        public static Texture2D PlayerMinigunTexture { get; set; }
        public static Texture2D PlayerMinigunShootTexture { get; set; }
        public static Texture2D PlayerFlamethrowerTexture { get; set; }

        public static Texture2D OfficerWalkTexture { get; set; }
        public static Texture2D OfficerPistolWalkTexture { get; set; }
        public static Texture2D OfficerPistolTexture { get; set; }
        public static Texture2D OfficerDieTexture { get; set; }

        public static Texture2D BulletTexture { get; set; }

        public static SpriteFont ArialFont { get; set; }


        public static Vector2 PlayerWalkRotationPoint { get; set; } = new Vector2(17, 31);
        public static Vector2 PlayerRunRotationPoint { get; set; } = new Vector2(45, 45);
        public static Vector2 PlayerPistolRotationPoint { get; set; } = new Vector2(26, 31);
        public static Vector2 PlayerShotgunRotationPoint { get; set; } = new Vector2(34, 26);
        public static Vector2 PlayerShotgunReloadRotationPoint { get; set; } = new Vector2(34, 26);
        public static Vector2 PlayerMinigunRotationPoint { get; set; } = new Vector2(13, 15);
        public static Vector2 PlayerMinigunShootRotationPoint { get; set; } = new Vector2(13, 15);
        public static Vector2 PlayerFlamethrowerRotationPoint { get; set; } = new Vector2(34, 26);

        public static Vector2 OfficerWalkRotationPoint { get; set; } = new Vector2(18, 22);
        public static Vector2 OfficerPistolWalkRotationPoint { get; set; } = new Vector2(17, 23);
        public static Vector2 OfficerPistolRotationPoint { get; set; } = new Vector2(13, 23);
        public static Vector2 OfficerDieRotationPoint { get; set; } = new Vector2(31, 27);

        public static Vector2 BulletRotationPoint { get; set; } = new Vector2(20, 13);
    }
}
