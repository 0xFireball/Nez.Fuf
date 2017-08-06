namespace Nez.Fuf
{
    public class VirtualButton
    {
        public class LogicButton : Nez.VirtualButton.Node
        {
            public override bool isDown => false;
            public override bool isPressed => Pressed;
            public override bool isReleased => !Pressed;
            
            public bool Pressed { get; set; }
        }
    }
}