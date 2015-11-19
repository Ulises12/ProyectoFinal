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
      enum SideDirection { Jump, Crouch, Stand_Right, Move_Left, Move_Right, GameOver, cac}

    class AnimatedCharacter
    {
        // Attributes
        protected BasicSprite  standRight, jump, crouch, cactus1, cactus2, cactus3, gameOver;

        protected BasicAnimatedSprite  walkRigh;   
        protected SideDirection direccion;
        protected int incX = 2;
        protected float incY = 2;
        protected Rectangle col;
        protected int heightLimit, widthLimit;
        protected bool collision;
        protected Random myRandom;
        protected ArrayList Cactu; //Cargar muchos enemigos en un arreglo
        protected int nR;
        protected int posY = 550; //La posicion de los cactus en Y
 
        // Methods 
        //LoadContent para cargar los cactus

        public void Load_GameOver(ContentManager Content, String dirName, String name)
        {
            gameOver= new BasicSprite();
            direccion = SideDirection.GameOver;
            gameOver.LoadContent(Content, dirName, name);
        }

        public virtual void Cactus(ContentManager Content, string dirName, String name, String name2, String name3)
        {
            Cactu = new ArrayList();

            myRandom = new Random();

            for (int k = 0; k < 20; k++) 
            {
                cactus1 = new BasicSprite();
                cactus2 = new BasicSprite();
                cactus3 = new BasicSprite();

                cactus1.LoadContent(Content, dirName, name);
                cactus2.LoadContent(Content, dirName, name2);
                cactus3.LoadContent(Content, dirName, name3);

                nR = myRandom.Next(1, 4);

                if (nR == 1)
                {
                    Rectangle tempo = cactus1.Pos;
                    if (k == 0)
                        tempo.X = 350;
                    if (k >= 1)
                        tempo.X = (myRandom.Next(360, 400)) + (((BasicSprite)Cactu[(k - 1)]).Pos.X); //Se separan los cactus
                   
                    
                    tempo.Y = posY;
                    cactus1.Pos = tempo;
                    Cactu.Add(cactus1);
                }
                else
                     if (nR== 2)
                {
                    Rectangle tempo = cactus2.Pos;
                    if (k == 0)
                        tempo.X = 350;
                    if (k >= 1)
                        tempo.X = (myRandom.Next(360, 400)) + (((BasicSprite)Cactu[(k - 1)]).Pos.X); //Se separan los cactus
                    
                    tempo.Y = posY;
                    cactus2.Pos = tempo;
                   
                    Cactu.Add(cactus2);
                }

                     else
                         if (nR >= 3)
                         {
                             Rectangle tempo = cactus3.Pos;
                             if (k == 0)
                                 tempo.X = 350;
                             if (k >= 1)
                                 tempo.X = (myRandom.Next(360, 400)) + (((BasicSprite)Cactu[(k - 1)]).Pos.X); //Se separan los cactus
                             
                             
                             tempo.Y = posY;
                             cactus3.Pos = tempo;
                            
                             Cactu.Add(cactus3);
                         }

                direccion = SideDirection.cac;
            }
        }



        //Load content para imagenes estáticas (BasicSprite)

        public virtual void LoadContent_Jump(ContentManager Content, string dirName, String name)
        {
            jump = new BasicSprite();
            direccion = SideDirection.Jump;
            jump.LoadContent(Content, dirName, name);
        }

        public virtual void LoadContent_Crouch(ContentManager Content, string dirName, String name)
        {
            crouch = new BasicSprite();
            direccion = SideDirection.Crouch;
            crouch.LoadContent(Content, dirName, name);
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
        
        //Loading metodo para animaciones con un solo archivo (BasicAnimatedSprite)       
        public virtual void LoadContent_WalkRight(ContentManager Content, string dirName, String name, int frameWidth, int frameHeight, int frameCount, float timePerFrame)
        {
            walkRigh = new BasicAnimatedSprite();
            direccion = SideDirection.Move_Right;
            walkRigh.LoadContent(Content, dirName, name, frameWidth, frameHeight, frameCount, timePerFrame);
        }
            
        //Los siguientes dos metodos (setHeightLimits, setWidth) son para delimitar la pantalla 
        public void setHeightLimits(int b)
        {
            heightLimit = b;
        }

        public void setWidthLimits(int a)
        {
            widthLimit = a;
        }
        //Checar colisiones
      /*  public virtual bool Collision(Rectangle rect)
        {            
            standRight.Colision(rect);
            jump.Colision(rect);
            crouch.Colision(rect);
            walkRigh.Colision(rect);

           collision = standRight.Colision(rect);
            return collision;
        }*/

        public virtual void Update(GameTime gameTime)
        {
            //Poner los valores por default         
            if (direccion == SideDirection.Move_Right)
                direccion = SideDirection.Stand_Right;
            
            //PARA CACTUS 
            if (direccion== SideDirection.cac)
            {
                for (int k = 0; k < Cactu.Count; k++)
                {
                ((BasicSprite)Cactu[k]).SetMove(true);
                ((BasicSprite)Cactu[k]).SetIncrement(new Vector2(-2, 0));
                ((BasicSprite)Cactu[k]).Update(gameTime);

                }
            }
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
                //jump.Pos = value;
                //crouch.Pos = value;
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
              /*  case SideDirection.Jump:
                    {
                        jump.Draw(spriteBatch);
                        break;
                    }*/
                case SideDirection.Crouch:
                    {
                        crouch.Draw(spriteBatch);
                        break;
                    }
                case SideDirection.Stand_Right:
                    {
                        standRight.Draw(spriteBatch);
                        break;
                    }

                case SideDirection.cac:
                    {
                        for (int k = 0; k < Cactu.Count; k++)
                            ((BasicSprite)Cactu[k]).Draw(spriteBatch);
                        break;
                    }

            }
        }
    }
}


