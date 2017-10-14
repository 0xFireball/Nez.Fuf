using System;

namespace Nez.Fuf.Sprites {
    public abstract class FufDeferredSprite<TAnimation> : FufAnimatedSprite<TAnimation>
        where TAnimation : struct, IComparable, IFormattable {
        protected string spriteAsset { get; }

        protected FufDeferredSprite(string spriteAsset) {
            this.spriteAsset = spriteAsset;
        }

        public override void initialize() {
            base.initialize();

            loadSprites();
        }

        protected abstract void loadSprites();
    }
}