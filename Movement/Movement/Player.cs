using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Movement
{
    class Player
    {
        public Vector2 Position;
        public Vector2 Velocity;
        public Vector2 Acceleration;

        float friction;
        bool jumping = false;

        public Texture2D Texture { get; set; }
        public Color Color { get; set; }

        Vector2 wantedPosition;

        public Player(Texture2D texture, Vector2 position)
        {
            Texture = texture;
            Position = position;
            Color = Color.White;
        }

        public void Move(Vector2 axis)
        {
            wantedPosition = axis;
        }

        public void Update(float elapsed)
        {
            friction = -6.0f;

            if (jumping)
            {
                friction = -6.0f;
            }

            Vector2 speed = new Vector2(600, 0);
            
            Acceleration = wantedPosition * speed;

            Acceleration += friction * Velocity;

            // Gravity
            Acceleration.Y = 3000;

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

        public void Jump()
        {
            if (!jumping)
            {
                jumping = true;
                Velocity.Y = -1000;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, Color);
            //spriteBatch.Draw(Texture, Position, Color.Red * 0.7f);
        }
    }
}
