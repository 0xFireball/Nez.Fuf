using Nez;

namespace Nez.Fuf.Game
{
    public class HealthComponent : Component
    {
        public float MaxHealth;

        public float Health;

        public HealthComponent(float maxHealth = 1f)
        {
            MaxHealth = maxHealth;
            Health = MaxHealth;
        }

        public float Damage
        {
            get => 1 - (Health / MaxHealth);
            set => Health = (1 - value) * MaxHealth;
        }

        public static implicit operator float(HealthComponent healthComponent)
        {
            return healthComponent.Health;
        }
    }
}