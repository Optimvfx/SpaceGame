using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(PlayerMover))]
public class PlayerInput : MonoBehaviour
{
    private readonly string _moveDirectionHorizontal = "Horizontal";

    private PlayerMover _playerMover;

    private readonly OneFloat _moveDirectionLeft = 1;
    private readonly OneFloat _moveDirectionRight = -1;

    private void Awake()
    {
        _playerMover = GetComponent<PlayerMover>();
    }

    private void Update()
    {
        var moveDirection = Input.GetAxis(_moveDirectionHorizontal);

        if(moveDirection > 0)
            _playerMover.ChangeTargetMoveDirection(_moveDirectionLeft);
        else if(moveDirection < 0)
             _playerMover.ChangeTargetMoveDirection(_moveDirectionRight);
        else
            _playerMover.ChangeTargetMoveDirection(0);
    }
}
