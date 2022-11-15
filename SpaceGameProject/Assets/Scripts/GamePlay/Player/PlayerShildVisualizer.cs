using UnityEngine;

[RequireComponent(typeof(Player))]
public class PlayerShildVisualizer : MonoBehaviour
{
    [SerializeField] private Transform _shild;

    private Player _player;

    private void Awake()
    {
        _shild.gameObject.SetActive(false);
        _player = GetComponent<Player>();
    }

    private void OnEnable()
    {
        _player.DeffEnable += ActiveShild;
        _player.DeffDisable += DisableShild;
    }

    private void OnDisable()
    {
        _player.DeffEnable -= ActiveShild;
        _player.DeffDisable -= DisableShild;
    }

    private void ActiveShild()
    {
        _shild.gameObject.SetActive(true);
    }

    private void DisableShild()
    {
        _shild.gameObject.SetActive(false);
    }
}
