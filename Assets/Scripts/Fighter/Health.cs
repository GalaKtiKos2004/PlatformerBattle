public class Health
{
    private float _maxHealth;

    public Health(float maxHealth)
    {
        _maxHealth = maxHealth;
        CurrentHealth = maxHealth;
    }

    public float CurrentHealth { get; private set; }

    public void TakeDamage(float damage)
    {
        CurrentHealth -= damage;
    }
}
