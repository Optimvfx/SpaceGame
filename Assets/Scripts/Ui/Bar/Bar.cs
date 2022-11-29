using UnityEngine;
using UnityEngine.UI;

public abstract class Bar : MonoBehaviour
{
    [SerializeField] protected Slider Slider;

    public void OnValueChanged(int value, int maxValue)
    {
        if (value > maxValue)
            throw new System.ArgumentException();

        Slider.maxValue = maxValue;
        Slider.value = value;
    }
}