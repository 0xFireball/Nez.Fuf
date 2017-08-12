using System;
using System.Collections.Generic;
using Nez.Sprites;
using Nez.Textures;

namespace Nez.Fuf.Sprites
{
    public class FufSimpleAnimatedSprite<TAnimation> : FufAnimatedSprite<TAnimation>, IUpdatable
        where TAnimation : struct, IComparable, IFormattable
    {
        private TAnimation _facingFlipKey;

        private bool _flipX;
        private bool _flipY;

        public void setFacingFlip(TAnimation facingFlipKey, bool flipX, bool flipY)
        {
            _flipX = flipX;
            _flipY = flipY;

            updateAnimations();
        }

        private void updateAnimations()
        {
            Animation.addAnimation(_facingFlipKey, new SpriteAnimation(new List<Subtexture>()
                {
                    _subtextures[0]
                }
            ));
        }

        public void update()
        {
            animation.flipX = facing == Facing.Left && _flipX;
            animation.flipY = facing == Facing.Up && _flipY;
        }
    }
}