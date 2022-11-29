using UnityEngine;

public static class Storage
{
    private static IStorage _storage;
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
    private static void InitializeStorage()
    {
        
#if UNITY_WEBGL && !UNITY_EDITOR
        _storage = new WebGLStorage();
#else
        _storage = new StandaloneStorage();
#endif

    }

    public static void DeleteKey(string key)
    {
        _storage.Remove(key);
    }

    public static bool HasKey(string key)
    {
        return _storage.HasKey(key);
    }

    public static string GetString(string key)
    {
        return _storage.GetString(key);
    }

    public static void SetString(string key, string value)
    {
        _storage.SetString(key,value);
    }

    public static void Save()
    {
        _storage.Save();
    }

    public static void PrintJSLine(string str)
    {
        _storage.PrintJSLine(str);
    }
}