namespace Nez.Fuf {
    public class VirtualAxis {
        public class LogicAxis : Nez.VirtualAxis.Node {
            public override float value => logicValue;

            public float logicValue { get; set; }
        }
    }
}