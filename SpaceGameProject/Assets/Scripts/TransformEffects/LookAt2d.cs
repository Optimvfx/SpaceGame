using System;
using UnityEngine;

public class LookAt2d : MonoBehaviour
{
    public const float FullSphareAngle = 360;

    [SerializeField] private Transform _target;
    [SerializeField] private float _addedAngle;
    [Range(0f, 100f)]
    [SerializeField] private float _modiffier;

    internal void Init(Transform target)
    {
        _target = target;
    }

    private void Update()
    {
        LookAtTarget();
    }

    public static void Look(Transform self, Transform target, float extraAngle = 0, float modiffier = 1)
    {
        modiffier = Mathf.Clamp(modiffier, 0, 1);

        var lookDirection = (Vector2)target.transform.position - (Vector2)self.position;

        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg + extraAngle;
        self.rotation = Quaternion.Lerp(self.rotation, Quaternion.AngleAxis(angle + FullSphareAngle / 2, Vector3.forward), modiffier);
    }

    public static Quaternion AngeleToQuaternion(float angle)
    {
        return Quaternion.AngleAxis(angle, Vector3.forward);
    }

    private void LookAtTarget()
    {
        if (_target == null)
            return;

        Look(transform, _target, _addedAngle, _modiffier * Time.deltaTime);
    }
}
