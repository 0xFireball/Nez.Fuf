using System;
using Microsoft.Xna.Framework.Graphics;
using Nez.Sprites;

namespace Nez.Fuf.Sprites {
    public abstract class FufAnimatedSprite<TAnimation> : FufSprite, IUpdatable
        where TAnimation : struct, IComparable, IFormattable {
        public Sprite<TAnimation> animation { get; private set; }

        private bool _flipX;
        private bool _flipY;

        protected FufAnimatedSprite(Texture2D texture, bool animated = false, int width = 0, int height = 0) : base(
            texture, animated, width, height) {
            animation = entity.addComponent(new Sprite<TAnimation>(_subtextures[0]));
            sprite = animation;
        }

        public void setFacingFlip(bool flipX, bool flipY) {
            _flipX = flipX;
            _flipY = flipY;
        }

        public virtual void update() {
            animation.flipX = facing == Direction.Left && _flipX;
            animation.flipY = facing == Direction.Up && _flipY;
        }
    }
}