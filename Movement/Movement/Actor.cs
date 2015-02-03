using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Movement
{
    class Actor
    {
        public Vector2 Position;
        public Vector2 Velocity;
        public Vector2 Acceleration;

        protected float friction = -6.0f;
        protected bool jumping = false;
        protected Vector2 wantedPosition;

        public Texture2D Texture { get; set; }
        public Color Color { get; set; }

        public virtual void Update(float elapsed)
        {
            GravitationalMovement(elapsed);
        }

        private void GravitationalMovement(float elapsed)
        {
            Vector2 speed = new Vector2(1500, 0);

            Acceleration = wantedPosition * speed;

            if (jumping)
            {
                Acceleration.X = 0;
            }

            friction = -6.0f;

            if (jumping)
            {
                friction = 0;
            }

            Acceleration += friction * Velocity;

            // Gravity
            Acceleration.Y = 1500;

            Vector2 delta = (0.5f * Acceleration * elapsed * elapsed + Velocity * elapsed);

            Velocity += Acceleration * elapsed;

            Position += delta;

            if (Position.Y >= 300)
            {
                Position.Y = 300;
                Velocity.Y = 0;
                jumping = false;
            }
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, Color);
        }
    }
}
