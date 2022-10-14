using UnityEngine;

public class ProgressBar : Bar
{
    private void OnEnable()
    {
        Slider.value = 0;
    }

    private void OnDisable()
    {
    }
}