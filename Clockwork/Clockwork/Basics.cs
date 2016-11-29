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
        public int MapsizeX = 400;
        public int MapsizeY = 800;
        Bitmap blueprint = new Bitmap(Clockwork.Properties.Resources.BP);
        public bool CollisionY(Vector2 location, int direct, int SizeY) //positiv direct for downwards movement, negative for upwards!
        {
            if (direct > 0)
            {
                 if (blueprint.GetPixel((int)location.X, (int)location.Y + direct + SizeY).Equals(blueprint.GetPixel(1, 1)))
                {
                    return true;
                }
            }
            else
            {
                if (blueprint.GetPixel((int)location.X, (int)location.Y + direct).Equals(blueprint.GetPixel(1, 1)))
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
                if (blueprint.GetPixel((int)location.X + direct+SizeX, (int)location.Y).Equals(blueprint.GetPixel(1, 1)))
                {
                    return true;
                }
            }
            else
            {
                if (blueprint.GetPixel((int)location.X + direct, (int)location.Y).Equals(blueprint.GetPixel(1, 1)))
                {
                    return true;
                }
            }
            return false;
        }

        /*
        // Vergleicht ob Spieler auf Platform fällt
        public bool IsElementOf(Vector2 pos, PlatformX platform)
        {
            for(int x = platform.location.X; x<= platform.location.X+platform.SizeX;x++)
            {
                for (int y = platform.location.Y; x <= platform.location.Y + platform.SizeY; x++)
                {
                    if(new Vector2(pos.X, pos.Y+1).Equals(new Vector2(x,y)))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        */
}
