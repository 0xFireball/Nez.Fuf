using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Nez.Sprites;
using Nez.Textures;

namespace Nez.Fuf.Sprites {
    public abstract class FufAnimatedSprite<TAnimation> : FufSprite, IUpdatable
        where TAnimation : struct, IComparable, IFormattable {
        
        protected readonly List<Subtexture> subtextures;
        
        public Sprite<TAnimation> animation { get; private set; }

        public Direction facing { get; set; }

        private bool _flipX;
        private bool _flipY;

        /// <summary>
        /// Create an animated sprite with the specified frame size
        /// </summary>
        /// <param name="texture"></param>
        /// <param name="width">The frame width</param>
        /// <param name="height">The frame height</param>
        protected FufAnimatedSprite(Texture2D texture, int width, int height) : base(
            texture) {
            animation = entity.addComponent(new Sprite<TAnimation>(subtextures[0]));
            sprite = animation;

            subtextures = Subtexture.subtexturesFromAtlas(base.texture, width, height);
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