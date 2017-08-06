namespace Nez.Fuf
{
    public class VirtualAxis
    {
        public class LogicAxis : Nez.VirtualAxis.Node
        {
            public override float value => Value;

            public float Value { get; set; }
        }
    }
}