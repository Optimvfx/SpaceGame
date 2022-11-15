using System.Collections;
using UnityEngine;

public class OnCollsionDamager : MonoBehaviour
{
    [SerializeField] private uint _damage;
    [SerializeField] private UFloat _damageKD;

    private bool _onKD = false;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (_onKD)
            return;

        if(collision.gameObject.TryGetComponent(out Player player))
        {
            StartCoroutine(StartCD());

            player.TakeDamage(_damage);
        }
    }

    private IEnumerator StartCD()
    {
        _onKD = true;

        yield return new WaitForSeconds(_damageKD);

        _onKD = false;
    }
}
