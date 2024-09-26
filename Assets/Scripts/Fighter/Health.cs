using System;

public class Health
{
    public event Action Died;

    public Health(float maxHealth)
    {
        CurrentHealth = maxHealth;
    }

    public float CurrentHealth { get; private set; }

    public void TakeDamage(float damage)
    {
        CurrentHealth -= damage;

        if (CurrentHealth <= 0)
        {
            Died?.Invoke();
        }
    }

    public void AddHealth(float recoverHealth)
    {
        CurrentHealth += recoverHealth;
    }
}
