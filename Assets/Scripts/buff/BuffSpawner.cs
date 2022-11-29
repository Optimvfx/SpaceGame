using System.Linq;
using UnityEngine;

public class BuffSpawner : MonoBehaviour
{
    [SerializeField] private BuffChanse[] _chanses;

    public void Spawn()
    {
        if (TrySellectBuff(out BuffOnCollision buffer))
            Instantiate(buffer, transform.position, Quaternion.identity);
    }

    private bool TrySellectBuff(out BuffOnCollision buffer)
    {
        _chanses = _chanses.OrderByDescending(chanse => chanse.Chanse).ToArray();

        var sumChanse = _chanses.Sum(chanse => chanse.Chanse);

        var randomChanse = Random.Range(0, sumChanse);

        int currentBuffIndex = 0;
        float currentSumarChanse = 0;

        while (currentSumarChanse < randomChanse && currentBuffIndex < _chanses.Length)
        {
            currentSumarChanse += _chanses[currentBuffIndex].Chanse;
            currentBuffIndex++;
        }

        return _chanses[currentBuffIndex - 1].Buffer.TryGetComponent(out buffer);
    }

    //Делаю через gameObject так как искать их в префабах удобней 

    [System.Serializable]
    private class BuffChanse
    {
        [Range(0.0f, 100f)]
        [SerializeField] private float _chanse;

        [SerializeField] private GameObject _buffer;

        public float Chanse => _chanse;

        public GameObject Buffer => _buffer;
    }
}
