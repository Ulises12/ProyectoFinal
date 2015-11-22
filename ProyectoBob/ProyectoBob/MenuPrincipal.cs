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
    class MenuPrincipal
    {
        //Atributos
        //botones
        Texture2D startON, exitON;
        Texture2D startOFF, exitOFF;
        Texture2D imagenBob; //logo del videojuego
        float startX, startY, exitX, exitY, BobY, BobX; //Parametrizar los tamaños de los botones
        Color[] pixelData; //Para saber donde esta tocando el mouse
        Texture2D cuadroGuia; //para regresar un valor, de acuerdo al color que se este tocando
        int selectedItem;
        int clickedItem;

        //La mayoria de este codigo fue tomada de la solucion ""GUI manejo de escenas"
        public void LoadContent(ContentManager Content)
        {
            imagenBob = Content.Load<Texture2D>("Menu/treasure");
            cuadroGuia = Content.Load<Texture2D>("Menu/FondoBotonesG");
            startON = Content.Load<Texture2D>("Menu/StartON");
            startOFF = Content.Load<Texture2D>("Menu/StartOFF");
            exitON = Content.Load<Texture2D>("Menu/SalirOFF");
            exitOFF = Content.Load<Texture2D>("Menu/SalirON");

            selectedItem = 0;
            clickedItem = 0;

            pixelData = new Color[cuadroGuia.Width * cuadroGuia.Height];
            cuadroGuia.GetData<Color>(pixelData);
        }

        public int Update()
        {
            if (cuadroGuia.Bounds.Contains(Mouse.GetState().X, Mouse.GetState().Y))
            {
                Color pixel = pixelData[Mouse.GetState().Y * cuadroGuia.Width + Mouse.GetState().X];

                selectedItem = 0;
                if (pixel.R == 0 && pixel.G == 255 && pixel.B == 0)
                    selectedItem = 1;
                if (pixel.R == 255 && pixel.G == 0 && pixel.B == 255)
                    selectedItem = 2;

                if (selectedItem > 0 && Mouse.GetState().LeftButton == ButtonState.Pressed)
                {
                    clickedItem = selectedItem;
                    return clickedItem;
                }

            }
            return 0;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(imagenBob, new Vector2(BobX, BobY), Color.White);
            spriteBatch.Draw(startOFF, new Vector2(startX, startY), Color.White);
            spriteBatch.Draw(exitOFF, new Vector2(exitX, exitY), Color.White);

            if (selectedItem == 1)
                spriteBatch.Draw(startON, new Vector2(startX, startY), Color.White);
            if (selectedItem == 2)
                spriteBatch.Draw(exitON, new Vector2(exitX, exitY), Color.White);

            spriteBatch.End();
        }

        //Los siguientes dos metodos (setHeightLimits, setWidth) son para delimitar la pantalla 
        public void PosicionBotones(float StrBottonX, float StrBottonY, float ExitBottonX, float ExitBottonY, float BobLogoX, float BobLogoY)
        {
            startY = StrBottonY;
            startX = StrBottonX;
            exitY = ExitBottonY;
            exitX = ExitBottonX;
            BobY = BobLogoY;
            BobX = BobLogoX;
        }
    }
}
