using Microsoft.Xna.Framework;

namespace Nez.Fuf {
    public class MouseFollow : Component, IUpdatable {
        private Vector2 offset;

        public MouseFollow() : this(Vector2.Zero) { }

        public MouseFollow(Vector2 offset) {
            this.offset = offset;
        }

        public void update() {
            // update entity position to mouse position
            entity.position = Input.mousePosition + offset;
        }
    }
}