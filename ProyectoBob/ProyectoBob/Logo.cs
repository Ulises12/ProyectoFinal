using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;

namespace ProyectoBob
{
    class Logo
    {
        Texture2D logo;
        Rectangle pos;

        public void LoadContent(ContentManager Content)
        {
            logo = Content.Load<Texture2D>("Logo/logo");
            pos = new Rectangle(10, 20, logo.Width, logo.Height);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(logo, pos, Color.White);
            spriteBatch.End();
        }

    }
}
