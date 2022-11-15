using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Graphic))]
public class ColorChanger : MonoBehaviour
{
    private readonly float _gradientMaxValue = 1;

    [Header("General")]
    [SerializeField] private Gradient _color;
    [SerializeField] private UFloat _changeSpeed;

    [Header("Healp")]
    [SerializeField] private Color _current;

    private float _currentColorIndex = 0;

    private Graphic _image;

    private void Awake()
    {
        _image = GetComponent<Graphic>();
    }

    private void Update()
    {
        _currentColorIndex += _changeSpeed * Time.deltaTime;
        _currentColorIndex %= _gradientMaxValue;

        _current = _color.Evaluate(_currentColorIndex);
        _image.color = _current;
    }
}
