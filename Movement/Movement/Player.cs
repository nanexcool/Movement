using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Movement
{
    class Player : Actor
    {
        public Player(Texture2D texture, Vector2 position)
        {
            Texture = texture;
            Position = position;
            Color = Color.White;
        }

        public override void Update(float elapsed)
        {
            base.Update(elapsed);
        }

        public void Move(Vector2 axis)
        {
            wantedPosition = axis;
        }

        public void Jump()
        {
            if (!jumping)
            {
                jumping = true;
                Velocity.Y = -800;
            }
        }

    }
}
