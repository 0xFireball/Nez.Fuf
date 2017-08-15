using Microsoft.Xna.Framework;

namespace Nez.Fuf.UI
{
    public class TextComposer
    {
        public NezSpriteFont Font { get; }
        public string Text { get; set; }

        private Entity _entity;
        private Text _textComponent;

        public Text TextComponent => _textComponent;

        public TextComposer(NezSpriteFont font)
        {
            Font = font;
        }

        public TextComposer attach(Scene scene, Vector2 position, Color color, string entityName = null)
        {
            _entity = scene.createEntity(entityName, position);
            _textComponent = _entity.addComponent(new Text(Font, Text, Vector2.Zero, color));
            
            return this;
        }

        public TextComposer updateOffsets(Vector2 offset)
        {
            _textComponent.localOffset = offset;
            
            return this;
        }
    }
}