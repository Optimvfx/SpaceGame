using System;
using UnityEngine;

public class EndableState : State
{
    public event Action OnStateFinshed;

    protected void EndStateAction()
    {
        OnStateFinshed?.Invoke();
    }
}
