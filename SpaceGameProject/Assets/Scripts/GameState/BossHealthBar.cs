using TMPro;
using UnityEngine;

public class BossHealthBar : MonoBehaviour
{
    [SerializeField] private TMP_Text _lable;
    [SerializeField] private HealthBar[] _healthBars;
    [SerializeField] private GoToBossPastTime _observable;

    private void OnEnable()
    {
        _observable.OnSpawn += Show;
    }

    private void OnDisable()
    {
        _observable.OnSpawn -= Show;
    }

    private void Show(ReadOnlyEnemy enemy)
    {
        _lable.text = enemy.name;

        enemy.Health.OnDie += Hide;

        _lable.gameObject.SetActive(true);

        foreach (var healthBar in _healthBars)
        {
            healthBar.Init(enemy.Health);
            healthBar.gameObject.SetActive(true);
        }
    }

    private void Hide()
    {
        _lable.gameObject.SetActive(false);

        foreach (var healthBar in _healthBars)
        {
            healthBar.gameObject.SetActive(false);
        }
    }
}
