using UnityEngine;

public class Attacker : MonoBehaviour
{
    [SerializeField] private LayerMask _attakcedLayer;
    [SerializeField] private float _damage;

    private PlayerInput _input;
    private ColliderDetector _detector;

    private void Awake()
    {
        _input = GetComponent<PlayerInput>();
        _detector = GetComponent<ColliderDetector>();
    }

    private void Update()
    {
        if (_input.IsAttack)
        {
            TryAttack();
        }
    }

    private void TryAttack()
    {
        if (_detector.IsGrounded(transform, _attakcedLayer, out Collider2D attackedCollider))
        {
            if (attackedCollider.TryGetComponent(out Health attackedHealth))
            {
                attackedHealth.TakeDamage(_damage);
            }
        }
    }

    public void Attack(Health health)
    {
        health.TakeDamage(_damage);
    }
}
