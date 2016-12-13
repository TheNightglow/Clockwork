using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Drawing;

namespace Clockwork
{
    public class Basics : Game
    {
        public int MapsizeX = 500;
        public int MapsizeY = 800;
        public Bitmap blueprint = new Bitmap(Clockwork.Properties.Resources.BPD2);
        public bool CollisionY(Vector2 location, int direct, int SizeY) //positiv direct for downwards movement, negative for upwards!
        {
            if (direct > 0)
            {
                if (blueprint.GetPixel((int)location.X, (int)location.Y + direct + SizeY +MapsizeY).Equals(blueprint.GetPixel(1, 1)))
                {
                    return true;
                }
            }
            else
            {
                if (blueprint.GetPixel((int)location.X, (int)location.Y + direct + MapsizeY).Equals(blueprint.GetPixel(1, 1)))
                {
                    return true;
                }
            }
            return false;
        }

        public bool CollisionX(Vector2 location, int direct, int SizeX) //positiv direct for right movement, negative for left!
        {
            if (direct >= 0)
            {
                if (blueprint.GetPixel((int)location.X + direct + SizeX, (int)location.Y + MapsizeY).Equals(blueprint.GetPixel(1, 1)))
                {
                    return true;
                }
            }
            else
            {
                if (blueprint.GetPixel((int)location.X + direct, (int)location.Y + MapsizeY).Equals(blueprint.GetPixel(1, 1)))
                {
                    return true;
                }
            }
            return false;
        }

        
        // Vergleicht ob Spieler auf Platform fällt
        public bool IsElementOf(Vector2 player, Vector2 plat)
        {
            if((player.Y+58)>plat.Y-5 && (player.Y+60) < plat.Y + 5)
            {
                if (player.X+25 >= plat.X && player.X < plat.X + 106 - 25)
                {
                    return true;
                }
            }
            //if(pos.Y>348 && pos.Y<352) return true;
            return false;
        }

        public bool IsElementOf(Vector2 player, Vector2[] platarray)
        {
  //          int i = 0;
  //          int count = 0;
            for (int i = 0; i < platarray.Length; i++)
 //           do
            {
   //             if (count == 1) break;
   //             i++;
                Vector2 plat = platarray[i];
                if ((player.Y + 58) > plat.Y - 5 && (player.Y + 60) < plat.Y + 5)
                {
                    if (player.X + 25 >= plat.X && player.X < plat.X + 106 - 25)
                    {
     //                   count = 1;
                        return true;
                    }
                }
            }
  //          while (i < platarray.Length-1);
  //          if (count ==0)
            return false;
    //        return true;

        }

    }
}
