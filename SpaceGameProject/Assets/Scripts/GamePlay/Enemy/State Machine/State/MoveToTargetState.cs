using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(BossEnemy))]
public class MoveToTargetState : EndableState
{
    [SerializeField] private Vector2 _endPoint;
    [SerializeField] private UFloat _speed;
    [SerializeField] private bool _ignoreXMove = false;
    [SerializeField] private bool _ignoreYMove = false;
    [SerializeField] private bool _activateTurrets;

    private BossEnemy _self;

    private Tween _moveTween;

    private void Awake()
    {
        _self = GetComponent<BossEnemy>();
    }

    private void OnEnable()
    {
        var endPoint = _endPoint;

        if (_ignoreXMove)
            endPoint.x = transform.position.x;

        if (_ignoreYMove)
            endPoint.y = transform.position.y;

        _moveTween = transform.DOMove(endPoint, Vector2.Distance(endPoint, transform.position) / _speed).SetEase(Ease.Linear);

        _moveTween.onKill += OnEnd;
    }

    private void OnDisable()
    {
        if(_moveTween != null )
            _moveTween.Kill();
    }

    private void OnEnd()
    {
        if (_activateTurrets)
            _self.ActivateWeapons();

        EndState();

        _moveTween.onKill -= OnEnd;
    }
}
