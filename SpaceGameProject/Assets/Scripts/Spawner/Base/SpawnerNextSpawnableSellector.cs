using UnityEngine;

public abstract class SpawnerNextSpawnableSellector<Arguments> : MonoBehaviour
    where Arguments : ISpawnArguments
{ 
    public abstract GameObject GetNextSpawnable(Arguments spawnArguments, Vector3 po);
}
