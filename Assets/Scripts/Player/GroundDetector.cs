using UnityEngine;

public class GroundDetector : MonoBehaviour
{
    [SerializeField] private Vector2 _boxSize;
    [SerializeField] private LayerMask _layerMask;

    public bool IsGrounded(Transform checkPoint)
    {
        Collider2D hitCollider = Physics2D.OverlapBox(checkPoint.position, _boxSize, checkPoint.eulerAngles.z, _layerMask);

        return hitCollider != null;
    }
}
