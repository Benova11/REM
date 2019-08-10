using FarseerPhysics.Dynamics;
using FarseerPhysics.Dynamics.Contacts;
using FarseerPhysics.Factories;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemGame
{
    class HealthBooster
    {
        private World world;
        private Body body;
        private int value;
        private bool activated;
        private Kid player;
        private Texture2D texture;
        private Rectangle collisionRec;
        private Vector2 startingLocation;
        private float floatingDirection;


        public HealthBooster (World world,ContentManager Content,Kid player,int value,Vector2 position,Vector2 size)
        {
            this.Value = value;
            this.player = player;
            this.world = world;
            Activated = false;
            texture = Content.Load<Texture2D>("misc/HealthBooster");
            body = BodyFactory.CreateRectangle(world, size.X * CoordinateHelper.pixelToUnit, size.Y * CoordinateHelper.pixelToUnit, 1);
            body.BodyType = BodyType.Dynamic;
            body.IgnoreGravity = true;
            body.CollisionCategories = Category.Cat5;
            collisionRec = new Rectangle((int)position.X, (int)position.Y,(int)size.X,(int)size.X);
            startingLocation = position;
            floatingDirection = -1;
        }

        public int Value { get => value; set => this.value = value; }
        public bool Activated { get => activated; set => activated = value; }
        public Vector2 Position { get => body.Position * CoordinateHelper.unitToPixel; set => body.Position = value * CoordinateHelper.pixelToUnit; }

        public void Update(GameTime gameTime)
        {
            if (collisionRec.Intersects(player.CollisionRec))
            {
                if (!activated)
                {
                    player.Health += value;
                    player.HealthBar.increase(value);
                    activated = true;
                }
            }

            if (activated)
            {
                body.ApplyForce(new Vector2(-2, -5));
                body.Rotation += 0.05f;
            }

            else
            {
                body.ApplyForce(new Vector2(0, floatingDirection));

                if (Position.Y <= startingLocation.Y - 25)
                    floatingDirection = 1;

                else if (Position.Y + 25 >= startingLocation.Y)
                    floatingDirection = -1;
            }

            if (this.Position.Y < -300)
            {
                this.body.Enabled = false;
            }
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {

            Rectangle destination = new Rectangle
           (
               (int)Position.X,
               (int)Position.Y,
               55,
               55
           );

            if (body.Enabled)
            {
                spriteBatch.Draw(texture, destination, null, Color.White, body.Rotation, new Vector2(texture.Width, texture.Height), SpriteEffects.None, 0);
            }
        }

    }
}
