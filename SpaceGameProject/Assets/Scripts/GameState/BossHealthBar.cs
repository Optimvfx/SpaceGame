using TMPro;
using UnityEngine;

public class BossHealthBar : MonoBehaviour
{
    [SerializeField] private TMP_Text _lable;
    [SerializeField] private HealthBar _healthBar;
    [SerializeField] private TransiterToBossPastTime _observable;

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

        _healthBar.Init(enemy.Health);
        _healthBar.gameObject.SetActive(true);
    }

    private void Hide()
    {
        _lable.gameObject.SetActive(false);

        _healthBar.gameObject.SetActive(false);
    }
}
