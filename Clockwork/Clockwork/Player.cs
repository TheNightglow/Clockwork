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
        Texture2D winP;
        Texture2D deathP;
        Texture2D empt;

        Vector2 move;
        public Vector2[] platVarray;
        float gForce = 0.3f;

        public int scrollHeight(Decal decal)
        {
            int result = (int)decal.position.Y+MapsizeY;

            return result;
        }

        //Constructor
        public Player(Texture2D playerTexture, Vector2 playerPosition, Texture2D empt, Texture2D Dmsg, Texture2D Wmsg)
        {
            //Define CLass Member
            texture = playerTexture;
            position = playerPosition;
            move = Vector2.Zero;
            winP = Wmsg;
            deathP = Dmsg;
            this.empt = empt;
            Message = empt;
        }

        public void Kill(Decal decal, PlatformX plat, Enemys e)
        {
            position = start;
            decal.position = new Vector2(0, 0 - MapsizeY);
            plat.position = plat.spawn;
            e.position = e.spawn;
            Message = deathP;
        }

        public void Update(Decal decal, PlatformX[] platarray, Enemys enemy)
        {


            KeyboardState key = Keyboard.GetState();

            Vector2 scrollPos = new Vector2(position.X, position.Y - scrollHeight(decal));
            move.Y += gForce;
            move.X = 0;

            //Win
            if (blueprint.GetPixel((int)scrollPos.X, (int)scrollPos.Y + playerSizeY + MapsizeY).Equals(blueprint.GetPixel(3, 30))) // 3 30 is Green!
            {
                Kill(decal, platarray[0], enemy);
                platarray[1].position = platarray[1].spawn;
                Message = winP;
            }

            if ((position.Y + 58) > enemy.position.Y - 5 && (position.Y + 60) < enemy.position.Y + 5)
            {
                if (position.X + 25 >= enemy.position.X && position.X < enemy.position.X + playerSizeX - 25)
                {
                    Kill(decal, platarray[0], enemy);
                    platarray[1].position = platarray[1].spawn;
                }
            }

            if (key.IsKeyDown(Keys.A)|| key.IsKeyDown(Keys.Left))
            {
                if (CollisionX(scrollPos, -2, playerSizeX) == false)
                {
                    move.X -= 2;
                }

            }

            if (key.IsKeyDown(Keys.D)|| key.IsKeyDown(Keys.Right))
            {
                if (CollisionX(scrollPos, 2, playerSizeX) == false)
                    move.X += 2;
                Message = empt;
            }

            //Jump
            for (int i = 0; i < platarray.Length; i++)
            {
                PlatformX plat = platarray[i];
            }
            if ((key.IsKeyDown(Keys.Space)|| key.IsKeyDown(Keys.W)|| key.IsKeyDown(Keys.Up)) && !jump)
            {
                jump = true;
                move.Y = -8;
                position.Y -= 1;
            }
            if(position.Y >= (MapsizeY - playerSizeY))
            {
                for (int i = 0; i < platarray.Length; i++)
                {
                    PlatformX plat = platarray[i];
                    Kill(decal, plat, enemy);
                }

            }

            //Array of Platform Positions
            for (int i = 0; i < platarray.Length; i++)
            {
                platVarray = new Vector2[platarray.Length];
                platVarray[i] = platarray[i].position;
            }
            if ((CollisionY(scrollPos, 1, playerSizeY)
                || CollisionY(new Vector2(position.X + playerSizeX, scrollPos.Y), 1, playerSizeY) || IsElementOf(this.position, platVarray)) == false)
            {
                if (move.Y < 0)
                {
                    if (CollisionY(scrollPos, -1, playerSizeY) == false && IsElementOf(this.position, platVarray) ==false)
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
                while(CollisionY(new Vector2(position.X, position.Y - scrollHeight(decal)), 0, playerSizeY-1) && IsElementOf(this.position, platVarray))
                {
                    position.Y -=1;

                }
                for(int i =1; i<playerSizeY; i++)
                {
                    if (CollisionY(new Vector2(position.X, position.Y - scrollHeight(decal)), 0, i) && IsElementOf(this.position, platVarray))
                    {
                        position.Y -= playerSizeY + i;
                    }
                }

            }
            for (int i = 0; i < platarray.Length; i++)
            {
                PlatformX plat = platarray[i];
                if (IsElementOf(new Vector2(this.position.X, this.position.Y + 1), plat.position))
                {
                    int direction = plat.direction;
                    if (direction == 1)
                    {
                        position.X += 1;
                    }

                    if (direction == 0)
                    {
                        position.X -= 1;
                    }
                }
            }





        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Color.White);
        }
        public void DrawMessage(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Message, new Vector2(170, 300), Color.White);
        }
    }
}
