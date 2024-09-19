using UnityEngine;

public class Attacker : MonoBehaviour
{
    [SerializeField] private LayerMask _attackedLayer;
    [SerializeField] private float _damage;

    private readonly LayerMask _playerLayer = LayerMask.NameToLayer("Player");
    private readonly LayerMask _enemyLayer = LayerMask.NameToLayer("Enemy");

    private PlayerInput _input;
    private ColliderDetector _detector;
    private LayerMask _currentLayer;

    private void Awake()
    {
        _input = GetComponent<PlayerInput>();
        _detector = GetComponent<ColliderDetector>();
        _currentLayer = GetComponent<LayerMask>();
    }

    private void Update()
    {
        if ((_currentLayer == _playerLayer && _input.IsAttack) || (_currentLayer == _enemyLayer))
        {
            TryAttack();
        }
    }

    private void TryAttack()
    {
        if (_detector.IsGrounded(transform, _attackedLayer, out Collider2D attackedCollider))
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
