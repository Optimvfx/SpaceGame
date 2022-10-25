using UnityEngine;
using UnityEngine.Events;

public class DoWithChan�e : MonoBehaviour
{
    private readonly UFloat _maxChanse = 100;

    [SerializeField] private UnityEvent _do;

    [Range(0f, 100f)]
    [SerializeField] private float _chan�e;

    public void TryDo()
    {
        var randomValue = Random.Range(0, _maxChanse);

        if(randomValue < _chan�e)
            _do?.Invoke();
    }
}
