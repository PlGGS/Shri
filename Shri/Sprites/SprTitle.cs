﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shri.Sprites
{
    public class SprTitle : Sprite
    {
        public SprTitle(Texture2D texture, Vector2 position, Color tint, Vector2 origin, bool isPlayerControlled = false, int speed = 50, float momentum = 0f, int mvmtDirection = 0)
            : base(texture,position,tint,origin,isPlayerControlled, speed,  momentum, mvmtDirection)
        {
            // Mouse.SetPosition(Shri.Instance.Window.ClientBounds.Width / 2, Shri.Instance.Window.ClientBounds.Height / 2);
        }

        public override void Update(GameTime gameTime)
        {
            if (Shri.Instance.GameScreenManager.CurrentGameScreen is MainMenu)
            {
                if (Shri.Instance.InputManager.Pressed(Input.Start))
                {
                    Shri.Instance.GameScreenManager.Push(new Level0());
                }
            }
        }
    }
}
