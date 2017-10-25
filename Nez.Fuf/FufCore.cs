using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Nez.Fuf.Configuration;
using Nez.Fuf.Platform;

namespace Nez.Fuf {
    public abstract class FufCore : Core {
        protected KeyboardState lastKbState;
        protected readonly FufGameContext gameContext;
        protected GamePlatform platform;

        public bool fullscreenOnAltEnter = true;

        protected FufCore(FufGameContext context, int width = 1280, int height = 720, bool isFullScreen = false,
            string windowTitle = "FFNez",
            string contentDirectory = "Content") : base(width: width, height: height, isFullScreen: isFullScreen,
            enableEntitySystems: true, windowTitle: windowTitle, contentDirectory: contentDirectory) {
            // on-create setup

            gameContext = context;
            // use "soft" fullscreen switching
            graphicsManager.HardwareModeSwitch = false;
        }

        protected override void Initialize() {
            base.Initialize();

            // Initialize platform
            switch (Environment.OSVersion.Platform) {
                case PlatformID.Win32NT:
                case PlatformID.MacOSX:
                case PlatformID.Unix:
                    platform = new DesktopPlatform();
                    break;
            }

            // Window defaults
            Window.AllowAltF4 = true;
            Window.AllowUserResizing = true;
            exitOnEscapeKeypress = false;

            // Register context service
            services.AddService(typeof(FufGameContext), gameContext);
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime) {
            // For Mobile devices, this logic will close the Game when the Back button is pressed
            // Exit() is obsolete on iOS
//#if !__IOS__ && !__TVOS__ &&
//            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
//                Keyboard.GetState().IsKeyDown(Keys.Escape))
//                Exit();
//#endif

            var kbState = Keyboard.GetState();
            if (fullscreenOnAltEnter) {
                if (kbState.IsKeyDown(Keys.LeftAlt) && kbState.IsKeyUp(Keys.Enter) && lastKbState.IsKeyDown(Keys.Enter)) {
                    graphicsManager.IsFullScreen = !graphicsManager.IsFullScreen;
                    graphicsManager.ApplyChanges();
                }
            }
            lastKbState = kbState;

            base.Update(gameTime);
        }
    }
}