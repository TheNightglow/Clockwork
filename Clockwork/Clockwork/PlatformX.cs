using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Clockwork
{
    class PlatformX : Basics
    {
        /*
         *gebraucht wird:
         * Vector2 location
         * int SizeX, SizeY
         * int direction=1
         * eine Texture2
         * 
         * Konstruktor Vektor2 Texture2d
         * Update()
         * 
         * while(CollisionX(location, 1, SizeX)==false&&direction=1 )
         * location.X+1;
         * }
         * ifCollisionX(location, 1, SizeX) direction =0;
         * 
         * while(CollisionX(location, -1, SizeX)==false && direction =0;)
         * }
         * ifCollisionX(location, -1, SizeX) direction =1;
         * 
         */

        Texture2D texture;
        public Vector2 position;
        public int SizeX = 106;
        public int SizeY = 22;
        private int direction;
        public Vector2 spawn;

        //Constructor
        public PlatformX(Texture2D platformTexture, Vector2 platformPosition)
        {
            //Define CLass Member
            texture = platformTexture;
            position = platformPosition;
            spawn = platformPosition;
        }

        public int scrollHeight(Decal decal)
        {
            int result = (int)decal.position.Y + MapsizeY;

            return result;
        }


        public void Update(Decal decal, Player play)
        {
            Vector2 scrollPos = new Vector2(position.X, position.Y - scrollHeight(decal));
            //Camera Position relation to Object

            if (CollisionX(scrollPos, 1, SizeX) == false && direction == 1)
            {
                position.X += 1;
            }


            if (CollisionX(scrollPos, 1, SizeX))
            {
                direction = 0;
            }

            if (CollisionX(scrollPos, -1, SizeX) == false && direction == 0)
            {
                position.X -= 1; // hab ich hinzugefügt
            }

            if (CollisionX(scrollPos, -1, SizeX))
            {
                direction = 1;
            }

            
            if (play.position.Y < 400)
            {
                //camera scroll
                
                KeyboardState key = Keyboard.GetState();
                if (key.IsKeyDown(Keys.Space))
                {
                    float diff = 400 - play.position.Y;
                    position.Y += 1.95f*diff;
                }
            }


            }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Color.White);
        }
    }

}

