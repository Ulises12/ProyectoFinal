using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using System.Collections;

enum Life { Life0,Life1,Life2,Life3, gameover}

//Los enemigos tendran en comun el movimiento automatico y la capacidad de restar vidas a Bob
namespace ProyectoBob
{
    class Enemy : AnimatedCharacter  
    {
        BasicSprite Life0,Life1, Life2, Life3, GameOver;
        protected Life Lifes;
        int carga=3;
        float delay = 2500f;
        bool game;

        //Cargar los sprites de Cactus 
        public virtual void LoadContentCactus1(ContentManager Content, String dirName, String name)
        {
            cactus1 = new BasicSprite();
            cactus1.LoadContent(Content, dirName, name);
        }

        public virtual void LoadContentCactus2(ContentManager Content, String dirName, String name)
        {
            cactus2 = new BasicSprite();
            cactus2.LoadContent(Content, dirName, name);
        }

        public virtual void LoadContentCactus3(ContentManager Content, String dirName, String name)
        {
            cactus3 = new BasicSprite();
            cactus3.LoadContent(Content, dirName, name);
        }



        //Cargar aqui los valores de los sprites de vivoras


        //Cargar aqui los valores de los sprites de murcielagos 
        
        public virtual void LoadLifes(ContentManager Content)
        {

            Life0 = new BasicSprite();
            Life0.LoadContent(Content, "Life", "LifeCero");

            Life1 = new BasicSprite();
            Life1.LoadContent(Content, "Life", "LifeUno");

            Life2 = new BasicSprite();
            Life2.LoadContent(Content, "Life", "LifeDos");

            Life3 = new BasicSprite();
            Life3.LoadContent(Content, "Life", "LifeTres");


            GameOver = new BasicSprite();
            GameOver.LoadContent(Content, "Menu", "gameover");

            Lifes = Life.Life3;
            
        }


     
        public virtual void Colision(Rectangle rect)
        {
            
                for (int i = 0; i < Cactu.Count; i++)
                {
                    delay++;
                    bool n = ((BasicSprite)Cactu[i]).Colision(rect);
                    
                    if (delay >= 2500)
                    {
                    if (((BasicSprite)Cactu[i]).Colision(rect) && carga == 3)
                    {

                        Lifes = Life.Life2;
                        carga = 2;
                        delay = 0;
                    }
                    else if (((BasicSprite)Cactu[i]).Colision(rect) && carga == 2)
                    {

                        Lifes = Life.Life1;
                        carga = 1;
                        delay = 0;
                    }
                    else if (((BasicSprite)Cactu[i]).Colision(rect) && carga <= 1)
                    {
                        Lifes = Life.Life0;
                        Lifes = Life.gameover;
                        carga = 0;
                        delay = 0;      
                    }                   

                    }                 
                }
                
           // }

         }

         public virtual bool Gameover()
        {

            if (Lifes == Life.gameover)
                game = true;
            else
                game = false;

            return game;
            
        }

        public  virtual void UpdateEnemy (GameTime gameTime)
         {
             //PARA CACTUS 
             if (direccion == SideDirection.cac)
             {
                 for (int k = 0; k < Cactu.Count; k++)
                 {
                     ((BasicSprite)Cactu[k]).SetMove(true);
                     ((BasicSprite)Cactu[k]).SetIncrement(new Vector2(-2, 0));
                     ((BasicSprite)Cactu[k]).Update(gameTime);

                 }
             }
         }


        public virtual void DrawEnemys(SpriteBatch spriteBatch)
        {
            switch (direccion)
            {
                    //Pintar los cactus
                case SideDirection.cac:
                    {
                        for (int k = 0; k < Cactu.Count; k++)
                            ((BasicSprite)Cactu[k]).Draw(spriteBatch);
                        break;
                    }
            }
        }

            public virtual void DrawLife(SpriteBatch spriteBatch )
            {
                switch(Lifes)
                {
                    case Life.Life3:
                        {
                            Rectangle temp = Life3.Pos;
                            temp.X = 1100;
                            temp.Y = 0;
                            Life3.Pos = temp;
                            Life3.Draw(spriteBatch);
                            break;
                        }
                     case Life.Life2:
                        {
                            Rectangle temp = Life2.Pos;
                            temp.X = 1100;
                            temp.Y = 0;
                            Life2.Pos = temp;
                            Life2.Draw(spriteBatch);
                            break;
                        }
                     case Life.Life1:
                        {
                            Rectangle temp = Life1.Pos;
                            temp.X = 1100;
                            temp.Y = 0;
                            Life1.Pos = temp;
                            Life1.Draw(spriteBatch);
                            break;
                        }
                     case Life.Life0:
                        {
                            Rectangle temp = Life0.Pos;
                            temp.X = 1100;
                            temp.Y = 0;
                            Life0.Pos = temp;
                            Life0.Draw(spriteBatch);
                            break;
                        }
                    case Life.gameover:
                        {
                            Rectangle tem = GameOver.Pos;
                            tem.X = 350;
                            tem.Y = 300;
                            GameOver.Pos = tem;
                            GameOver.Draw(spriteBatch);
                            break;
                        }
                }
            }
         
        }




    }

