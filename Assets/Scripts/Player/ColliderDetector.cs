using UnityEngine;

public class ColliderDetector : MonoBehaviour
{
    [SerializeField] private Vector2 _boxSize;

    public bool IsGrounded(Transform checkPoint, LayerMask layerMask, out Collider2D hitCollider)
    {
        hitCollider = Physics2D.OverlapBox(checkPoint.position, _boxSize, checkPoint.eulerAngles.z, layerMask);

        return hitCollider != null;
    }
}
