using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MathBattle
{
    class LoseScreen : GameScreen
    {
        SpriteFont spriteFont;
        MenuComponent menuComponent;

        public int selectedIndex
        {
            get { return menuComponent.SelectedIndex; }
            set { menuComponent.SelectedIndex = value; }
        }


        public LoseScreen(Game game, SpriteBatch spriteBatch, SpriteFont spriteFont, SpriteFont menuFont) : base(game, spriteBatch)
        {
            string[] menuItems = { "Return to Main Menu", "End Game" };
            menuComponent = new MenuComponent(game, spriteBatch, menuFont, menuItems);
            Components.Add(menuComponent);
            this.spriteFont = spriteFont;
        }



        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

        }

        public override void Draw(GameTime gameTime)
        {

            spriteBatch.DrawString(spriteFont, "You Lost!", new Vector2(300, 100), Color.Black);

            base.Draw(gameTime);
        }
    }
}

