using Microsoft.Xna.Framework;

namespace Nez.Fuf.Physics
{
    public class ProjectileBody : Component, IUpdatable
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
                onProjectileHit();
            }
        }

        public virtual void onProjectileHit()
        {
            // destroy
            entity.destroy();
        }
    }
}