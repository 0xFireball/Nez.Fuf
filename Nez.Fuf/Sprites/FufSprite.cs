using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Nez;
using Nez.Sprites;
using Nez.Textures;

namespace Nez.Fuf.Sprites
{
    public class FufSprite : Component
    {
        protected Texture2D _texture;
        protected List<Subtexture> _subtextures;

        public void loadGraphic(string graphicAsset, bool animated = false, int width = 0, int height = 0)
        {
            _texture = entity.scene.content.Load<Texture2D>(graphicAsset);

            if (animated)
            {
                _subtextures = Subtexture.subtexturesFromAtlas(_texture, width, height);
            }
            else
            {
                entity.addComponent(new Sprite(_texture));
            }
        }
    }
}