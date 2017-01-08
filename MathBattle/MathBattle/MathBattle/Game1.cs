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

namespace MathBattle
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        SpriteFont health;
        KeyboardManager keyBoard;

        KeyboardState currentKeyboardState;
        KeyboardState lastKeyboardState;

        Character player;
        Character enemy;

        GameScreen activeScreen;
        WinScreen winScreen;
        ActionScreen actionScreen;
        StartScreen startScreen;
        LoseScreen loseScreen;
        InstructionScreen instructionScreen;
        private float elapse;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            player = new Character(this, spriteBatch, Content.Load<Texture2D>("dude"));
            enemy = new Character(this, spriteBatch, Content.Load<Texture2D>("megamansprite"));
            health = Content.Load<SpriteFont>("Health");
            keyBoard = new KeyboardManager(this);

            base.Initialize();
        }

        public bool CheckKey(Keys theKey)
        {
            return lastKeyboardState.IsKeyDown(theKey) && currentKeyboardState.IsKeyUp(theKey);
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            startScreen = new StartScreen(this, spriteBatch, health, Content.Load<SpriteFont>("winFont"));
            Components.Add(startScreen);
            startScreen.Hide();

            actionScreen = new ActionScreen(this, spriteBatch, Content.Load<Texture2D>("dude"), Content.Load<Texture2D>("megamansprite"), Content.Load<SpriteFont>("Health"));
            Components.Add(actionScreen);
            actionScreen.Hide();

            winScreen = new WinScreen(this,spriteBatch,Content.Load<SpriteFont>("winFont"), health);
            Components.Add(winScreen);
            winScreen.Hide();

            loseScreen = new LoseScreen(this, spriteBatch, Content.Load<SpriteFont>("winFont"), health);
            Components.Add(loseScreen);
            loseScreen.Hide();

            instructionScreen = new InstructionScreen(this, spriteBatch, Content.Load<SpriteFont>("instructionFont"), health);
            Components.Add(instructionScreen);
            instructionScreen.Hide();

            activeScreen = startScreen;
            activeScreen.Show();
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            currentKeyboardState = Keyboard.GetState();

            if (actionScreen.Win())
            {
                activeScreen.Hide();
                activeScreen = winScreen;
                winScreen.Show();
            }

            if (actionScreen.Loss())
            {
                activeScreen.Hide();
                activeScreen = loseScreen;
                loseScreen.Show();
            }

            if (Keyboard.GetState().IsKeyDown(Keys.F))
            {
                activeScreen.Hide();
                activeScreen = loseScreen;
                loseScreen.Show();
            }           

            if (activeScreen == startScreen)
            {
                if (CheckKey(Keys.Enter))
                {
                    if (startScreen.selectedIndex == 0)
                    {
                        activeScreen.Hide();
                        activeScreen = instructionScreen;
                        instructionScreen.Show();                       
                    }
                    if (startScreen.selectedIndex == 4)
                    {
                        Exit();
                    }
                }
             }

            if (activeScreen == instructionScreen)
            {
                elapse += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
                if (elapse >= 1000f)
                {
                    if (CheckKey(Keys.Enter))
                    {
                        if (instructionScreen.selectedIndex == 0)
                        {
                            activeScreen.Hide();
                            activeScreen = actionScreen;
                            actionScreen.Show();
                        }
                    }
                }
            }

            if (activeScreen == winScreen)
            {                
                if (CheckKey(Keys.Enter))
                {
                    if (winScreen.selectedIndex == 0)
                    {
                        
                        activeScreen.Hide();
                        activeScreen = startScreen;
                        startScreen.Show();
                    }
                    if (winScreen.selectedIndex == 1)
                    {
                        Exit();
                    }
                }
            }

            if (activeScreen == loseScreen)
            {
                
                if (CheckKey(Keys.Enter))
                {
                    if (loseScreen.selectedIndex == 0)
                    {
                        activeScreen.Hide();
                        activeScreen = startScreen;
                        startScreen.Show();
                    }
                    if (loseScreen.selectedIndex == 1)
                    {
                        Exit();
                    }
                }
            }


            lastKeyboardState = currentKeyboardState;


            base.Update(gameTime);
            
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);

            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, null, null, null);
            base.Draw(gameTime);
            spriteBatch.End();

        }
    }
}
