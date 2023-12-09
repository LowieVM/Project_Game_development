using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Project_Game_development
{
    internal abstract class Character<TState> : MovableObject, IHittable, ICircle where TState : Enum
    {
        public TState CurrentState { get; set; }
        public int Health { get; set; } = 100;
        public bool isAlive { get; set; } = true;
        public List<IHittable> Enemies { get; set; }
        public float TimeSinceDeath { get; set; } = 0;
        public float LayerDepth { get; set; } = 0.5f;
        public float CircleRadius { get; set; } = 20;

        protected Dictionary<TState, SpriteProperties> stateMappings;
        protected RotationManager rotationManager;
        protected MoveManager mover;

        public Character(Vector2 position, MoveManager moveManager, List<IHittable> enemies) : base(position)
        {
            InitialSpeed = new Vector2(1, 1);
            MaxSpeed = 5;
            Acceleration = new Vector2(0.1f, 0.1f);
            CurrentAcceleration = new Vector2(0.1f, 0.1f);
            stateMappings = ((TState[])Enum.GetValues(typeof(TState))).ToDictionary(state => state, state => GameTextures.GetProperties(state));
            CurrentState = Enum.GetValues(typeof(TState)).Cast<TState>().FirstOrDefault();

            rotationManager = new RotationManager(this);
            mover = moveManager;

            this.Enemies = enemies;
        }

        public void TakeDamage(int damage)
        {
            Health -= damage;
            if (Health <= 0)
            {
                Die();
            }
        }

        protected abstract void Die();

        public override void Update(GameTime gameTime)
        {
            if (!isAlive)
            {
                TimeSinceDeath += (float)gameTime.ElapsedGameTime.TotalSeconds;
                return;
            }

            currentTexture = stateMappings[CurrentState].Texture;
            currentAnimation = stateMappings[CurrentState].Animation;
            RotationPoint = stateMappings[CurrentState].RotationPoint;

            mover.Move(this, MoveBehavior);
            rotationManager.Update();
            currentAnimation.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(currentTexture, Position, currentAnimation.CurrentFrame.SourceRectangle, Color.White, Rotation, RotationPoint, 1f, SpriteEffects.None, LayerDepth);
        }
    }
}