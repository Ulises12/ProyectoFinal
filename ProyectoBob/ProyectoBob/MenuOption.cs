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
    class MenuOption
    {

        Texture2D achieveON, achieveOFF;
        bool achieveStatus;
        Vector2 pos;

        public void LoadContent(ContentManager Content, String name, float x, float y)
        {
            achieveOFF = Content.Load<Texture2D>(name);
            achieveON = Content.Load<Texture2D>(name + "_press");
            achieveStatus = false;
            pos = new Vector2(x, y);
        }

        public void SetPos(int x, int y)
        {
            pos.X = x;
            pos.Y = y;
        }
        public Vector2 GetPos()
        {
            return pos;
        }
        public int Update()
        {
            Rectangle area = new Rectangle((int)pos.X, (int)pos.Y, achieveOFF.Width, achieveOFF.Height);
            if (area.Contains(Mouse.GetState().X, Mouse.GetState().Y))
            {
                achieveStatus = true;
                if (Mouse.GetState().LeftButton == ButtonState.Pressed)
                {
                    return 1;
                }
            }
            else
            {
                achieveStatus = false;
            }
            return 0;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            if (achieveStatus == true)
            {
                spriteBatch.Draw(achieveON, pos, Color.White);
            }
            else
            {
                spriteBatch.Draw(achieveOFF, pos, Color.White);
            }
        }


    }
}
