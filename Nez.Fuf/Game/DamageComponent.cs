namespace Nez.Fuf.Game
{
    public class DamageComponent : Component
    {
        public float Value { get; }

        public DamageComponent(float value)
        {
            Value = value;
        }

        public void damage(HealthComponent hc)
        {
            hc.Health -= Value;
        }
        
        public static implicit operator float(DamageComponent damageComponent)
        {
            return damageComponent.Value;
        }
    }
}