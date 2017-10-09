using Microsoft.Xna.Framework;

namespace Nez.Fuf
{
    public class VirtualJoystick
    {
        public class LogicJoystick : Nez.VirtualJoystick.Node
        {
            public override Vector2 value { get; }

            public Vector2 Value { get; set; }
        }

        public class MouseDirectionalJoystick : Nez.VirtualJoystick.Node
        {
            private Vector2 _mouseDirection;
            public override Vector2 value => _mouseDirection;

            public override void update()
            {
                var mouseInputCenter = new Vector2(Nez.Core.graphicsManager.PreferredBackBufferWidth,
                                           Nez.Core.graphicsManager.PreferredBackBufferHeight) / 2;
                _mouseDirection = Nez.Input.mousePosition - mouseInputCenter;
            }
        }
    }
}