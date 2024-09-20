using UnityEngine;
public class Attacker
{
    public void TryAttack(float damage, ColliderDetector detector, Transform position, LayerMask attackedLayer, Vector2 colliderSize)
    {
        if (detector.IsGrounded(position, attackedLayer, colliderSize, out Collider2D attackedCollider))
        {
            if (attackedCollider.TryGetComponent(out Attacked attacked))
            {
                attacked.TakeDamage(damage);
            }
        }
    }
}
