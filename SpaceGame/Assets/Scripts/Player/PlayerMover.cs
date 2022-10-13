using System;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private UFloat _moveSpeedBySecond;
    [SerializeField] private UFloat _moveBoundsX;

    [Header("Rotation")]
    [SerializeField] private Angle _angleToMoveDirectionCoefficient = 60;

    [Header("Move Direction")]
    [SerializeField] private AnimationCurve _moveDirectionChangeSpeed;
    [SerializeField] private UFloat _moveDirectionChangeModiffier;

    [SerializeField] private OneFloat _targetMoveDirectionX;

    [SerializeField] private OneFloat _currentMoveDirectionX;

    private void Update()
    {
        ChangeCurrentMoveDirection(Time.deltaTime);
        RotateByMoveDirection();
        MoveToDirection(Time.deltaTime);
    }

    public void ChangeTargetMoveDirection(OneFloat newTargetMoveDirectionX)
    {
        _targetMoveDirectionX = newTargetMoveDirectionX;
    }

    private void ChangeCurrentMoveDirection(float passedTime)
    {
        if (Mathf.Approximately(_targetMoveDirectionX, 0) || Mathf.Approximately(_targetMoveDirectionX, _currentMoveDirectionX))
            return;

        var range = Mathf.Abs(_targetMoveDirectionX - passedTime);

        _currentMoveDirectionX = Mathf.MoveTowards(_currentMoveDirectionX, _targetMoveDirectionX, _moveDirectionChangeSpeed.Evaluate(range) * passedTime * _moveDirectionChangeModiffier);
    }

    private void RotateByMoveDirection()
    {
        transform.rotation = Quaternion.Euler(0, 0, -_angleToMoveDirectionCoefficient * _currentMoveDirectionX);
    }

    private void MoveToDirection(float passedTime)
    {
        var moveX = _currentMoveDirectionX * passedTime * _moveSpeedBySecond;
        var nextXPoistion = transform.position.x + moveX;
        var clampedNextXPosition = Mathf.Clamp(nextXPoistion, -_moveBoundsX, _moveBoundsX);

        transform.position = new Vector3(clampedNextXPosition, transform.position.y, transform.position.z);
    }
}
