using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using System.Collections;

namespace ProyectoBob
{
   enum SideDirection { Jump, Stand_Right, Move_Right, GameOver, cac}

    class AnimatedCharacter
    {
        // Attributes
        protected BasicSprite  standRight, jump, cactus1, cactus2, cactus3;
        protected BasicAnimatedSprite  walkRigh;   
        protected SideDirection direccion;
        protected int incX = 2;
        protected float incY = 2;
        protected Random myRandom;
        protected ArrayList Cactu; //Cargar muchos enemigos en un arreglo
        protected int nR;
        protected int posY = 550; //La posicion de los cactus en Y
 
        // Methods 

        //Load content para imagenes estáticas (BasicSprite)

        public virtual void LoadContent_Jump(ContentManager Content, string dirName, String name)
        {
            jump = new BasicSprite();
            direccion = SideDirection.Jump;
            jump.LoadContent(Content, dirName, name);
        }

        public virtual void LoadContent_StandRight(ContentManager Content, string dirName, String name)
        {
            standRight = new BasicSprite();
            direccion = SideDirection.Stand_Right;
            standRight.LoadContent(Content, dirName, name);
        }

        //Loading metodo para animaciones con multiples archivos (BasicAnimatedSprite)     
        public virtual void LoadContent_WalkRight(ContentManager Content, String nameDir, String nameFile, int frameCount, float timePerFrame)
        {
            walkRigh = new BasicAnimatedSprite();
            direccion = SideDirection.Move_Right;
            walkRigh.LoadContent(Content, nameDir, nameFile, frameCount, timePerFrame);
        }  
                    

        public virtual void Update(GameTime gameTime)
        {
            //Poner los valores por default         
            if (direccion == SideDirection.Move_Right)
                direccion = SideDirection.Stand_Right;
        }


        public virtual Rectangle Pos
        {
            set
            {
                if (direccion == SideDirection.cac)
                {
                    //Dar la posicion de cada uno de los cactus 
                    for (int i = 0; i < Cactu.Count; i++)
                    {
                        ((BasicSprite)Cactu[i]).Pos = value;
                    }
                }

                standRight.Pos = value;
                walkRigh.Pos = value;

            }
            get { return walkRigh.Pos; }
        }
        
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            switch (direccion)
            {
                case SideDirection.Move_Right:
                    {
                        walkRigh.Draw(spriteBatch);
                        break;
                    }

                case SideDirection.Stand_Right:
                    {
                        standRight.Draw(spriteBatch);
                        break;
                    }
            }
        }
    }
}


