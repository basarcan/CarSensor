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
    public class backSensor
    {
        public Texture2D firstBackWaveTex, secondBackWaveTex, thirthBackWaveTex;
        public Vector2 firstBackWavePos, secondBackWavePos, thirthBackWavePos;

        public Color[] firstBackWaveTextureData;
        public Color[] secondBackWaveTextureData;
        public Color[] thirthBackWaveTextureData;

        public Color firstBackColor;
        public Color secondBackColor;
        public Color thirthBackColor;

        public Rectangle firstBackWaveRec, secondBackWaveRec, thirthBackWaveRec;
        public bool collisionBackFirst, collisionBackSecond, collisionBackThirth;

        public backSensor()
        {
            firstBackColor = Color.White;
            secondBackColor = Color.White;
            thirthBackColor = Color.White;

            firstBackWaveTex = null;
            secondBackWaveTex = null;
            thirthBackWaveTex = null;

            firstBackWavePos = new Vector2(805, 106);//default position of first wave
            secondBackWavePos = new Vector2(741, 124);//default position of second wave
            thirthBackWavePos = new Vector2(695, 138);//default position of thirth wave

            firstBackWaveRec = new Rectangle((int)firstBackWavePos.X, (int)firstBackWavePos.Y, 108, 277);
            secondBackWaveRec = new Rectangle((int)secondBackWavePos.X, (int)secondBackWavePos.Y, 97, 241);
            thirthBackWaveRec = new Rectangle((int)thirthBackWavePos.X, (int)thirthBackWavePos.Y, 79, 212);

            collisionBackFirst = false;
            collisionBackSecond = false;
            collisionBackThirth = false;
        }

        public void LoadContent(ContentManager Content)
        {
            firstBackWaveTex = Content.Load<Texture2D>("waveBack1");
            secondBackWaveTex = Content.Load<Texture2D>("waveBack2");
            thirthBackWaveTex = Content.Load<Texture2D>("waveBack3");

            firstBackWaveTextureData = new Color[firstBackWaveTex.Width * firstBackWaveTex.Height];
            firstBackWaveTex.GetData(firstBackWaveTextureData);

            secondBackWaveTextureData = new Color[secondBackWaveTex.Width * secondBackWaveTex.Height];
            secondBackWaveTex.GetData(secondBackWaveTextureData);

            thirthBackWaveTextureData = new Color[thirthBackWaveTex.Width * thirthBackWaveTex.Height];
            thirthBackWaveTex.GetData(thirthBackWaveTextureData);
        
        }

        public void Update(GameTime gameTime)
        { 
        
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(firstBackWaveTex, firstBackWaveRec, firstBackColor);
            spriteBatch.Draw(secondBackWaveTex, secondBackWaveRec, secondBackColor);
            spriteBatch.Draw(thirthBackWaveTex, thirthBackWaveRec, thirthBackColor);        
        }

    }
}
