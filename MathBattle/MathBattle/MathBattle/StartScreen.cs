using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MathBattle
{
    class StartScreen : GameScreen
    {
        SpriteFont spriteFont;
        MenuComponent menuComponent;

        public StartScreen(Game game, SpriteBatch spriteBatch, SpriteFont menuFont, SpriteFont spriteFont) : base(game, spriteBatch)
        {
            string[] menuItems = { "Subtraction","Addition","Multiplication","Division", "End Game" };
            menuComponent = new MenuComponent(game, spriteBatch, menuFont, menuItems);
            Components.Add(menuComponent);
            this.spriteFont = spriteFont;
        }

        public int selectedIndex
        {
            get { return menuComponent.SelectedIndex; }
            set { menuComponent.SelectedIndex = value; }
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

        }

        public override void Draw(GameTime gameTime)
        {

            spriteBatch.DrawString(spriteFont, "Math Battle!", new Vector2(175, 75), Color.Black);

            base.Draw(gameTime);
        }
    }
}
