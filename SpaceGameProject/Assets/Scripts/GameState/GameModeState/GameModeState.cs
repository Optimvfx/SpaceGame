using UnityEngine;
using UnityEngine.Events;

public class GameModeState : MonoBehaviour
{
    [SerializeField] private CurrentState _currentState;

    [Header("Events")]
    [SerializeField] private UnityEvent OnBossStateEnter;
    [SerializeField] private UnityEvent OnMeteorSpawnStateEnter;

    public event UnityAction<CurrentState> OnChangeState;

    public void TrySetCurrentState(CurrentState currentState)
    {
        if (_currentState == currentState)
            return;

        _currentState = currentState;

        OnChangeState?.Invoke(_currentState);

        InvokeState();
    }

    private void InvokeState()
    {
        if (_currentState == CurrentState.MeteorSpawn)
            OnMeteorSpawnStateEnter?.Invoke();

        if (_currentState == CurrentState.BossFight)
            OnBossStateEnter?.Invoke();
    }

   [System.Serializable]
   public enum CurrentState
    {
        MeteorSpawn,
        BossFight
    }
}
