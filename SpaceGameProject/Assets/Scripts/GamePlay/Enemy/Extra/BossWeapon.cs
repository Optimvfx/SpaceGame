using UnityEngine;

public class BossWeapon : MonoBehaviour
{
    [SerializeField] private LookAt2d _torretLookAt;
    [SerializeField] private Turret _turret;

    public void Activate(BossEnemyInitArguments arguments)
    {
        if (_torretLookAt != null)
        {
            _torretLookAt.Init(arguments.Player.transform);
            _torretLookAt.enabled = true;
        }

        if (_turret != null)
        {
            _turret.Init(arguments);
            _turret.enabled = true;
        }
    }

    public void DiActivate()
    {
        if(_torretLookAt != null)
        _torretLookAt.enabled = false;

        if(_turret != null)
        _turret.enabled = false;
    }
}
