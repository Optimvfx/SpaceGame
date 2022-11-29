using IJunior.TypedScenes;
using UnityEngine;
using UnityEngine.Events;

public class GameSceneLoadHandler : MonoBehaviour, ISceneLoadHandler<GameSceneArguments>
{
    [SerializeField] private GameSceneLoadEvent[] _gameSceneLoadEvents;

    public void OnSceneLoaded(GameSceneArguments argument)
    {
        foreach (var loadEvent in _gameSceneLoadEvents)
            loadEvent.OnSceneLoaded(argument);
    }
}
