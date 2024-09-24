using System;
using UnityEngine;

public class PlayerFinder : MonoBehaviour
{
    private const string PlayerLayer = "Player";

    public event Action Collide;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (LayerMask.LayerToName(collision.gameObject.layer) == PlayerLayer)
        {
            Collide?.Invoke();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (LayerMask.LayerToName(collision.gameObject.layer) == PlayerLayer)
        {
            Collide?.Invoke();
        }
    }
}