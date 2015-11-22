#region Using Statements
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
// using Microsoft.Xna.Framework.GamerServices;
#endregion

namespace ProyectoBob
{
    
    class BasicSprite
    {
       //Atributos
        Texture2D image;
        Rectangle pos;
        bool collision;
        Vector2 increment; //Incremento para movimiento automático
        bool move; // booleano para asiganr el movimiento automatico


        //METODOS


        //Metodo para asiganer incremento
        public void SetIncrement(Vector2 input)
        {
            increment = input;

        }

        //Metodo para asignar moviento automatico
        public void SetMove(bool set)
        {
            move = set;
        }    
        // Metodo de inicializacion
        public void LoadContent(ContentManager Content,String dirName, String name)
        {
            image = Content.Load<Texture2D>(dirName + "/" + name);
            //Se respetan los valores que tiene la imagen
            pos = new Rectangle(0,0, image.Width,image.Height);
        }
        
        //Checar colisiones 
        public bool Colision(Rectangle rect)
        {
            bool tempCol = pos.Intersects(rect);
            if (collision || tempCol)

                collision = true;
            return collision;
        }
        public void Update(GameTime GameTime)
        {
            if (move)
            {
                pos.Y += (int)increment.Y;
                pos.X += (int)increment.X;

            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            if (collision)
            spriteBatch.Draw(image, pos, Color.Red);   
            else
                spriteBatch.Draw(image, pos, Color.White); 
            spriteBatch.End();

            collision = false;
        }

       // Regresa/obtiene el valor de la posicion en un momento en especifico
        public Rectangle Pos
        {
            set
            {
                pos = value;
            }
            get
            {
                return pos;
            }
        }
    
    
    
    
    }
}


