using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;

    public void Spawn()
    {
        Instantiate(_prefab, transform.position,Quaternion.identity);
    }
}
