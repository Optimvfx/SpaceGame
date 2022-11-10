using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private float _zRotation;
    [SerializeField] private bool _rotate;

    public void Spawn()
    {
        if (_prefab == null)
            return;

        if (_rotate)
        {
            Instantiate(_prefab, transform.position, Quaternion.Euler(new Vector3(0, 0, _zRotation) + _prefab.transform.rotation.eulerAngles));
        }
        else
        {
            Instantiate(_prefab, transform.position, Quaternion.identity);
        }
    }
}
