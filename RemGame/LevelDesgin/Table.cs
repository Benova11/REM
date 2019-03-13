﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using FarseerPhysics.Dynamics;
using FarseerPhysics.Factories;
namespace RemGame
{
    class Table : Obstacle
    {
        public Table(World world, Texture2D texture, Vector2 size, SpriteFont font) : base(world, texture, size, font)
        {

        }
    }
}
