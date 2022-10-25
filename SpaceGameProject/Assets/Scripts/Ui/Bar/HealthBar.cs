using UnityEngine;

public class HealthBar : Bar
{
    [SerializeField] private Health _health;

    private void OnEnable()
    {
        Subscribe(_health);
    }

    private void OnDisable()
    {
        UnSubscribe(_health);
    }

    public void Init(Health health)
    {
        if (health == null)
            throw new System.NullReferenceException();

        if (_health != null)
            UnSubscribe(_health);

        _health = health;

        Subscribe(health);
    }

    private void Subscribe(Health health)
    {
        _health.OnValueChanged += OnValueChanged;

        Slider.value = 1;
    }

    private void UnSubscribe(Health health)
    {
        _health.OnValueChanged -= OnValueChanged;
    }
}