using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(PlayerInput))]
public class PlayerJumper : MonoBehaviour
{
    [SerializeField] private float _force;
    [SerializeField] private ColliderDetector _groundDetector;
    [SerializeField] private LayerMask _groundLayer;

    private Rigidbody2D _rigidbody;
    private PlayerInput _playerInput;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _playerInput = GetComponent<PlayerInput>();
    }

    private void FixedUpdate()
    {
        if (_playerInput.JumpInput)
        {
            TryJump();
        }
    }

    private void TryJump()
    {
        if (_groundDetector.IsGrounded(transform, _groundLayer, out _))
        {
            _rigidbody.AddForce(new Vector2(0f, _force), ForceMode2D.Impulse);
        }

    }
}