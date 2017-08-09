using Nez;

namespace Nez.Fuf.Game
{
    public class DamageComponent : Component
    {
        public float Damage { get; }

        public DamageComponent(float damage)
        {
            Damage = damage;
        }
    }
}