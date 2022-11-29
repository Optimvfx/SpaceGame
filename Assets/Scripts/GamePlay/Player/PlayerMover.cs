using System;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private UFloat _moveSpeedBySecond;
    [SerializeField] private UFloat _moveBoundsX;

    [SerializeField] private OneFloat _targetMoveDirectionX;

    private void Update()
    {
        MoveToDirection(Time.deltaTime);
    }

    public void ChangeTargetMoveDirection(OneFloat newTargetMoveDirectionX)
    {
        if (newTargetMoveDirectionX > 0)
            _targetMoveDirectionX = 1;
        else if (newTargetMoveDirectionX < 0)
            _targetMoveDirectionX = -1;
        else
            _targetMoveDirectionX = 0;  
    }


    private void MoveToDirection(float passedTime)
    {
        var moveX = _targetMoveDirectionX * passedTime * _moveSpeedBySecond;
        var nextXPoistion = transform.position.x + moveX;
        var clampedNextXPosition = Mathf.Clamp(nextXPoistion, -_moveBoundsX, _moveBoundsX);

        transform.position = new Vector3(clampedNextXPosition, transform.position.y, transform.position.z);
    }
}
