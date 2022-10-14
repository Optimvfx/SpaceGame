using UnityEngine;
using UnityEngine.Events;

public class GameState : MonoBehaviour
{
    [SerializeField] private WinCondition _winCondition;
    [SerializeField] private LosseCondition _losseCondition;

    public event UnityAction OnWin;
    public event UnityAction OnLosse;

    private void OnEnable()
    {
        _winCondition.OnWin += Win;
        _losseCondition.OnLosse += Losse;
    }

    private void OnDisable()
    {
        UnSubscribe();
    }

    private void Win()
    {
        UnSubscribe();
        OnWin?.Invoke();
    }

    private void Losse()
    {
        UnSubscribe();
        OnLosse?.Invoke();
    }

    private void UnSubscribe()
    {
        _winCondition.OnWin -= Win;
        _losseCondition.OnLosse -= Losse;
    }
}
