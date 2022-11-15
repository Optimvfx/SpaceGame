using UnityEngine;

public class Restarter : MonoBehaviour
{
    public void Restart()
    {
        Time.timeScale = 1;
        IJunior.TypedScenes.MenuScene.Load();
    }
}
