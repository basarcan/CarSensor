using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Storage;
using System.IO.Ports;
using System.Diagnostics;

namespace carSensor
{

    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public bool bipGreenBool;
        public bool bipOrangeBool;
        public bool bipRedBool;

        public int greenDelay;
        public int orangeDelay;
        public int redDelay;

        public SerialPort sPort;
        private Stopwatch stopwatch;


        frontSensor sensorFront = new frontSensor();
        backSensor sensorBack = new backSensor();
        Background bg = new Background();
        Blocks blocks = new Blocks();
        SoundManager sm = new SoundManager();

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            bipGreenBool = false;
            bipOrangeBool = false;
            bipRedBool = false;
            greenDelay = 20;
            orangeDelay = 10;
            redDelay = 5;

            //sPort = new SerialPort("COM5", 9600);

            //sPort.DataReceived += new SerialDataReceivedEventHandler(sPort_DataReceived);
            //sPort.Open();

            //Defined these cuz we need spesific space to fill whole area
            graphics.IsFullScreen = false;
            graphics.PreferredBackBufferWidth = 1000;
            graphics.PreferredBackBufferHeight = 500;
            this.Window.Title = "Car Sensor";
        }

  
        protected override void Initialize()
        {
            if (SerialPort.GetPortNames().Any(i => i == "COM5"))
            {
                sPort = new SerialPort("COM5", 9600);
                sPort.DataReceived += new SerialDataReceivedEventHandler(sPort_DataReceived);
                sPort.Open();

                stopwatch = new Stopwatch();
            }
            else throw new Exception("Could not initialize gyro sensor. COM3 not found");

            base.Initialize();
        }

        void sPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            var line = sPort.ReadLine();

            stopwatch.Stop();
            float elapsedSeconds = (float)stopwatch.ElapsedMilliseconds / 1000;
            stopwatch.Reset();
            stopwatch.Start();
            var tokens = line.Split(',');

            if (tokens.Length > 1)
            {
                blocks.pos = Convert.ToInt32(tokens[0]);
                blocks.pos2 = Convert.ToInt32(tokens[1]);
            }

        }


        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            bg.LoadContent(Content);
            sensorFront.LoadContent(Content);
            sensorBack.LoadContent(Content);
            blocks.LoadContent(Content);
            sm.LoadContent(Content);
        }


        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }


        protected override void Update(GameTime gameTime)
        {
            
            KeyboardState keyboard = Keyboard.GetState();
            GamePadState gamePad = GamePad.GetState(PlayerIndex.One);

            // Allows the game to exit
            if (gamePad.Buttons.Back == ButtonState.Pressed ||
                keyboard.IsKeyDown(Keys.Escape))
            {
                this.Exit();
            }


            bg.Update(gameTime); 
            sensorFront.Update(gameTime);
            blocks.Update(gameTime);

            if (IntersectPixels(sensorFront.firstWaveRec, sensorFront.firstWaveTextureData,
                                  blocks.firstBoxRec, blocks.blockTextureData))
            {
                sensorFront.collisionFirst = true;
                bipGreenBool = true;
            }
            //if (IntersectPixels(sensorFront.firstWaveRec, sensorFront.firstWaveTextureData,
            //                        blocks.secondBoxRec, blocks.secondBlockTexData))
            //{
            //    sensorFront.collisionFirst = true;
            //    bipGreenBool = true;
            //}
            else
            {
                sensorFront.collisionFirst = false;
            }
            if (IntersectPixels(sensorFront.secondWaveRec, sensorFront.secondWaveTextureData,
                                    blocks.firstBoxRec, blocks.blockTextureData))
            {
                sensorFront.collisionSecond = true;
                bipGreenBool = false;
                bipOrangeBool = true;
            }
            else 
            {
                sensorFront.collisionSecond = false;
            }
            if (IntersectPixels(sensorFront.thirthWaveRec, sensorFront.thirthWaveTextureData,
                                     blocks.firstBoxRec, blocks.blockTextureData))
            {
                sensorFront.collisionThirth = true;
                bipOrangeBool = false;
                bipRedBool = true;
            }
            else
            {
                sensorFront.collisionThirth = false;
            }


            if (IntersectPixels(sensorBack.firstBackWaveRec, sensorBack.firstBackWaveTextureData,
                               blocks.secondBoxRec, blocks.secondBlockTexData))
            {
                sensorBack.collisionBackFirst = true;
                bipGreenBool = true;
            }
            else
            {
                sensorBack.collisionBackFirst = false; 
            }
            if (IntersectPixels(sensorBack.secondBackWaveRec, sensorBack.secondBackWaveTextureData,
                               blocks.secondBoxRec, blocks.secondBlockTexData))
            {
                sensorBack.collisionBackSecond = true;
                bipGreenBool = false;
                bipOrangeBool = true;
            }
            else 
            {
                sensorBack.collisionBackSecond = false;
            }
            if (IntersectPixels(sensorBack.thirthBackWaveRec, sensorBack.thirthBackWaveTextureData,
                               blocks.secondBoxRec, blocks.secondBlockTexData))
            {
                sensorBack.collisionBackThirth = true;
                bipOrangeBool = false;
                bipRedBool = true;
            }
            else
            {
                sensorBack.collisionBackThirth = false;
            }

            if (bipGreenBool)
            {
                greenDelay--;
                if (greenDelay <= 0)
                {
                    sm.waveBip.Play();
                }
                if(greenDelay == 0)
                {
                    greenDelay = 20;
                    bipGreenBool = false;
                }

            }

            if (bipOrangeBool)
            {
                orangeDelay--;
                if (orangeDelay <= 0)
                {
                    sm.waveBip.Play();
                }
                if (orangeDelay == 0)
                {
                    orangeDelay = 10;
                    bipOrangeBool = false;
                }

            }
            if (bipRedBool)
            {
                redDelay--;
                if (redDelay <= 0)
                {
                    sm.waveBip.Play();
                }
                if (redDelay == 0)
                {
                    redDelay = 5;
                    bipRedBool = false;
                }
            }
           

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            //GraphicsDevice.Clear(Color.CornflowerBlue);
            GraphicsDevice device = graphics.GraphicsDevice;

            if (sensorFront.collisionFirst)
            {
                sensorFront.firstColor = Color.Green;
            }
            else { sensorFront.firstColor = Color.White; }
            if (sensorFront.collisionSecond)
            {
                sensorFront.secondColor = Color.Orange;
            }
            else { sensorFront.secondColor = Color.White; }
            if (sensorFront.collisionThirth)
            {
                sensorFront.thirthColor = Color.Red;
            }
            else 
            {
                sensorFront.thirthColor = Color.White;
            }
            if (sensorBack.collisionBackFirst)
            {
                sensorBack.firstBackColor = Color.Green;
            }
            else { sensorBack.firstBackColor = Color.White; }
            if (sensorBack.collisionBackSecond)
            {
                sensorBack.secondBackColor = Color.Orange;
            }
            else { sensorBack.secondBackColor = Color.White; }
            if (sensorBack.collisionBackThirth)
            {
                sensorBack.thirthBackColor = Color.Red;
                //sm.waveBip.Play();
            }
            else { sensorBack.thirthBackColor = Color.White; }

            spriteBatch.Begin();

            bg.Draw(spriteBatch);
            sensorFront.Draw(spriteBatch);
            sensorBack.Draw(spriteBatch);
            blocks.Draw(spriteBatch);
            
            spriteBatch.End();

            base.Draw(gameTime);
        }
        static bool IntersectPixels(Rectangle rectangleA, Color[] dataA,
                                   Rectangle rectangleB, Color[] dataB)
        {
            // Find the bounds of the rectangle intersection
            int top = Math.Max(rectangleA.Top, rectangleB.Top);
            int bottom = Math.Min(rectangleA.Bottom, rectangleB.Bottom);
            int left = Math.Max(rectangleA.Left, rectangleB.Left);
            int right = Math.Min(rectangleA.Right, rectangleB.Right);

            // Check every point within the intersection bounds
            for (int y = top; y < bottom; y++)
            {
                for (int x = left; x < right; x++)
                {
                    // Get the color of both pixels at this point
                    Color colorA = dataA[(x - rectangleA.Left) +
                                         (y - rectangleA.Top) * rectangleA.Width];
                    Color colorB = dataB[(x - rectangleB.Left) +
                                         (y - rectangleB.Top) * rectangleB.Width];

                    // If both pixels are not completely transparent,
                    if (colorA.A != 0 && colorB.A != 0)
                    {
                        // then an intersection has been found
                        return true;
                    }
                }
            }

            // No intersection found
            return false;
        }
    }
}
