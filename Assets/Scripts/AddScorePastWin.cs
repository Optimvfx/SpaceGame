using UnityEngine;

public class AddScorePastWin : MonoBehaviour
{
    [SerializeField] private GameState _state;

    private void OnEnable()
    {
        _state.OnWin += AddScore;
    }

    private void OnDisable()
    {
        _state.OnWin -= AddScore;
    }

    private void AddScore()
    {
        SpaceGameApiSingleton.GameAPI.LevelUp();
    }    
}
