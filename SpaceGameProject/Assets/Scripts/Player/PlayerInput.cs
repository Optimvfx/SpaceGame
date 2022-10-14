using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(PlayerMover))]
[RequireComponent(typeof(PlayerShoter))]
[RequireComponent(typeof(PlayerInventory))]
public class PlayerInput : MonoBehaviour
{
    private readonly string _moveDirectionHorizontal = "Horizontal";

    [SerializeField] private Button _nextWeaponButton;
    [SerializeField] private Button _prewiusWeaponButton;

    private readonly OneFloat _moveDirectionLeft = 1;
    private readonly OneFloat _moveDirectionRight = -1;

    private PlayerMover _mover;
    private PlayerShoter _shoter;
    private PlayerInventory _inventory;

    private void Awake()
    {
        _mover = GetComponent<PlayerMover>();
        _shoter = GetComponent<PlayerShoter>();
        _inventory = GetComponent<PlayerInventory>();
    }

    private void OnEnable()
    {
        _nextWeaponButton.onClick.AddListener(SellectNextWeapon);
        _prewiusWeaponButton.onClick.AddListener(SellectPrewiusWeapon);
    }

    private void OnDisable()
    {
        _nextWeaponButton.onClick.RemoveListener(SellectNextWeapon);
        _prewiusWeaponButton.onClick.RemoveListener(SellectPrewiusWeapon);
    }

    private void Update()
    {
        RecalculateMoveDirection();

        _shoter.TryShoot();
    }

    private void RecalculateMoveDirection()
    {
        var moveDirection = Input.GetAxis(_moveDirectionHorizontal);

        if (moveDirection > 0)
            _mover.ChangeTargetMoveDirection(_moveDirectionLeft);
        else if (moveDirection < 0)
            _mover.ChangeTargetMoveDirection(_moveDirectionRight);
        else
            _mover.ChangeTargetMoveDirection(0);
    }

    private void SellectNextWeapon()
    {
        _inventory.SellectNextWeapon();
    }

    private void SellectPrewiusWeapon()
    {
        _inventory.SellectPreviousWeapon();
    }
}
