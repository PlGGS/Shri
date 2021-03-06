﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Shri.Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shri.Managers;

namespace Shri
{
    public abstract class Level : GameScreen
    {
        private readonly float initialPlayerScale = 0.2f;

        public Texture2D txrPlayerBlue;
        public Texture2D txrPlayerYellow;
        public Texture2D txrPlayerRed;
        public Texture2D txrFillBlue;
        public Texture2D txrFillYellow;
        public Texture2D txrFillRed;
        public Texture2D txrFilled;
        public Texture2D txrBlack;
        public Texture2D txrWhite;
        public Texture2D txrMediumFont;

        public Entity Player;
        protected List<SprWall> _walls = new List<SprWall>();
        public List<SprWall> Walls
        {
            get
            {
                return _walls;
            }
        }
        public SprWall sprWallLeft;
        public SprWall sprWallRight;
        public SprWall sprWallTop;
        public SprWall sprWallBottom;
        public SprEntrance sprEntrance;
        public SprExit sprExit;
        public FramedSprite sprMediumFont;

        public Font fntMediumFont;

        public override void LoadContent(ContentManager contentManager, GraphicsDevice graphicsDevice)
        {
            txrPlayerBlue = contentManager.GetTexture("Shri/Content/Images/budBlue.png", graphicsDevice);
            txrPlayerYellow = contentManager.GetTexture("Shri/Content/Images/budYellow.png", graphicsDevice);
            txrPlayerRed = contentManager.GetTexture("Shri/Content/Images/budRed.png", graphicsDevice);
            txrBlack = contentManager.GetTexture("Shri/Content/Images/black.png", graphicsDevice);
            txrWhite = contentManager.GetTexture("Shri/Content/Images/white.png", graphicsDevice);
            txrFillBlue = contentManager.GetTexture("Shri/Content/Images/fillBlue.png", graphicsDevice);
            txrFillYellow = contentManager.GetTexture("Shri/Content/Images/fillYellow.png", graphicsDevice);
            txrFillRed = contentManager.GetTexture("Shri/Content/Images/fillRed.png", graphicsDevice);
            txrFilled = contentManager.GetTexture("Shri/Content/Images/filled.png", graphicsDevice); //TODO change the way fill textures are loaded

            if (Shri.Instance.GameScreenManager.CurrentGameScreen is Level0)
            {
                Player = new Entity(
                    texture: txrPlayerBlue,
                    position: new Vector2((Shri.Instance.Window.ClientBounds.Width / 2), (Shri.Instance.Window.ClientBounds.Height / 2 + 160)),
                    circle: new Circle(new Vector2((Shri.Instance.Window.ClientBounds.Width / 2), (Shri.Instance.Window.ClientBounds.Height / 2 + 160 * initialPlayerScale)), (txrPlayerBlue.Width / 2) * initialPlayerScale),
                    tint: Color.White,
                    origin: new Vector2((txrPlayerBlue.Width) / 2, (txrPlayerBlue.Height) / 2),
                    color: Color.Blue, true, 250, 1.0f, 90,
                    scale: new Vector2(initialPlayerScale, initialPlayerScale)
                );

                Shri.Instance.ControlManager = new ControlManager(Player, false);
            }
            else
            {
                Player.Position = new Vector2((Shri.Instance.Window.ClientBounds.Width / 2), (Shri.Instance.Window.ClientBounds.Height / 2 + 160));
                Player.Speed = 250;
                Player.Momentum = 1.0f;
                Player.MvmtDirection = 90;
            }

            sprWallLeft = new SprWall(txrBlack, Vector2.Zero, Color.Black, Vector2.Zero)
            {
                Scale = new Vector2(1f, 48f)
            };
            sprWallRight = new SprWall(txrBlack, new Vector2(Shri.Instance.Window.ClientBounds.Width - txrBlack.Width, 0), Color.Black, Vector2.Zero)
            {
                Scale = new Vector2(1f, 48f)
            };
            sprWallTop = new SprWall(txrBlack, Vector2.Zero, Color.Black, Vector2.Zero)
            {
                Scale = new Vector2(80f, 1f)
            };
            sprWallBottom = new SprWall(txrBlack, new Vector2(0, Shri.Instance.Window.ClientBounds.Height - txrBlack.Height), Color.Black, Vector2.Zero)
            {
                Scale = new Vector2(80f, 1f)
            };

            sprExit = new SprExit(false, txrWhite, new Vector2(Shri.Instance.Window.ClientBounds.Width / 2, 0), Color.White, new Vector2(txrWhite.Width / 2, 0))
            {
                Scale = new Vector2(20f, 1.5f)
            };
            sprEntrance = new SprEntrance(true, txrWhite, new Vector2(Shri.Instance.Window.ClientBounds.Width / 2, Shri.Instance.Window.ClientBounds.Height - txrWhite.Height), Color.White, new Vector2(txrWhite.Width / 2, 0))
            {
                Scale = new Vector2(20f, 1f)
            };

            _walls.Add(sprWallLeft);
            _walls.Add(sprWallRight);
            _walls.Add(sprWallTop);
            _walls.Add(sprWallBottom);

            txrMediumFont = contentManager.GetTexture("Shri/Content/Fonts/medium-font.png", graphicsDevice);
            sprMediumFont = new FramedSprite(18, 4, 0, txrMediumFont, Vector2.Zero, Color.White, false);
            Dictionary<int, int> mapping = contentManager.GetFontMapping("Shri/Content/Fonts/medium-font.fontmapping");
            fntMediumFont = new Font(sprMediumFont, mapping, 1, 2, Color.Black);
        }

        public override void Update(GameTime gameTime)
        {
            Player.Update(gameTime); //TODO reminder to always call sprite updates
            sprEntrance.Update(gameTime);
            sprExit.Update(gameTime);
            foreach (Sprite wall in _walls)
            {
                wall.Update(gameTime);
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.PointWrap);

            foreach (SprWall wall in _walls)
            {
                wall.Draw(spriteBatch);
            }

            if (sprExit.Open)
            {
                sprExit.Draw(spriteBatch);
            }

            if (sprEntrance.Open)
            {
                sprEntrance.Draw(spriteBatch);
            }
        }
    }
}
