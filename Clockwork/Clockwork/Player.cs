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
    class Player
    {
        Vector2 location;
        Texture2D texture;

        public Player(Texture2D tex, Vector2 pos)
        {
            texture = tex;
            location = pos;
        }

        public void Update()
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, location, Color.White);

        }
    }
}
