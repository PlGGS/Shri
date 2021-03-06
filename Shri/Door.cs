﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shri
{
    public class Door : Sprite
    {
        bool _open = false;
        public bool Open
        {
            get
            {
                return _open;
            }
            set
            {
                _open = value;
            }
        }

        public Door(bool open, Texture2D texture, Vector2 position, Color tint, Vector2 origin, bool isPlayerControlled = false, int speed = 50, float momentum = 0f, int mvmtDirection = 0)
            : base(texture, position, tint, origin, isPlayerControlled, speed, momentum, mvmtDirection)
        {
            _open = open;
        }
    }
}
