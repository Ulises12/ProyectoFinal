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
    class Cactus : Enemy
    {         
        //Cargar Texturas 

        public virtual void LoadConCactus1(ContentManager Content)
        {
            this.LoadContentCactus1(Content, "Cactus", "Cactus1");
        }

        public virtual void LoadConCactus2(ContentManager Content)
        {
            this.LoadContentCactus2(Content, "Cactus", "Cactus2");
        }
        public virtual void LoadConCactus3(ContentManager Content)
        {
            this.LoadContentCactus3(Content, "Cactus", "Cactus3");
        }
        
        //Logica de cactus para aparecer de forma aleatoria 

        public virtual void Cac(ContentManager Content)
        {
            Cactu = new ArrayList();

            myRandom = new Random();

            for (int k = 0; k < 20; k++)
            {
                this.LoadConCactus1(Content);
                this.LoadConCactus2(Content);
                this.LoadConCactus3(Content);

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
                    if (nR == 2)
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
    }
}
