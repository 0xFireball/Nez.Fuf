using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Nez.Fuf.Util {
    public static class TextureScaler {
        public static Texture2D renderTextureScaled(Texture2D source, Vector2 scale) {
            var targetSize = new Point((int) (scale.X * source.Width), (int) (scale.Y * source.Height));
            var renderTarget = new RenderTarget2D(Core.instance.GraphicsDevice, targetSize.X, targetSize.Y);
            var targetRect = new Rectangle(0, 0, targetSize.X, targetSize.Y);
            Core.instance.GraphicsDevice.SetRenderTarget(renderTarget);
            Core.instance.GraphicsDevice.Clear(Color.Transparent);
            var spriteBatch = new SpriteBatch(Core.instance.GraphicsDevice);
            spriteBatch.Begin(samplerState: SamplerState.PointClamp);
            spriteBatch.Draw(source, targetRect, Color.White);
            spriteBatch.End();
            Core.instance.GraphicsDevice.SetRenderTarget(null);
            return renderTarget;
        }
    }
}