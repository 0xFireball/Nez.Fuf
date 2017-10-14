namespace Nez.Fuf.Physics {
    public abstract class ProjectileBody : PhysicsBody, IUpdatable, ITriggerListener {
        private ProjectileMover _mover;

        public override void initialize() {
            base.initialize();

            _mover = entity.addComponent<ProjectileMover>();
        }

        public void update() {
            if (_mover.move(velocity * Time.deltaTime)) {
                // onProjectileHit();
            }
        }

        public abstract void onProjectileHit(Entity nt);

        public void onTriggerEnter(Collider other, Collider local) {
            // -
            onProjectileHit(other.entity);
        }

        public void onTriggerExit(Collider other, Collider local) {
            // -
        }
    }
}