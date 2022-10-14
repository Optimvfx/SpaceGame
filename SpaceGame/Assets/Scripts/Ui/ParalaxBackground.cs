using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RawImage))]
public class ParalaxBackground : MonoBehaviour
{
    private readonly UFloat _maximalYPosition = 1;

    [SerializeField] private UFloat _moveSpeedY;

    private RawImage _image;

    private float _currentYPossition = 0;

    private void Start()
    {
        _image = GetComponent<RawImage>();
    }

    private void Update()
    {
        _currentYPossition += _moveSpeedY * Time.deltaTime;

        _currentYPossition %= _maximalYPosition;

        _image.uvRect = new Rect(0, _currentYPossition, _image.uvRect.width, _image.uvRect.height);
    }
}
