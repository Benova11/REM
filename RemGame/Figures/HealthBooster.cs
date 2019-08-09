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

        public HealthBooster (World world,ContentManager Content,Kid player,int value,Vector2 position,Vector2 size)
        {
            this.Value = value;
            this.player = player;
            this.world = world;
            Activated = false;
            texture = Content.Load<Texture2D>("misc/HealthBooster");
            body = BodyFactory.CreateRectangle(world, size.X * CoordinateHelper.pixelToUnit, size.Y * CoordinateHelper.pixelToUnit, 1);
            body.BodyType = BodyType.Static;
            body.CollisionCategories = Category.Cat5;
            body.CollidesWith = Category.Cat10 | Category.Cat11;
            //body.OnCollision += new OnCollisionEventHandler(Ron_OnCollision);
            collisionRec = new Rectangle((int)position.X, (int)position.Y,(int)size.X,(int)size.X);

        }

        public int Value { get => value; set => this.value = value; }
        public bool Activated { get => activated; set => activated = value; }
        public Vector2 Position { get => body.Position * CoordinateHelper.unitToPixel; set => body.Position = value * CoordinateHelper.pixelToUnit; }

        public void TakeOff()
        {
            body.BodyType = BodyType.Dynamic;
            body.ApplyForce(new Vector2(0,-4));
            body.Rotation = 0.2f;
            activated = true;
        }

        bool Ron_OnCollision(Fixture fixtureA, Fixture fixtureB, Contact contact)
        {
            Console.Write("ONCOLISIONNNNN");
            if (!activated && (fixtureB.CollisionCategories == Category.Cat10 || fixtureB.CollisionCategories == Category.Cat11))
            {
                TakeOff();
                player.Health += value;
                return true;
            }
               
            else
                return true;
        }

        public void Update(GameTime gameTime)
        {
            if (collisionRec.Intersects(player.CollisionRec))
            {
                Console.Write("ONCOLISIONNNNN");

                TakeOff();
                player.Health += value;
                player.HealthBar.increase(value);
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
               50,
               50
           );
            spriteBatch.Draw(texture, destination, null, Color.White, body.Rotation, new Vector2(texture.Width , texture.Height ), SpriteEffects.None, 0);

        }

    }
}
