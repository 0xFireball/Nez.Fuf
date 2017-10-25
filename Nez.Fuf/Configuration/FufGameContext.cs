using RustyNebula.Configuration;

namespace Nez.Fuf.Configuration {
    public abstract class FufGameContext {
        public GameConfiguration configuration;

        protected FufGameContext(GameConfiguration configuration) {
            this.configuration = configuration;
        }
    }
}