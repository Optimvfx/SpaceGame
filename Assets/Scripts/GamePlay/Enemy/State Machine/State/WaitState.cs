using System.Collections;
using UnityEngine;

public class WaitState : EndableState
{
    [SerializeField] private UFloat _timeToWait;

    private Coroutine _waitCorutine;

    private void OnEnable()
    {
        _waitCorutine = StartCoroutine(WaitTime());
    }

    private void OnDisable()
    {
        if (_waitCorutine != null)
            StopCoroutine(_waitCorutine);
    }

    private IEnumerator WaitTime()
    {
        yield return new WaitForSeconds(_timeToWait);

        EndState();
    }
}
