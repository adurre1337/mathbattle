using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MathBattle
{
    class InstructionScreen : GameScreen
    {
        SpriteFont spriteFont;
        MenuComponent menuComponent;
        float elapse;

        public int selectedIndex
        {
            get { return menuComponent.SelectedIndex; }
            set { menuComponent.SelectedIndex = value; }
        }

        


        public InstructionScreen(Game game, SpriteBatch spriteBatch, SpriteFont spriteFont, SpriteFont menuFont) : base(game, spriteBatch)
        {
            string[] menuItems = { "Got it!" };
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
            
            spriteBatch.DrawString(spriteFont, "Complete math problems using the KeyPad!", new Vector2(100, 100), Color.Black);
            
            base.Draw(gameTime);
        }
    }
}
