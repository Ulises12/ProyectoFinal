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
    class Hero : AnimatedCharacter
    {
        Keys jumping = Keys.Space;
        Keys crouching = Keys.Down;
        Keys right = Keys.Right;
        // for jump using Euler eqs.
        float accel = 0.0f, gravity = 0.0f;
        float vel = 0.0f, posin = 0.0f, deltaT = 0.05f;
        int posInit = 0;    // to stop the jump
        BasicMap map;

        public void SetMap(BasicMap theMap)
        {
            map = theMap;
        }


        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            //Rectangle currentPos = this.Pos;
            /* if (Keyboard.GetState().IsKeyDown(crouch))
             {
               
             }*/

            direccion = SideDirection.Move_Right;
            walkRigh.Update(gameTime);
            if (Keyboard.GetState().IsKeyDown(right))
            {
                //if (currentPos.X <= (widthLimit - currentPos.Width))
               // {

                    direccion = SideDirection.Move_Right;
                    walkRigh.Update(gameTime);
                    Rectangle currentPos = walkRigh.Pos;
                    //Rectangle pos = new Rectangle(currentPos.X, currentPos.Y, currentPos.Width, currentPos.Height);
                
                    //pos.X += incX;
                    //if (map.VallidateCollision(currentPos))
                   // {
                        currentPos.X += incX;
                        this.Pos = currentPos;
                    //}
               // }
                //this.Pos = currentPos;
            }
            // Only accept ONE keyboard call - check to see we are not jumping (i.e. gravity = 0.0)
            if (Keyboard.GetState().IsKeyDown(jumping) && gravity == 0.0)
            {
                accel = -2000.0f;       // acceleration impulse will control the height of the jump
                vel = 0.0f;
                posin = (float)walkRigh.Pos.Y;
                posInit = walkRigh.Pos.Y;
                gravity = 9.81f * 3.2f; // Gravity will control de speed of the jump (in conjunction with deltaT)
                // OJO: deltaT is constant in this class.. can also be based on time per frame (technically, it should be the same)
            }

            // do update only if gravity
            // Means that we are jumping
            // OJO: Can also use states to determine whether character will be jumping
            //      This will change the logic at the beginning of Update()
            if (gravity != 0.0)
            {
                vel += (accel + gravity) * 2 * deltaT; //Regresar a este valor sin el 2
                posin += vel *deltaT;
                // Set to zero so that there is only ONE impulse (setp impulse)
                accel = 0.0f;
                // Update position
                Rectangle currentPos2 = walkRigh.Pos;
                currentPos2.Y = (int)posin;
                this.Pos = currentPos2;
            }

            // stop condition
            // When does the character stop jumping? When it returns to its initial position
            // Also, making sure we are actually jumping (i.e. vel is not 0)
            if ((posInit <= (int)posin) && (vel != 0.0f))
            {
                gravity = 0.0f;
                accel = 0.0f;
                vel = 0.0f;
                posin = (float)posInit;
                // Update position
                Rectangle currentPos2 = walkRigh.Pos;
                currentPos2.Y = (int)posin;
                this.Pos = currentPos2;
            }
        }
    }
}
