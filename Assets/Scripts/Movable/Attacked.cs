using System.Threading;
using UnityEngine;

[RequireComponent(typeof(ColliderDetector))]
public class Attacked : MonoBehaviour
{
    [SerializeField] private LayerMask _attackedLayer;
    [SerializeField] private LayerMask _playerLayer;
    [SerializeField] private LayerMask _enemyLayer;
    [SerializeField] private Vector2 _colliderSize;
    [SerializeField] private float _damage;
    [SerializeField] private float _maxHealth;

    private PlayerInput _input;
    private ColliderDetector _detector;
    private LayerMask _currentLayer;
    private Attacker _attacker;
    private Health _health;

    private void Awake()
    {
        TryGetComponent(out _input);
        _detector = GetComponent<ColliderDetector>();
        _currentLayer = gameObject.layer;
        _attacker = new Attacker();
        _health = new Health(_maxHealth);
    }

    private void Update()
    {
        bool isPlayerLayer = (_playerLayer.value & (1 << gameObject.layer)) != 0;
        bool isEnemyLayer = (_enemyLayer.value & (1 << gameObject.layer)) != 0;

        if ((isPlayerLayer && _input.IsAttack) || (isEnemyLayer))
        {
            _attacker.TryAttack(_damage, _detector, transform, _attackedLayer, _colliderSize);
        }

        if (isPlayerLayer)
        {
            Debug.Log(_health.CurrentHealth);
        }

        Thread.Sleep(5000);
    }

    public void TakeDamage(float damage)
    {
        _health.TakeDamage(damage);
    }
}
