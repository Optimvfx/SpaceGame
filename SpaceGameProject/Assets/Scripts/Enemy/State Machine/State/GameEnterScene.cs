using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(BossEnemy))]
public class GameEnterScene : State
{
    [SerializeField] private Transform _endPoint;
    [SerializeField] private UFloat _speed;

    private BossEnemy _self;

    private Tween _moveTween;

    private void Awake()
    {
        _self = GetComponent<BossEnemy>();
    }

    private void OnEnable()
    {
        _moveTween = transform.DOMove(_endPoint.position, Vector2.Distance(_endPoint.position, transform.position) / _speed);

        _moveTween.onKill += ActivateTurrets;

    }

    private void OnDisable()
    {
        if(_moveTween != null )
            _moveTween.Kill();
    }

    private void ActivateTurrets()
    {
        _self.ActivateTurrets();
    }
}
