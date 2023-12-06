using Microsoft.Xna.Framework;

namespace Project_Game_development
{
    internal interface IHittable : IPositional, IGameObject
    {
        public void TakeDamage(int damage);
        public bool isAlive { get; set; }

        public float TimeSinceDeath { get; set; }
    }
}