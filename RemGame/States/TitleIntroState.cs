﻿using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using XELibrary;

namespace RemGame
{
    public sealed class TitleIntroState : BaseGameState, ITitleIntroState
    {
        private Texture2D texture;

        ISoundManager soundManager;

        public TitleIntroState(Game game)
            : base(game)
        {
            if (game.Services.GetService(typeof(ITitleIntroState))==null)
                game.Services.AddService(typeof(ITitleIntroState), this);

            soundManager = (ISoundManager)game.Services.GetService(typeof(ISoundManager));
        }

        protected override void LoadContent()
        {
          texture = Content.Load<Texture2D>(@"ScreenDisplay\titleIntro");
        }

        public override void Update(GameTime gameTime)
        {
            if (Input.KeyboardHandler.WasKeyPressed(Keys.Escape))
                Game.Exit();

            if (Input.KeyboardHandler.WasKeyPressed(Keys.Enter))
            {
                // Push our start menu into the stack.
                StateManager.PushState(OurGame.StartMenuState.Value);
            }

            base.Update(gameTime);
        }
        
        public override void Draw(GameTime gameTime)
        {
            Vector2 pos = new Vector2(Game.GraphicsDevice.Viewport.Width / 2,
                                      Game.GraphicsDevice.Viewport.Height / 2);
            Vector2 origin = new Vector2(texture.Width / 2,
                                         texture.Height / 2);
            Vector2 scale = new Vector2((float)Game.GraphicsDevice.Viewport.Width / texture.Width,
                                        (float)Game.GraphicsDevice.Viewport.Height / texture.Height);

           // OurGame.SpriteBatch.Draw(texture, pos, new Rectangle(0, 0, texture.Width, texture.Height), Color.White, 0.0f, origin, scale, SpriteEffects.None, 1.0f);

            base.Draw(gameTime);
        }
        
        protected override void StateChanged(object sender, EventArgs e)
        {
            base.StateChanged(sender, e);
            /*
            if (StateManager.State == this.Value)
                soundManager.Play("titleSound");
            else
                soundManager.StopSong();
                */
        }

    }
}
