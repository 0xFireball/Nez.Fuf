﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Nez.Sprites;

namespace Nez.Fuf.Components.Display {
    public class FufBackdrop : Component, IUpdatable {
        public readonly Texture2D texture;
        public ScrollingSprite scrollingSprite;

        public Vector2 scrollFactor = Vector2.One;
        public Vector2 textureScale = Vector2.One;

        public FufBackdrop(Texture2D texture) {
            this.texture = texture;
            setUpdateOrder(int.MaxValue);
        }

        public override void initialize() {
            base.initialize();

            scrollingSprite = entity.addComponent(new ScrollingSprite(texture) {
                textureScale = textureScale
            });
            entity.updateOrder = int.MaxValue;
        }

        public void update() {
            scrollingSprite.scrollX = (int) (entity.scene.camera.position.X * scrollFactor.X);
            scrollingSprite.scrollY = (int) (entity.scene.camera.position.Y * scrollFactor.Y);
            scrollingSprite.entity.position = entity.scene.camera.position;
        }
    }
}