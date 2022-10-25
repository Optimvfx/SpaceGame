using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(BossEnemy))]
public class MoveToTargetState : EndableState
{
    [SerializeField] private Vector2 _endPoint;
    [SerializeField] private UFloat _speed;
    [SerializeField] private bool _ignoreXMove = false;
    [SerializeField] private bool _activateTurrets;

    private BossEnemy _self;

    private Tween _moveTween;

    private void Awake()
    {
        _self = GetComponent<BossEnemy>();
    }

    private void OnEnable()
    {
        if (_ignoreXMove)
            _moveTween = transform.DOMove(new Vector2(transform.position.x, _endPoint.y), Mathf.Abs(_endPoint.y - transform.position.y) / _speed);
        else
            _moveTween = transform.DOMove(_endPoint, Vector2.Distance(_endPoint, transform.position) / _speed);

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
            _self.ActivateTurrets();

        EndStateAction();

        _moveTween.onKill -= OnEnd;
    }
}
