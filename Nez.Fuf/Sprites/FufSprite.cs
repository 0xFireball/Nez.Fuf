﻿using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Nez.Sprites;
using Nez.Textures;

namespace Nez.Fuf.Sprites {
    public abstract class FufSprite : Component {
        protected Texture2D _texture;
        public Sprite sprite;
        protected List<Subtexture> _subtextures;

        public Direction facing { get; set; }

        public virtual void loadGraphic(string graphicAsset, bool animated = false, int width = 0, int height = 0) {
            _texture = FufCore.contentSource.Load<Texture2D>(graphicAsset);

            if (animated) {
                _subtextures = Subtexture.subtexturesFromAtlas(_texture, width, height);
            } else {
                sprite = new Sprite(_texture);
                entity.addComponent(sprite);
            }
        }
    }
}