﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Project_Game_development
{
    internal abstract class Character<TState> : IRotatable, IMovable where TState : Enum
    {
        public TState CurrentState { get; set; }
        public Vector2 Position { get; set; }
        public float Rotation { get; set; }
        public Vector2 RotationPoint { get; set; }
        public Vector2 InitialSpeed { get; set; } = new Vector2(1, 1);
        public float MaxSpeed { get; set; } = 5;
        public Vector2 Acceleration { get; set; } = new Vector2(0.1f, 0.1f);
        public MoveBehavior MoveBehavior { get; set; }

        protected Dictionary<TState, SpriteProperties> stateMappings;
        protected Texture2D currentTexture;
        protected Animation currentAnimation;
        protected RotationManager rotationManager;
        protected MoveManager mover;

        public Character(Vector2 position)
        {
            stateMappings = ((TState[])Enum.GetValues(typeof(TState))).ToDictionary(state => state, state => GameTextures.GetProperties(state));
            Position = position;
            CurrentState = Enum.GetValues(typeof(TState)).Cast<TState>().FirstOrDefault();

            rotationManager = new RotationManager(this);
            mover = new MoveManager();
        }


        public virtual void Update(GameTime gameTime)
        {
            currentTexture = stateMappings[CurrentState].Texture;
            currentAnimation = stateMappings[CurrentState].Animation;
            RotationPoint = stateMappings[CurrentState].RotationPoint;

            mover.Move(this, MoveBehavior);
            rotationManager.Update();
            currentAnimation.Update(gameTime);
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(currentTexture, Position, currentAnimation.CurrentFrame.SourceRectangle, Color.White, Rotation, RotationPoint, 1f, SpriteEffects.None, 0f);
        }
    }
}