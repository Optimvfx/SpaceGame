using UnityEngine;
using UnityEngine.Events;

public class DoWithChanñe : MonoBehaviour
{
    private readonly UFloat _maxChanse = 100;

    [SerializeField] private UnityEvent _do;

    [Range(0f, 100f)]
    [SerializeField] private float _chanñe;

    public void TryDo()
    {
        var randomValue = Random.Range(0, _maxChanse);

        if(randomValue < _chanñe)
            _do?.Invoke();
    }
}
