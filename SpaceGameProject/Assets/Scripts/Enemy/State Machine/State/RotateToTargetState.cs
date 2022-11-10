using DG.Tweening;
using UnityEngine;

[RequireComponent(typeof(BossEnemy))]
public class RotateToTargetState : EndableState
{
    [SerializeField] private float _endZRotate;
    [SerializeField] private UFloat _duration;

    private Tween _rotateTween;

    private void OnEnable()
    {
        var currentRotation = transform.rotation.eulerAngles;

        _rotateTween = transform.DORotate(new Vector3(currentRotation.x, currentRotation.y, _endZRotate), _duration);

        _rotateTween.onKill += OnEnd;
    }

    private void OnDisable()
    {
        if (_rotateTween != null)
            _rotateTween.Kill();
    }

    private void OnEnd()
    {
        EndState();

        _rotateTween.onKill -= OnEnd;
    }
}