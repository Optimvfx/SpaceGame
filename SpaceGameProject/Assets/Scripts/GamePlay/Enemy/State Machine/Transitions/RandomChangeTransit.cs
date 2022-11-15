
using System.Collections;
using UnityEngine;

public class RandomChangeTransit : Transition
{
    [SerializeField] private Change _change;
    [SerializeField] private UFloat _dellay;

    public override bool NeedTransit => TryTransit();

    private bool _isOnDellay = false;

    private bool TryTransit()
    {
        if (_isOnDellay)
            return false;

        StartCoroutine(WaitDellay());

        return _change.Try();
    }

    private IEnumerator WaitDellay()
    {
        _isOnDellay = true;

        yield return new WaitForSeconds(_dellay);

        _isOnDellay = false;
    }    

    [System.Serializable]
    public class Change
    {
        public const float MaxChange = 100;

        [Range(0,MaxChange)]
        [SerializeField] private float _change;

        public bool Try()
        {
            return Random.Range(0, MaxChange) < _change;
        }
    }
}
