using Nez.UI;

namespace Nez.Fuf.Platform {
    public class DesktopPlatform {
        private readonly Core _core;

        public DesktopPlatform(Core core) {
            _core = core;
        }

        private bool _borderlessFullscreen = false;

        public bool IsBorderlessFullscreen {
            get => _borderlessFullscreen;
            set {
                if (value) EnterBorderlessFullscreen();
                else ExitBorderlessFullscreen();
                _borderlessFullscreen = value;
            }
        }

        public void EnterBorderlessFullscreen() {
            _core.Window.IsBorderless = true;
            
            // update backbuffer size
            Core.graphicsManager.PreferredBackBufferWidth = Core.graphicsDevice.Adapter.CurrentDisplayMode.Width;
            Core.graphicsManager.PreferredBackBufferHeight = Core.graphicsDevice.Adapter.CurrentDisplayMode.Height;

            Core.graphicsManager.ApplyChanges();
        }

        public void ExitBorderlessFullscreen() {
            _core.Window.IsBorderless = false;
            // restore backbuffer size
            Core.graphicsManager.PreferredBackBufferWidth = _core.defaultResolution.X;
            Core.graphicsManager.PreferredBackBufferHeight = _core.defaultResolution.Y;

            Core.graphicsManager.ApplyChanges();
        }
    }
}