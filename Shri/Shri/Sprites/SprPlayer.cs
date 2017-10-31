﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shri.Sprites
{
    public class SprPlayer : Sprite
    {
        public SprPlayer(Texture2D texture, Vector2 position, Color tint, Vector2 origin, bool isPlayerControlled = false, int speed = 50, float momentum = 0f, int mvmtDirection = 0)
            : base(texture,position,tint,origin,isPlayerControlled, speed,  momentum, mvmtDirection)
        {

        }

        public virtual void Update()
        {
            //TODO move movement and player specific code here
        }
    }
}
