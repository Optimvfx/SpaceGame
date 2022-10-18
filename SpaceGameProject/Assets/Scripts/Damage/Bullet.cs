using UnityEngine;
using UnityEngine.Events;

public class Bullet<Ignore> : Damager<Ignore>
    where Ignore : IDamageIgnore, new()
{
    [SerializeField] private UFloat _speed;

    public UnityAction<GameObject> Destroying;

    private void Update()
    {
        transform.Translate(Vector2.up * _speed * Time.deltaTime, Space.Self);
    }

    private void OnDestroy()
    {
        Destroying?.Invoke(gameObject);
    }
}
