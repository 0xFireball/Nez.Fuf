using Microsoft.Xna.Framework.Graphics;
using Nez.Sprites;

namespace Nez.Fuf.Sprites {
    public abstract class FufSprite : Component {
        protected readonly Texture2D texture;
        public Sprite sprite;

        public FufSprite(Texture2D texture) {
            this.texture = texture;

            sprite = new Sprite(this.texture);
        }

        public override void onAddedToEntity() {
            base.onAddedToEntity();

            entity.addComponent(sprite);
        }
    }
}