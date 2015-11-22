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
    class Bob : Hero
    {
        public void LoadContent(ContentManager Content)
        {        
            this.LoadContent_WalkRight(Content, "BobRight", "Front_f",8, 0.06f);
            this.LoadContent_StandRight(Content, "StandState", "StandRightP");
            //this.LoadContent_Jump(Content, "BobJump", "LinkFrontStand");        
        }
    }
}
