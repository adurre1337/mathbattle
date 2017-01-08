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
    /// This is a game component that implements IUpdateable.
    /// </summary>
    public class KeyboardManager : Microsoft.Xna.Framework.GameComponent
    {
        KeyboardState lastKeyboardState;
        KeyboardState currentKeyboardState;

        string text;

        Keys[] keysToCheck = new Keys[] {
        Keys.NumPad0, Keys.NumPad1, Keys.NumPad2, Keys.NumPad3, Keys.NumPad4,
        Keys.NumPad5, Keys.NumPad6, Keys.NumPad7, Keys.NumPad8, Keys.NumPad9,
        Keys.Back, Keys.Space, Keys.Enter };

        bool enterPressed;

        public bool CheckKey(Keys theKey)
        {
            return lastKeyboardState.IsKeyDown(theKey) && currentKeyboardState.IsKeyUp(theKey);
        }
        private void AddKeyToText(Keys key)
        {

            string newChar = "";


            if (text.Length >= 20 && key != Keys.Back)

                return;

            switch (key)

            {

                case Keys.NumPad0:

                    newChar += "0";

                    break;

                case Keys.NumPad1:

                    newChar += "1";

                    break;

                case Keys.NumPad2:

                    newChar += "2";

                    break;

                case Keys.NumPad3:

                    newChar += "3";

                    break;

                case Keys.NumPad4:

                    newChar += "4";

                    break;

                case Keys.NumPad5:

                    newChar += "5";

                    break;

                case Keys.NumPad6:

                    newChar += "6";

                    break;

                case Keys.NumPad7:

                    newChar += "7";

                    break;

                case Keys.NumPad8:

                    newChar += "8";

                    break;

                case Keys.NumPad9:

                    newChar += "9";

                    break;

                case Keys.Subtract:

                    newChar += "-";

                    break;

                case Keys.Space:

                    newChar += " ";

                    break;

               /* case Keys.Enter:

                    enterPressed = true;

                    break;*/



                case Keys.Back:

                    if (text.Length != 0)

                        text = text.Remove(text.Length - 1);

                    return;

            }

            if (currentKeyboardState.IsKeyDown(Keys.RightShift) ||

                currentKeyboardState.IsKeyDown(Keys.LeftShift))

            {

                newChar = newChar.ToUpper();
            }

            text += newChar;

        }

        public KeyboardManager(Game game)
            : base(game)
        {
            
            text = "";
        }

        /// <summary>
        /// Allows the game component to perform any initialization it needs to before starting
        /// to run.  This is where it can query for any required services and load content.
        /// </summary>
        public override void Initialize()
        {
            // TODO: Add your initialization code here
            enterPressed = false;

            base.Initialize();
        }

        /// <summary>
        /// Allows the game component to update itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {
            currentKeyboardState = Keyboard.GetState();

            foreach (Keys key in keysToCheck)
            {
                if (CheckKey(key))
                {
                    AddKeyToText(key);
                    break;
                }
            }
           
            base.Update(gameTime);
            lastKeyboardState = currentKeyboardState;
        }

        public string Text
        {
            get { return text; }
            set { text = value; }
        }

        public bool EnterPressed
        {
            get
            { return enterPressed; }
            set { enterPressed = value; }
        }

        public bool EnterDown
        {
            get
            {
                return CheckKey(Keys.Enter);
            }
        }
    }
}
