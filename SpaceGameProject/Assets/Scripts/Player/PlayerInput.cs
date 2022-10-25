using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(PlayerMover))]
[RequireComponent(typeof(PlayerShoter))]
[RequireComponent(typeof(PlayerInventory))]
public class PlayerInput : MonoBehaviour
{
    private readonly string _moveDirectionHorizontal = "Horizontal";

    private PlayerMover _mover;
    private PlayerShoter _shoter;

    private float _prewiusInput = 0;

    private void Awake()
    {
        _mover = GetComponent<PlayerMover>();
        _shoter = GetComponent<PlayerShoter>();
    }

    private void Update()
    {
        RecalculateMoveDirection();

        _shoter.TryShoot();
    }

    private void RecalculateMoveDirection()
    {
        var moveDirection = Input.GetAxis(_moveDirectionHorizontal);

        if (Mathf.Approximately(moveDirection, _prewiusInput) == false)
        {
            _prewiusInput = moveDirection;
            _mover.ChangeTargetMoveDirection(moveDirection);
        }
    }
}
