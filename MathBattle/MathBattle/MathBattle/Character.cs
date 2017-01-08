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
    public class Character : Microsoft.Xna.Framework.GameComponent
    {
        int health;
        int attackDmg;
        Texture2D image;



        public Character(Game game, SpriteBatch spriteBatch, Texture2D image)
            : base(game)
        {
            // TODO: Construct any child components here

            this.image = image;
            health = 100;
        }

        public int Health
        {
            get { return health; }
            set { health = value; }

        }

        public int AttackDmg
        {
            get { return attackDmg; }            
        }

        public Texture2D Image
        {
            get { return image; }
        }

        

        /// <summary>
        /// Allows the game component to perform any initialization it needs to before starting
        /// to run.  This is where it can query for any required services and load content.
        /// </summary>
        public override void Initialize()
        {
            // TODO: Add your initialization code here
            
            base.Initialize();
        }

        

        /// <summary>
        /// Allows the game component to update itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {
            // TODO: Add your update code here

            base.Update(gameTime);
        }
    }
}
