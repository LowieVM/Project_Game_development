using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Game_development
{
    internal static class GameTextures
    {
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
