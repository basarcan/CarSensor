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
using Microsoft.Xna.Framework.Storage;


namespace carSensor
{
    public class frontSensor
    {
        public Texture2D firstWaveTex,secondWaveTex, thirthWaveTex;
        public Vector2 firstWavePos, secondWavePos, thirthWavePos;

        public Color[] firstWaveTextureData;
        public Color[] secondWaveTextureData;
        public Color[] thirthWaveTextureData;

        public Color firstColor;
        public Color secondColor;
        public Color thirthColor;

        public Rectangle firstWaveRec, secondWaveRec, thirthWaveRec;
        public bool collisionFirst, collisionSecond, collisionThirth;

        public frontSensor()
        {
            firstColor = Color.White;
            secondColor = Color.White;
            thirthColor = Color.White;

            firstWaveTex = null;
            secondWaveTex = null;
            thirthWaveTex = null;

            firstWavePos = new Vector2(95, 114);//default position of first wave
            secondWavePos = new Vector2(171, 131);//default position of second wave
            thirthWavePos = new Vector2(235, 146);//default position of thirth wave

            firstWaveRec = new Rectangle((int)firstWavePos.X, (int)firstWavePos.Y, 108, 277);
            secondWaveRec = new Rectangle((int)secondWavePos.X, (int)secondWavePos.Y, 97, 241);
            thirthWaveRec = new Rectangle((int)thirthWavePos.X, (int)thirthWavePos.Y, 79, 212);

            collisionFirst = false;
            collisionSecond = false;
            collisionThirth = false;
        }

        public void LoadContent(ContentManager Content)
        {
            firstWaveTex = Content.Load<Texture2D>("wave1");
            secondWaveTex = Content.Load<Texture2D>("wave2");
            thirthWaveTex = Content.Load<Texture2D>("wave3");

            firstWaveTextureData = new Color[firstWaveTex.Width * firstWaveTex.Height];
            firstWaveTex.GetData(firstWaveTextureData);

            secondWaveTextureData = new Color[secondWaveTex.Width * secondWaveTex.Height];
            secondWaveTex.GetData(secondWaveTextureData);

            thirthWaveTextureData = new Color[thirthWaveTex.Width * thirthWaveTex.Height];
            thirthWaveTex.GetData(thirthWaveTextureData);
        }
        
        public void Update(GameTime gameTime)
        {}

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(firstWaveTex, firstWaveRec, firstColor);
            spriteBatch.Draw(secondWaveTex, secondWaveRec, secondColor);
            spriteBatch.Draw(thirthWaveTex, thirthWaveRec, thirthColor);
        }
    }
}
