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
    public class SoundManager
    {
        public SoundEffect waveBip;

        public SoundManager()
        {
            waveBip = null;
        }

        public void LoadContent(ContentManager Content)
        {
            waveBip = Content.Load<SoundEffect>("bip");
        }
    }
}
