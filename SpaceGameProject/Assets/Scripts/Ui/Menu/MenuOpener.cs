using UnityEngine.UI;
using UnityEngine;

public class MenuOpener : MonoBehaviour
{
    [SerializeField] private MenuManager _menuManger;

    [SerializeField] private Button _openMainMenuButton;

    [SerializeField] private MainMenu _mainMenu;

    private void OnEnable()
    {
        _openMainMenuButton.onClick.AddListener(OpenMainMenu);
    }

    private void OnDisable()
    {
        _openMainMenuButton.onClick.RemoveListener(OpenMainMenu);
    }


    private void OpenMainMenu()
    {
       _menuManger.OpenMenu(_mainMenu);
    }
}
