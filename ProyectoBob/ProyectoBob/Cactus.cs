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
    class Cactus : Enemy
    {         
        public void LoadCac(ContentManager Content)
        {
            this.Cactus(Content, "Cactus", "Cactus1","Cactus2", "Cactus3");



        }
      

        
    }
}
