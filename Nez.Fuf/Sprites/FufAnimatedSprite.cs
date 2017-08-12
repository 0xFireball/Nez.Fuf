using System;
using Nez.Sprites;

namespace Nez.Fuf.Sprites
{
    public class FufAnimatedSprite<TAnimation> : FufSprite, IUpdatable where TAnimation : struct, IComparable, IFormattable
    {
        protected Sprite<TAnimation> animation;

        public Sprite<TAnimation> Animation => animation;

        private TAnimation _facingFlipKey;

        private bool _flipX;
        private bool _flipY;

        public override void loadGraphic(string graphicAsset, bool animated = false, int width = 0, int height = 0)
        {
            if (!animated)
                throw new ArgumentOutOfRangeException(nameof(animated),
                    "animated sprites must have `animated` set to true in loadGraphic()");
            base.loadGraphic(graphicAsset, animated, width, height);

            animation = entity.addComponent(new Sprite<TAnimation>(_subtextures[0]));
        }

        public void setFacingFlip(TAnimation facingFlipKey, bool flipX, bool flipY)
        {
            _flipX = flipX;
            _flipY = flipY;
        }

        public virtual void update()
        {
            animation.flipX = facing == Facing.Left && _flipX;
            animation.flipY = facing == Facing.Up && _flipY;
        }
    }
}