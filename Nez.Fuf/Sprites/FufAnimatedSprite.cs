using System;
using Nez.Sprites;

namespace Nez.Fuf.Sprites
{
    public class FufAnimatedSprite<TAnimation> : FufSprite where TAnimation : struct, IComparable, IFormattable
    {
        protected Sprite<TAnimation> animation;

        public override void loadGraphic(string graphicAsset, bool animated = false, int width = 0, int height = 0)
        {
            if (!animated) throw new ArgumentOutOfRangeException(nameof(animated), "animated sprites must have `animated` set to true in loadGraphic()");
            base.loadGraphic(graphicAsset, animated, width, height);

            animation = entity.addComponent(new Sprite<TAnimation>(_subtextures[0]));
        }
    }
}