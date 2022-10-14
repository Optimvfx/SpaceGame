using UnityEngine;

public class RotateByTime : MonoBehaviour
{
    [Range(-100f,100)]
    [SerializeField] private float _rotationSpeed;

    private void Update()
    {
        Rotate();
    }

    private void Rotate()
    {
        transform.Rotate(new Vector3(0, 0, _rotationSpeed * Time.deltaTime));
    }
}
