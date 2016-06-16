using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;


namespace carSensor
{
    public class Blocks
    {
        public Texture2D texture;

        public Texture2D secondTex;
        public Color[] secondBlockTexData;
        public Vector2 secondBoxPos;
        public Rectangle secondBoxRec;

        public Color[] blockTextureData;

        public Vector2 firstBoxPos;
        public Rectangle firstBoxRec;

        public int pos, pos2;
        public float distance, distance2;


        public Blocks()
        {
            texture = null;
            secondTex = null;
            secondBoxPos = new Vector2(0, 0);
            firstBoxPos = new Vector2(0, 0);
            
        }

        public void LoadContent(ContentManager Content)
        {
            texture = Content.Load<Texture2D>("block");
            secondTex = Content.Load<Texture2D>("block");

            blockTextureData = new Color[texture.Width * texture.Height];
            texture.GetData(blockTextureData);

            secondBlockTexData = new Color[secondTex.Width * secondTex.Height];
            secondTex.GetData(secondBlockTexData);
        }

        public void Update(GameTime gameTime)
        {
            //MouseState mouse = Mouse.GetState();
            //position = new Vector2(mouse.X, mouse.Y);

            //firstBoxPos.X = pos;
            //secondBoxPos.X = pos2;

            if(pos >= 65)
            {
                distance = 185;
            }
            if(pos2 >= 65)
            {
                distance2 = 185;
            }
            
            firstBoxRec = new Rectangle(225 - (pos * 3), 216, 50, 100);  //225 limit     40    185px
            secondBoxRec = new Rectangle(740 + (pos2 * 3), 214, 50, 100); //733 limit

        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, firstBoxRec, Color.White);
            spriteBatch.Draw(secondTex, secondBoxRec, Color.White);
        }
    }
}
