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
    class Enemys : Game1
    {
        Texture2D texture;
        public Vector2 position;
        public Vector2 spawn;
        public int SizeX = 60;
        public int SizeY = 70;
        public int direction = 0;

        //Constructor
        public Enemys(Texture2D enemysTexture, Vector2 enemysPosition, int SizeX, int SizeY)
        {
            //Define CLass Member
            texture = enemysTexture;
            position = enemysPosition;
            spawn = enemysPosition;
            this.SizeX = SizeX;
            this.SizeY = SizeY;
        }

        public int scrollHeight(Decal decal)
        {
            int result = (int)decal.position.Y + MapsizeY;

            return result;
        }

        public void Update(PlatformX plat, Player player, Decal decal)
        {
            if (position.Y < MapsizeY - SizeX)
            {
                //Camera
                Vector2 scrollPos = new Vector2(position.X, position.Y - scrollHeight(decal));
                if (direction == 1 && CollisionX(scrollPos, 1, SizeX) == false)
                {
                    position.X += 1;
                }


                if (CollisionY(new Vector2(scrollPos.X + SizeX, scrollPos.Y), 1, SizeY) == false)
                {
                    direction = 0;
                }

                if (direction == 0 && CollisionX(scrollPos, -1, SizeX) == false)
                {
                    position.X -= 1;
                }

                if (CollisionY(new Vector2(scrollPos.X, scrollPos.Y), 1, SizeY) == false)
                {
                    direction = 1;
                }
                if (CollisionY(new Vector2(scrollPos.X, scrollPos.Y), 1, SizeY) == false && CollisionY(new Vector2(scrollPos.X + SizeX, scrollPos.Y), 1, SizeY) == false)
                {
                    position.Y += 1;
                }



                //Camera

                if (player.position.Y < 400)
                {
                    //camera scroll

                    KeyboardState key = Keyboard.GetState();
                    if (key.IsKeyDown(Keys.Space))
                    {
                        float diff = 400 - player.position.Y;
                        position.Y += 1.95f * diff;
                    }
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Color.White);
        }
    }
}
