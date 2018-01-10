using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Nez.Sprites;
using Nez.Textures;

namespace Nez.Fuf.Sprites {
    public abstract class FufSprite : Component {
        protected readonly Texture2D texture;
        public Sprite sprite;

        public FufSprite(Texture2D texture) {
            this.texture = texture;

            sprite = new Sprite(this.texture);
            entity.addComponent(sprite);
        }
    }
}