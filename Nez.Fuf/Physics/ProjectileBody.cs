using Microsoft.Xna.Framework;

namespace Nez.Fuf.Physics
{
    public abstract class ProjectileBody : Component, IUpdatable, ITriggerListener
    {
        private ProjectileMover _mover;

        public Vector2 velocity = Vector2.Zero; 

        public override void initialize()
        {
            base.initialize();
            
            _mover = entity.addComponent<ProjectileMover>();
        }

        public void update()
        {
            if (_mover.move(velocity * Time.deltaTime))
            {
                // onProjectileHit();
            }
        }

        public abstract void onProjectileHit(Entity nt);

        public void onTriggerEnter(Collider other, Collider local)
        {
            // -
            onProjectileHit(other.entity);
        }

        public void onTriggerExit(Collider other, Collider local)
        {
            // -
        }
    }
}