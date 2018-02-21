using Microsoft.Xna.Framework;

namespace Nez.Fuf.UI {
    public class TextComposer {
        public string _text { get; }
        public IFont _font { get; }
        public float _scale { get; }

        private Entity _entity;
        private Text _textComponent;

        public Text TextComponent => _textComponent;

        public TextComposer(string text, IFont font, float scale) {
            _text = text;
            _font = font;
            _scale = scale;
        }

        public TextComposer attach(Scene scene, Vector2 position, Color color, string entityName = null) {
            _entity = scene.createEntity(entityName, position);
            _textComponent = _entity.addComponent(new Text(_font, _text, Vector2.Zero, color));
            _textComponent.transform.setLocalScale(_scale);

            return this;
        }

        public TextComposer updateOffsets(Vector2 offset) {
            _textComponent.localOffset = offset;

            return this;
        }
    }
}