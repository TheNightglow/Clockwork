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
        int fallspeed = 1;
        Texture2D texture;
        public Vector2 position;
        double modifier=0;
        int playerSizeX = 8;
        int playerSizeY = 8;
        Vector2 move;
        float gForce = 0.3f;

        //Constructor
        public Player(Texture2D playerTexture, Vector2 playerPosition)
        {
            //Define CLass Member
            texture = playerTexture;
            position = playerPosition;
            move = Vector2.Zero;
        }

        public void Update()
        {
            KeyboardState key = Keyboard.GetState();

            move.Y += gForce;
            move.X = 0;

            if (key.IsKeyDown(Keys.Left))
            {
                if(CollisionX(position,-2, playerSizeX) ==false)
                    move.X -= 2;
            }


            if (key.IsKeyDown(Keys.Right))
            {
                if (CollisionX(position, 2, playerSizeX) == false)
                    move.X += 2;
            }

            if (key.IsKeyDown(Keys.A))
            {
                if (CollisionX(position, -2, playerSizeX) == false)
                {
                    move.X -= 2;
                }

            }

            if (key.IsKeyDown(Keys.D))
            {
                if (CollisionX(position, 2, playerSizeX) == false)
                    move.X += 2;
            }

            //Jump
            if (key.IsKeyDown(Keys.Space)&& !jump)
            {
                jump = true;
                move.Y = -10;
                position.Y -= 1;
            }

            if (CollisionY(position, 1, playerSizeY) ==false && position.Y <= MapsizeY)
            {
                if (move.Y<0)
                {
                    if (CollisionY(position, -1, playerSizeY) == false)
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
                while(CollisionY(position, 0, playerSizeY))
                {
                    position.Y -=1;

                }
                for(int i =1; i<playerSizeY; i++)
                {
                    if (CollisionY(position, i, 0))
                    {
                        position.Y -= playerSizeY - 1 + i;
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
