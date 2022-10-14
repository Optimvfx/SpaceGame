using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallDown : MonoBehaviour
{
    private readonly Vector2 _down = new Vector2(0, -1);

    [SerializeField] private UFloat _speed;

    private void Update()
    {
        transform.position += (Vector3)_down.normalized * _speed * Time.deltaTime;
    }
}
