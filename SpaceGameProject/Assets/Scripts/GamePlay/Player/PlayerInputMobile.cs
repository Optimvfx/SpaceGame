using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(PlayerMover))]
[RequireComponent(typeof(PlayerShoter))]
[RequireComponent(typeof(PlayerInventory))]
public class PlayerInputMobile : MonoBehaviour
{
    private readonly UFloat _minimalStep = 0.15f;

    private PlayerMover _mover;
    private PlayerShoter _shoter;

    private void Awake()
    {
        _mover = GetComponent<PlayerMover>();
        _shoter = GetComponent<PlayerShoter>();
    }

    private void LateUpdate()
    {
        RecalculateMoveDirection();

        _shoter.TryShoot();
    }

    private void RecalculateMoveDirection()
    {
        if (Input.GetMouseButton(0))
        {
            var moveDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition).x - transform.position.x;

            if (Mathf.Abs(moveDirection) > _minimalStep)
                _mover.ChangeTargetMoveDirection(moveDirection);
            else
                _mover.ChangeTargetMoveDirection(0);
        }
        else
            _mover.ChangeTargetMoveDirection(0);
    }
}
