﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Shri.Sprites;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shri.Managers;

namespace Shri
{
    public class Level0 : Level
    {
        public SprFill sprFill;
        
        public Level0()
        {
            
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        public override void LoadContent(ContentManager contentManager, GraphicsDevice graphicsDevice)
        {
            base.LoadContent(contentManager, graphicsDevice);

            sprFill = new SprFill(txrFillRed, new Vector2(Shri.Instance.Window.ClientBounds.Width / 2, Shri.Instance.Window.ClientBounds.Height / 2), new Circle(new Vector2(Shri.Instance.Window.ClientBounds.Width / 2, Shri.Instance.Window.ClientBounds.Height / 2), (txrPlayerBlue.Width / 2)), Color.White, new Vector2(txrFillBlue.Width / 2, txrFillBlue.Height / 2), Color.Red)
            {
                Scale = new Vector2(0.1f, 0.1f)
            };
            sprFill.Circle.Radius = sprFill.Circle.Radius * sprFill.Scale.X;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            sprFill.Update(gameTime);

            if (sprFill.Filled)
            {
                sprExit.Open = true;
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);

            fntMediumFont.DrawString(spriteBatch, "Colors", new Vector2(20, 20));

            if (sprFill.Filled == false)
            {
                sprFill.Texture = txrFillRed;
                sprFill.Draw(spriteBatch);
            }
            else
            {
                sprFill.Texture = txrFilled;
                sprFill.Draw(spriteBatch);
            }

            Player.Draw(spriteBatch);
            //spriteBatch.Draw(txrWhite, sprPlayer.Bounds, Color.Green); //TODO figure out what this is supposed to be
            
            spriteBatch.End();
        }
    }
}
