using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
//using Microsoft.Xna.Framework.GamerServices;


//La mayoria del codigo utilizado en esta clase fue reutilizado de los ejercicios realizados en clase

namespace ProyectoBob
{
    class BasicMap
    {
        //Atributos

        Texture2D transitable;
        Texture2D notransitable;
        Rectangle pos, posit;
        Color[] OverData;
        int incX;

        bool test;

        //Propiedades
        /*public Rectangle Pos
        {
            set
            {
                pos = value;
                posit = value;
            }

            get
            {
                return posit;
            }
        }*/

        //Metodos
        public void LoadContent_Transitable(ContentManager Content, String transi, int x, int y)
        {
            transitable = Content.Load<Texture2D>(transi);


            OverData = new Color[transitable.Width * transitable.Height];
            transitable.GetData(OverData);
            pos = new Rectangle(x, y, (transitable.Width - 5000), (transitable.Height + 20 ));
            Console.WriteLine(transitable.Height + 20);
        }


        public void LoadContent_Notransitable(String notransi, ContentManager Content, int x, int y)
        {
            notransitable = Content.Load<Texture2D>(notransi);//back
            posit = new Rectangle(x, y, (notransitable.Width), (notransitable.Height));
        }

        public void SetIncrement(int incX)
        {
            this.incX = incX;
        }
        //No se necesita este Updated
        public void Update(GameTime gameTime)
        {
            Rectangle currentPos = pos;
            Rectangle currentPos1 = posit;

            currentPos.X -= incX;
            currentPos1.X -= incX;
            //regresar la imagen cuando no se dibuje
            if (currentPos.X <= 0 - currentPos.Width)
                currentPos.X = currentPos.Width;

            if (currentPos1.X <= 0 - currentPos1.Width)
                currentPos1.X = currentPos1.Width;

            pos = currentPos;
            posit = currentPos1;
        }

        //Codigo recuperado del video "11.- Contruccion OO - Mapas"
        public bool VallidateCollision(Rectangle characterSize)
        {
            Color col1, col2, col3, col4; //Variables temporales que almacenan el color de la imagen
            int xTex, yTex;

            xTex = characterSize.X - 1;
            yTex = characterSize.Y - 1;
            col1 = OverData[(yTex * transitable.Width) + xTex];

            xTex = characterSize.X + characterSize.Width;
            yTex = characterSize.Y;
            col2 = OverData[(yTex * transitable.Width) + xTex];

            xTex = characterSize.X;
            yTex = characterSize.Y + characterSize.Height / 2;
            col3 = OverData[(yTex * transitable.Width) + xTex];

            xTex = characterSize.X + characterSize.Width;
            yTex = characterSize.Y + characterSize.Height / 2;
            col4 = OverData[(yTex * transitable.Width) + xTex];


            if (col1.A != 0 && col2.A != 0 && col3.A != 0 && col4.A != 0)
                return true;
            else
                return false;

        }
        public void DrawUnder(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(notransitable, posit, Color.White);
            spriteBatch.End();
        }

        public void DrawOver(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(transitable, pos, Color.White);
            spriteBatch.End();
        }

    }
}