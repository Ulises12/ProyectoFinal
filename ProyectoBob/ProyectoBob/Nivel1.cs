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
        Cactus cactus;
        Logo logo;

        public void LoadContent(ContentManager Content)
        {


            theMap = new BasicMap();
            theMap2 = new BasicMap();
            bob = new Bob();
            cactus = new Cactus();
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
            cactus.LoadCac(Content);
            cactus.LoadLifes(Content);

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
            if (cactus.Gameover() )
                 {
                     
                 }
            else
            {
                theMap.Update(gameTime);
                theMap2.Update(gameTime);
                bob.Update(gameTime);
                cactus.Update(gameTime);
                cactus.ColisionCactus(bob.Pos);
            }
            return 1;
        }


        public void Draw(SpriteBatch spriteBatch)
        {
            theMap.DrawOver(spriteBatch);
            theMap2.DrawOver(spriteBatch);
            bob.Draw(spriteBatch);
            cactus.Draw(spriteBatch);
            cactus.DrawLife(spriteBatch);
            logo.Draw(spriteBatch);
            theMap.DrawUnder(spriteBatch);
            theMap2.DrawUnder(spriteBatch);
        }
        
          

    }
}
