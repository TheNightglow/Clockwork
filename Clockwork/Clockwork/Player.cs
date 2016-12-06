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
    class Player : Game1
    {
        bool jump = false;
        Texture2D texture;
        public Vector2 position;
        public int playerSizeX = 60;
        public int playerSizeY = 70;
        Vector2 move;
        float gForce = 0.3f;

        public int scrollHeight(Decal decal)
        {
            int result = (int)decal.position.Y+MapsizeY;

            return result;
        }

        //Constructor
        public Player(Texture2D playerTexture, Vector2 playerPosition)
        {
            //Define CLass Member
            texture = playerTexture;
            position = playerPosition;
            move = Vector2.Zero;
        }

        public void Kill(Decal decal, PlatformX plat)
        {
            position = start;
            decal.position = new Vector2(0, 0 - MapsizeY);
            plat.position = plat.spawn;
        }

        public void Update(Decal decal, PlatformX plat)
        {
            KeyboardState key = Keyboard.GetState();

            Vector2 scrollPos = new Vector2(position.X, position.Y - scrollHeight(decal));
            move.Y += gForce;
            move.X = 0;

            if (key.IsKeyDown(Keys.Left))
            {
                if(CollisionX(scrollPos,-2, playerSizeX) ==false)
                    move.X -= 2;
            }


            if (key.IsKeyDown(Keys.Right))
            {
                if (CollisionX(scrollPos, 2, playerSizeX) == false)
                    move.X += 2;
            }

            if (key.IsKeyDown(Keys.A))
            {
                if (CollisionX(scrollPos, -2, playerSizeX) == false)
                {
                    move.X -= 2;
                }

            }

            if (key.IsKeyDown(Keys.D))
            {
                if (CollisionX(scrollPos, 2, playerSizeX) == false)
                    move.X += 2;
            }

            //Jump
            if (key.IsKeyDown(Keys.Space)&& !jump)
            {
                jump = true;
                move.Y = -8;
                position.Y -= 1;
            }
            if(position.Y >= (MapsizeY - playerSizeY))
            {
                Kill(decal, plat);
            }

            if ((CollisionY(scrollPos, 1, playerSizeY)
                || CollisionY(new Vector2(position.X + playerSizeX, scrollPos.Y), 1, playerSizeY) || IsElementOf(this.position, plat.position)) == false)
            {
                if (move.Y < 0)
                {
                    if (CollisionY(scrollPos, -1, playerSizeY) == false && || IsElementOf(this.position, plat.position)==false)
                    {
                        position.Y += move.Y;
                    }
                    else
                    {
                        move.Y = 1;
                    }

                }
                else
                    position.Y += move.Y;
            }
            else
            {
                jump = false;
                move.Y = 1;
            }
           
            position.X += move.X;

            //Location Correction
            if(!jump)
            {
                while(CollisionY(new Vector2(position.X, position.Y - scrollHeight(decal)), 0, playerSizeY-1) || IsElementOf(this.position, plat.position))
                {
                    position.Y -=1;

                }
                for(int i =1; i<playerSizeY; i++)
                {
                    if (CollisionY(new Vector2(position.X, position.Y - scrollHeight(decal)), 0, i) || IsElementOf(this.position, plat.position))
                    {
                        position.Y -= playerSizeY + i;
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
