using UnityEngine;

[RequireComponent(typeof(ReadOnlyEnemy))]
[RequireComponent(typeof(Health))]
public class EnemyStateMachine : MonoBehaviour
{
    [SerializeField] private State _firstState;

    private ReadOnlyEnemy _self;
    private Health _health;

    private State _currentState;

    public State Current => _currentState;

    private void Awake()
    {
        _self = GetComponent<ReadOnlyEnemy>();
        _health = GetComponent<Health>();

        StopStateMachine();
    }

    private void OnEnable()
    {
        _health.Dieing += StopStateMachine;
    }

    private void OnDisable()
    {
        _health.Dieing -= StopStateMachine;
    }

    private void Start()
    {
        Reset(_firstState);
    }

    private void Update()
    {
        if (_currentState == null)
            return;

        var nextState = _currentState.GetNextState();
        if (nextState != null)
            Transit(nextState);
    }

    private void Reset(State startState)
    {
        _currentState = startState;

        if (_currentState != null)
            _currentState.Enter();
    }

    private void Transit(State nextState)
    {
        if (_currentState != null)
            _currentState.Exit();

        _currentState = nextState;

        if (_currentState != null)
            _currentState.Enter();
    }

    private void StopStateMachine()
    {
        _currentState = null;

        foreach (var state in GetComponents<State>())
            state.enabled = false;

        foreach (var transition in GetComponents<Transition>())
            transition.enabled = false;
    }    
}