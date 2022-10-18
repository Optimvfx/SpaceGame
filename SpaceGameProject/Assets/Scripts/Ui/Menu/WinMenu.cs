using UnityEngine;
using UnityEngine.UI;

public class WinMenu : Menu
{
    [SerializeField] private TopMenu _topMenu;
    [Header("Restart")]
    [SerializeField] private Button _restartButton;
    [SerializeField] private Restarter _restarter;

    public void OnEnable()
    {
        _restartButton.onClick.AddListener(Restart);
        _topMenu.gameObject.SetActive(true);
    }

    private void OnDisable()
    {
        _restartButton.onClick.RemoveListener(Restart);
        _topMenu.gameObject.SetActive(false);
    }

    private void Restart()
    {
        _restarter.Restart();
    }
}