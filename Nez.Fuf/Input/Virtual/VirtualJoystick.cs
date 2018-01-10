using Microsoft.Xna.Framework;

namespace Nez.Fuf.Input {
    public class VirtualJoystick {
        public class LogicJoystick : Nez.VirtualJoystick.Node {
            public override Vector2 value => logicValue;

            public Vector2 logicValue { get; set; }
        }

        public class MouseDirectionalJoystick : Nez.VirtualJoystick.Node {
            private Vector2 _mouseDirection;
            private Nez.Camera _camera;
            public override Vector2 value => _mouseDirection;

            public MouseDirectionalJoystick(Nez.Camera camera) {
                _camera = camera;
            }

            public override void update() {
                _mouseDirection = (Nez.Input.mousePosition - _camera.origin);
            }
        }
    }
}