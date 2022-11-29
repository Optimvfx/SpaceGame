using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class VirtualScoreScrolBar : MonoBehaviour
{
    private Slider _slider;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
    }

    private void OnEnable()
    {
        _slider.onValueChanged.AddListener(ChangeVirtualScore);
    }

    private void OnDisable()
    {
        _slider.onValueChanged.RemoveListener(ChangeVirtualScore);
    }

    private void ChangeVirtualScore(float value)
    {
        SpaceGameApiSingleton.GameAPI.SetVirtualScore((uint)(value));
    }
}
