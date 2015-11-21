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
    class Nivel1
    {

        Bob bob;
        BasicMap theMap, theMap2;
        Cactus cactus1,cactus2,cactus3;
        Logo logo;

        bool GO; 

        public void LoadContent(ContentManager Content)
        {


            theMap = new BasicMap();
            theMap2 = new BasicMap();
            bob = new Bob();
            logo = new Logo();

            bob.LoadContent(Content);
            Rectangle temp = bob.Pos;
            temp.X = 100;
            temp.Y = 430;
            temp.Width = 140;
            temp.Height = 210;
            bob.Pos = temp;
            bob.SetMap(theMap);
            //Cactus           

            cactus1 = new Cactus();
            cactus2 = new Cactus();
            cactus3 = new Cactus();

            cactus1.LoadConCactus1(Content);
            cactus2.LoadConCactus2(Content);
            cactus3.LoadConCactus3(Content);

            cactus1.LoadLifes(Content);
            cactus2.LoadLifes(Content);
            cactus3.LoadLifes(Content);

            cactus1.Cac(Content);
            cactus2.Cac(Content);
            cactus3.Cac(Content);


            //Mapas
            theMap.LoadContent_Transitable(Content, "Transitable", 0, -1);
            theMap.LoadContent_Notransitable("NoTransitable", Content, 0, 640);
            theMap.SetIncrement(14);

            theMap2.LoadContent_Transitable(Content, "Transitable", 4080, -1);
            theMap2.LoadContent_Notransitable("NoTransitable", Content, 9072, 640);
            theMap2.SetIncrement(14);

            //Logo
            logo.LoadContent(Content);

            
            
        }

        public int Update(GameTime gameTime)
        {
            if (cactus1.Gameover() | cactus2.Gameover() | cactus3.Gameover() )
                 {
                     GO = true;
                 }
            else
            {
                theMap.Update(gameTime);
                theMap2.Update(gameTime);
                bob.Update(gameTime);
                //Cactus
                cactus1.UpdateEnemy(gameTime);
                cactus2.UpdateEnemy(gameTime);
                cactus3.UpdateEnemy(gameTime);
                cactus1.Colision(bob.Pos);
                cactus2.Colision(bob.Pos);
                cactus3.Colision(bob.Pos);

            }
            return 1;
        }


        public void Draw(SpriteBatch spriteBatch)
        {
            theMap.DrawOver(spriteBatch);
            theMap2.DrawOver(spriteBatch);
            if(GO)
            {

            }
            else
            {
                    bob.Draw(spriteBatch);
                    cactus1.DrawEnemys(spriteBatch);
                    cactus2.DrawEnemys(spriteBatch);
                    cactus3.DrawEnemys(spriteBatch);
                    logo.Draw(spriteBatch);
            }

            cactus1.DrawLife(spriteBatch);
            cactus2.DrawLife(spriteBatch);
            cactus3.DrawLife(spriteBatch);

            theMap.DrawUnder(spriteBatch);
            theMap2.DrawUnder(spriteBatch);
        }
        
          

    }
}
