using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Game_development
{
    internal interface IMovable : IPositional
    {
        Vector2 InitialSpeed { get; set; }
        float MaxSpeed { get; set; }
        Vector2 MoveDirection { get; set; }
        Vector2 Acceleration { get; set; }
    }
}
