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

        Texture2D cuadro;
        Texture2D startON, exitON;
        Texture2D startOFF, exitOFF;
        Texture2D imagenBob;

        Color[] pixelData;
        Texture2D cuadroGuia;
        int selectedItem;
        int clickedItem;

        public void LoadContent(ContentManager Content)
        {
            cuadro = Content.Load<Texture2D>("Menu/FondoBotones");
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
            spriteBatch.Draw(cuadro, new Vector2(100, 100), Color.White);
            spriteBatch.Draw(imagenBob, new Vector2(500, 100), Color.White);
            spriteBatch.Draw(startOFF, new Vector2(550, 500), Color.White);
            spriteBatch.Draw(exitOFF, new Vector2(550, 600), Color.White);

            if (selectedItem == 1)
                spriteBatch.Draw(startON, new Vector2(550, 500), Color.White);
            if (selectedItem == 2)
                spriteBatch.Draw(exitON, new Vector2(550, 600), Color.White);

            spriteBatch.End();
        }

    }
}
