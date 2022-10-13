using UnityEngine;

public class WinMenuOpener : MonoBehaviour
{
    [SerializeField] private MenuManager _menuManager;

    [SerializeField] private WinMenu _winMenu;

    private void OnEnable()
    {
    }

    private void OnDisable()
    {
    }

    private void ActivateWinMenu()
    {
       _menuManager.OpenMenu(_winMenu);
    }
}
