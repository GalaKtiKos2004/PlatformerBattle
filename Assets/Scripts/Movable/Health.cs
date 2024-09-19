using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float _maxHealth;

    public float CurrentHealth { get; private set; }

    private void Start()
    {
        CurrentHealth = _maxHealth;
    }

    public void TakeDamage(float damage)
    {
        CurrentHealth -= damage;
    }
}
