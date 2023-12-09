using Microsoft.Xna.Framework;

namespace Project_Game_development
{
    internal interface IMovable : IPositional
    {
        Vector2 InitialSpeed { get; set; }
        float MaxSpeed { get; set; }
        MoveBehavior MoveBehavior { get; set; }
        Vector2 Acceleration { get; set; }
        Vector2 CurrentAcceleration { get; set; }
    }
}
