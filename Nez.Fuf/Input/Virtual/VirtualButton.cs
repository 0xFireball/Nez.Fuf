namespace Nez.Fuf.Input {
    public class VirtualButton {
        public class LogicButton : Nez.VirtualButton.Node {
            public override bool isDown => logicPressed;
            public override bool isPressed => logicPressed;
            public override bool isReleased => !logicPressed;

            public bool logicPressed { get; set; }
        }
    }
}