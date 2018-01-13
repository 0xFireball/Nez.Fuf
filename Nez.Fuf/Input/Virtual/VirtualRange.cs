using System.Collections.Generic;
using Microsoft.Xna.Framework.Input;

namespace Nez.Fuf {
    /// <summary>
    /// A virtual input represented as a float between -1 and 1
    /// </summary>
    public class VirtualRange : VirtualInput {
        private readonly int min;
        private readonly int max;
        private readonly bool adjustRange;

        public List<Node> nodes = new List<Node>();

        public int value {
            get {
                for (var i = 0; i < nodes.Count; i++) {
                    var val = nodes[i].value;
                    if (val != 0) {
                        if (adjustRange) {
                            if (val < min) val = min;
                            if (val > max) val = max;
                        }
                        return val;
                    }
                }

                return 0;
            }
        }


        public VirtualRange(int min, int max, bool adjustRange) {
            this.min = min;
            this.max = max;
            this.adjustRange = adjustRange;
        }


        public VirtualRange(params Node[] nodes) {
            this.nodes.AddRange(nodes);
        }


        public override void update() {
            for (var i = 0; i < nodes.Count; i++) nodes[i].update();
        }


        public static implicit operator int(VirtualRange range) {
            return range.value;
        }


        #region Node types

        public abstract class Node : VirtualInputNode {
            public abstract int value { get; }
        }


        public class KeyboardNumRow : Node {
            private static Keys[] numRowKeys =
                {Keys.D0, Keys.D1, Keys.D2, Keys.D3, Keys.D4, Keys.D5, Keys.D6, Keys.D7, Keys.D8, Keys.D9};

            private int lastValue;

            public KeyboardNumRow(int initialValue) {
                lastValue = initialValue;
            }

            public override void update() {
                base.update();

                for (var i = 0; i < numRowKeys.Length; i++) {
                    if (Nez.Input.currentKeyboardState.IsKeyDown(numRowKeys[i])) lastValue = i;
                }
            }

            public override int value => lastValue;
        }

        public class LogicRange : Node {
            public override int value => Value;

            public int Value { get; set; }

            public LogicRange(int initialValue) {
                Value = initialValue;
            }
        }

        #endregion
    }
}