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
    class Decal : Game1
    {
        bool jump = false;
        int fallspeed = 1;
        Texture2D texture;
        public Vector2 position;
        double modifier = 0;
        int playerSizeX = 60;
        int playerSizeY = 70;
        Vector2 move;
        float gForce = 0.3f;
        float diff=0;

        //Constructor
        public Decal(Texture2D tex, Vector2 pos)
        {
            //Define CLass Member
            texture = tex;
            position = pos;
            move = Vector2.Zero;
        }

        public void Update(Player play)
        {


            KeyboardState key = Keyboard.GetState();
            if (key.IsKeyDown(Keys.Space) && !jump)
            {
                jump = false;
                float diff = 400 - play.position.Y;
                position.Y += diff;
                play.position.Y += diff;

            }

            /*
            KeyboardState key = Keyboard.GetState();

            move.Y += gForce;
            move.X = 0;

            if (key.IsKeyDown(Keys.Left))
            {
                if (CollisionX(play.position, -2, playerSizeX) == false)
                    move.X -= 2;
            }


            if (key.IsKeyDown(Keys.Right))
            {
                if (CollisionX(play.position, 2, playerSizeX) == false)
                    move.X += 2;
            }

            if (key.IsKeyDown(Keys.A))
            {
                if (CollisionX(play.position, -2, playerSizeX) == false)
                {
                    move.X -= 2;
                }

            }

            if (key.IsKeyDown(Keys.D))
            {
                if (CollisionX(play.position, 2, playerSizeX) == false)
                    move.X += 2;
            }

            //Jump
            if (key.IsKeyDown(Keys.Space) && !jump)
            {
                jump = true;
                move.Y = -8;
                position.Y -= 1;
            }

            if ((CollisionY(play.position, 1, playerSizeY) || CollisionY(new Vector2(play.position.X + playerSizeX, play.position.Y), 1, playerSizeY)) == false && play.position.Y <= MapsizeY)
            {
                if (move.Y < 0)
                {
                    if (CollisionY(play.position, -1, playerSizeY) == false)
                    {
                        position.Y += move.Y;
                    }
                    else
                    {
                        move.Y = 1;
                    }

                }
                else
                    play.position.Y += move.Y;

            }
            else
            {
                jump = false;
                move.Y = 1;
            }
            play.position.X += move.X;

            //Location Correction
            if (!jump)
            {
                while (CollisionY(play.position, 0, playerSizeY - 1))
                {
                    position.Y -= 1;

                }
                for (int i = 1; i < playerSizeY; i++)
                {
                    if (CollisionY(play.position, 0, i))
                    {
                        position.Y -= playerSizeY + i;
                    }
                }


            }*/




        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Color.White);
        }
    }
}

