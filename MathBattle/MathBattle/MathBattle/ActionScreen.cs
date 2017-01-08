using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MathBattle
{
    class ActionScreen : GameScreen
    {
        Character player;
        Character enemy;
        SpriteFont health;
        KeyboardManager keyBoard;

        Rectangle playerLoc;
        Rectangle enemyLoc;

        bool isCorrect;
        Random rand1;
        bool enterPressed;

        int math1;
        int math2;
        int answer;

        string text;

        string right;
        string wrong;

        float elapse;
        KeyboardState currentKeyboardState;
        KeyboardState lastKeyboardState;

        public ActionScreen(Game game, SpriteBatch spriteBatch, Texture2D dude, Texture2D megaMan, SpriteFont health) : base(game, spriteBatch)
        {
            enterPressed = false;
            player = new Character(game, spriteBatch,megaMan);
            enemy = new Character(game, spriteBatch, dude);
            this.health = health;
            playerLoc = new Rectangle(100, 200, 200, 200);
            enemyLoc = new Rectangle(550, 50, 200, 200);

            elapse = 0;
            right = "Correct!";
            wrong = "Incorrect.";
            keyBoard = new KeyboardManager(game);
            text = keyBoard.Text;



            rand1 = new Random();

            math1 = rand1.Next(50, 100);
            math2 = rand1.Next(0, 49);
        }

        public bool CheckKey(Keys theKey)
        {
            return lastKeyboardState.IsKeyDown(theKey) && currentKeyboardState.IsKeyUp(theKey);
        }

        public bool EnterPressed()
        {
            if (CheckKey(Keys.Enter))
            {
                enterPressed = true;
                return enterPressed;
            }
            else
            {
                return enterPressed;
            }
        }


        private void ResetNumbers()
        {
            math1 = rand1.Next(50, 100);
            math2 = rand1.Next(0, 49);
        }

        private void ResetText()
        {
            keyBoard.Text = "";
        }

        private void ResetEnter()
        {
            keyBoard.EnterPressed = false;
        }

        public override void Update(GameTime gameTime)
        {
            currentKeyboardState = Keyboard.GetState();

            answer = math1 - math2;

            if (answer.ToString() == keyBoard.Text && EnterPressed())
            {
                isCorrect = true;
                elapse += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
                if (elapse >= 1000f)
                {
                    enterPressed = false;
                    enemy.Health -= 20;
                    ResetNumbers();
                    ResetText();
                    elapse = 0;
                    isCorrect = false;
                }
            }
            if (answer.ToString() != keyBoard.Text && EnterPressed())
            {
                isCorrect = false;
                elapse += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
                if (elapse >= 1000f)
                {
                    enterPressed = false;
                    player.Health -= 20;
                    ResetNumbers();
                    ResetText();
                    elapse = 0;
                    isCorrect = false;
                }
            }

            
            keyBoard.Update(gameTime);
            base.Update(gameTime);

            lastKeyboardState = currentKeyboardState;
        }

        public override void Draw(GameTime gameTime)
        {

            
            spriteBatch.DrawString(health, "Health:" + player.Health, new Vector2(150, 175), Color.Black);
            spriteBatch.DrawString(health, "Health:" + enemy.Health, new Vector2(600, 25), Color.Black);
            spriteBatch.DrawString(health, math1 + " - " + math2 + " = ", new Vector2(190, 25), Color.Black);
            spriteBatch.DrawString(health, keyBoard.Text, new Vector2(300, 25), Color.Black);
            if (isCorrect)
            {
                spriteBatch.DrawString(health, right, new Vector2(300, 50), Color.Black);
            }
            if (!isCorrect && EnterPressed())
            {
                spriteBatch.DrawString(health, wrong, new Vector2(300, 50), Color.Black);
            }
            spriteBatch.Draw(player.Image, playerLoc, Color.White);
            spriteBatch.Draw(enemy.Image, enemyLoc, Color.White);
            

            base.Draw(gameTime);
        }

        public bool Loss()
        {
            if (player.Health <= 0)
            {
                player.Health = 100;
                enemy.Health = 100;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Win()
        {
            if (enemy.Health <= 0)
            {
                enemy.Health = 100;
                player.Health = 100;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
