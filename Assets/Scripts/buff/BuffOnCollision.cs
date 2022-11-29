using UnityEngine;

[RequireComponent(typeof(Buffer))]
public class BuffOnCollision : MonoBehaviour
{
    private Buffer _buffer;

    private void Awake()
    {
        _buffer = GetComponent<Buffer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            _buffer.Buff(player);
            Destroy(gameObject);
        }
    }
}
