﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System;
using Shri.Managers;

namespace Shri
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Shri : Game
    {
        private static Shri _instance;
        public static Shri Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Shri();
                }
                return _instance;
            }
        }

        GraphicsDeviceManager _graphics;
        SpriteBatch spriteBatch;

        GameScreenManager _gameScreenManager;
        public GameScreenManager GameScreenManager
        {
            get
            {
                return _gameScreenManager;
            }
        }

        InputManager _inputManager;
        public InputManager InputManager
        {
            get
            {
                return _inputManager;
            }
        }

        ControlManager _controlManager;
        public ControlManager ControlManager
        {
            get
            {
                return _controlManager;
            }
            set
            {
                _controlManager = value;
            }
        }

        ContentManager _contentManager;
        public ContentManager ContentManager
        {
            get
            {
                return _contentManager;
            }
        }

        SoundManager _soundManager;
        public SoundManager SoundManager
        {
            get
            {
                return _soundManager;
            }
        }

        public Shri()
        {
            _graphics = new GraphicsDeviceManager(this);
            IsMouseVisible = true;
            _gameScreenManager = new GameScreenManager();
            _inputManager = new InputManager();
            _contentManager = new ContentManager();
            _soundManager = new SoundManager(new List<SoundFX>
            {
                new SoundFX {Key = "Fill", FileName = "Shri/Content/Audio/fill.wav", DefaultPitch = 0.01f, DefaultVolume = 1},
                new SoundFX {Key = "NoFill", FileName = "Shri/Content/Audio/noFill.wav", DefaultPitch = 0.01f, DefaultVolume = 1},
                new SoundFX {Key = "Open", FileName = "Shri/Content/Audio/open.wav", DefaultPitch = 0.01f, DefaultVolume = 1},
                new SoundFX {Key = "Close", FileName = "Shri/Content/Audio/close.wav", DefaultPitch = 0.01f, DefaultVolume = 1},
                new SoundFX {Key = "Music", FileName = "Shri/Content/Audio/music.wav", DefaultPitch = 0.01f, DefaultVolume = 1},
                new SoundFX {Key = "TempWin", FileName = "Shri/Content/Audio/tempWin.wav", DefaultPitch = 0.01f, DefaultVolume = 1}
            }, 1);
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            base.Initialize();
            _gameScreenManager.Push(new MainMenu());
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            _contentManager.Prepare(GraphicsDevice);
            spriteBatch = new SpriteBatch(GraphicsDevice);
            _soundManager.LoadContent(ContentManager);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {

        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            _inputManager.Update(gameTime);
            if (_controlManager != null)
                _controlManager.Update(gameTime);
            _gameScreenManager.Update(gameTime, GraphicsDevice);
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White); //This makes sure we're not still rendering old screens when we shift to a new one

            _gameScreenManager.Draw(spriteBatch);

            base.Draw(gameTime);
        }
    }
}
