using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;

    public void Spawn()
    {
        if (_prefab == null)
            return;

        Instantiate(_prefab, transform.position,Quaternion.identity);
    }
}
