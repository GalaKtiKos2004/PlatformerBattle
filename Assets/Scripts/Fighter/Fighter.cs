using System.Collections;
using System.Threading;
using UnityEngine;

[RequireComponent(typeof(ColliderDetector))]
public class Fighter : MonoBehaviour
{
    [SerializeField] private LayerMask _attackedLayer;
    [SerializeField] private LayerMask _playerLayer;
    [SerializeField] private LayerMask _enemyLayer;
    [SerializeField] private Vector2 _colliderSize;
    [SerializeField] private float _damage;
    [SerializeField] private float _maxHealth;
    [SerializeField] private float _attackColldown = 3f;

    private PlayerInput _input;
    private ColliderDetector _detector;
    private Attacker _attacker;
    private Health _health;
    private WaitForSeconds _wait;
    private LayerMask _currentLayer;
    private bool _canAttack = true;

    private void Awake()
    {
        TryGetComponent(out _input);
        _detector = GetComponent<ColliderDetector>();
        _currentLayer = gameObject.layer;
        _attacker = new Attacker();
        _health = new Health(_maxHealth);
        _wait = new WaitForSeconds(_attackColldown);
    }

    private void Update()
    {
        bool isPlayerLayer = (_playerLayer.value & (1 << gameObject.layer)) != 0;
        bool isEnemyLayer = (_enemyLayer.value & (1 << gameObject.layer)) != 0;

        if (_canAttack && (isPlayerLayer && _input.IsAttack || isEnemyLayer))
        {
            Attack();
        }
    }

    public void TakeDamage(float damage)
    {
        _health.TakeDamage(damage);
    }

    private void Attack()
    {        
        if (_attacker.TryAttack(_damage, _detector, transform, _attackedLayer, _colliderSize))
        {
            StartCoroutine(AttackColldown());
        }
    }

    private IEnumerator AttackColldown()
    {
        _canAttack = false;
        yield return _wait;
        _canAttack = true;
    }
}
