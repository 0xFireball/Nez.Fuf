using System;
using Nez.Sprites;

namespace Nez.Fuf.Sprites {
    public abstract class FufAnimatedSprite<TAnimation> : FufSprite, IUpdatable
        where TAnimation : struct, IComparable, IFormattable {
        protected Sprite<TAnimation> animation;

        public Sprite<TAnimation> Animation => animation;

        private bool _flipX;
        private bool _flipY;

        public override void loadGraphic(string graphicAsset, bool animated = false, int width = 0, int height = 0) {
            if (!animated)
                throw new ArgumentOutOfRangeException(nameof(animated),
                    "animated sprites must have `animated` set to true in loadGraphic()");
            base.loadGraphic(graphicAsset, animated, width, height);

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