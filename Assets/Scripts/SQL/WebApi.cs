using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Linq;
using UnityEngine;

public static class WebApi
{

    public static void DeleteKey(string key)
    {
        RemoveFromLocalStorage(key);
    }

    public static bool HasKey(string key)
    {
        try
        {
            return (HasKeyInLocalStorage(key) == 1);
        }
        catch
        {
            return false;
        }
    }

    public static string GetString(string key)
    {
        return LoadFromLocalStorage(key);
    }

    public static void SetString(string key, string value)
    {
#if UNITY_WEBGL
        SaveToLocalStorage(key, value);
#else
        throw new InvalidProgramException();
#endif

    }

    public static void Save()
    {

#if !UNITY_WEBGL
        UnityEngine.PlayerPrefs.Save();
#endif
    }

    public static void PrintJSLine(string str)
    {
        try
        {
            Print(str);
        }
        catch {
            Debug.Log(str);
        }
    }

#if UNITY_WEBGL

    [DllImport("__Internal")]
    private static extern void Print(string str);
    [DllImport("__Internal")]
    private static extern void SaveToLocalStorage(string key, string value);

    [DllImport("__Internal")]
    private static extern string LoadFromLocalStorage(string key);

    [DllImport("__Internal")]
    private static extern void RemoveFromLocalStorage(string key);

    [DllImport("__Internal")]
    private static extern int HasKeyInLocalStorage(string key);
#endif
}