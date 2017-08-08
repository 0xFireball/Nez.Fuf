using System;
using Nez.Fuf.Physics;

namespace Nez.Fuf.Sprites
{
    public class FufProjectile<TSprite, TMovement> : Component
        where TSprite : FufSprite
        where TMovement : ProjectileBody
    {
        public override void initialize()
        {
            base.initialize();
            
            // add sprite
            entity.addComponent(Activator.CreateInstance<TSprite>());
        }

        public Type BodyType => typeof(TMovement);
    }
}