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
    public class Background
    {
        public Texture2D texture;
        public Vector2 position;

        public Background()
        {
            texture = null;
            position = new Vector2(0,0);
        }

        public void LoadContent(ContentManager Content)
        {
            texture = Content.Load<Texture2D>("car");
        }

        public void Update(GameTime gameTime)
        {
        
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Color.White);
        }
        
    }
}
