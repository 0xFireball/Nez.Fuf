using Microsoft.Xna.Framework;

namespace Nez.Fuf {
    public class VirtualJoystick {
        public class LogicJoystick : Nez.VirtualJoystick.Node {
            public override Vector2 value { get; }

            public Vector2 Value { get; set; }
        }

        public class MouseDirectionalJoystick : Nez.VirtualJoystick.Node {
            private Vector2 _mouseDirection;
            private Camera _camera;
            public override Vector2 value => _mouseDirection;

            public MouseDirectionalJoystick(Camera camera) {
                _camera = camera;
            }

            public override void update() {
                _mouseDirection = (Nez.Input.mousePosition - _camera.origin) * new Vector2(1, -1);
            }
        }
    }
}