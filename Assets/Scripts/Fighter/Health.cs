using System;
using UnityEngine;

public class Health
{
    private float _maxHealth;

    public event Action Died;

    public Health(float maxHealth)
    {
        _maxHealth = maxHealth;
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
        float minHealth = 0;

        CurrentHealth = CurrentHealth = Mathf.Clamp(CurrentHealth + recoverHealth, minHealth, _maxHealth);
    }
}
