using UnityEngine;
using UnityEngine.Events;

public class Bullet : MonoBehaviour
{
    [SerializeField] private uint _damage;
    [SerializeField] private UFloat _speed;

    public UnityAction<Bullet> OnDestroy;

    private void Update()
    {
        transform.Translate(Vector2.up * _speed * Time.deltaTime, Space.Self);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
            return;

        OnDestroy?.Invoke(this);

        if(collision.gameObject.TryGetComponent(out Metior metior))
        {
            metior.TakeDamage((int)_damage);
        }

        Destroy(gameObject);
    }
}