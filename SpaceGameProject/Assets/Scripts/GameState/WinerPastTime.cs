using System.Collections;
using UnityEngine;

public class WinerPastTime : WinCondition
{
    [SerializeField] private UFloat _timeToWin;

    public void Start()
    {
        StartCoroutine(WinPastTime());
    }

    public IEnumerator WinPastTime()
    {
        yield return new WaitForSeconds(_timeToWin);

        Win();
    }
}
