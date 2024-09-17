using UnityEngine;

public class Collector : MonoBehaviour
{
    private Wallet _wallet;

    private void Awake()
    {
        _wallet = new Wallet();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out ICollectable collectable))
        {
            if (collectable is Coin)
            {
                _wallet.AddCoin();
            }

            collectable.Collect();
        }
    }
}
