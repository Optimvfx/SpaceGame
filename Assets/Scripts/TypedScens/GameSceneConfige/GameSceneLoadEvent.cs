using UnityEngine;
using IJunior.TypedScenes;

public abstract class GameSceneLoadEvent : MonoBehaviour
{
    public abstract void OnSceneLoaded(GameSceneArguments argument);
}
