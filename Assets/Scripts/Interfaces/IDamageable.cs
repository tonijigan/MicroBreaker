namespace Interfaces
{
    public interface IDamageable : ITrigger
    {
        public void TakeDamage(int damage);
    }
}