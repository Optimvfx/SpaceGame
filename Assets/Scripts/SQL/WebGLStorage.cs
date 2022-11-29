#if UNITY_WEBGL
using System.Runtime.InteropServices;
using UnityEngine;

public class WebGLStorage : IStorage
{
	public void Remove(string key)
	{
		RemoveFromLocalStorage(key);
	}

	public void Save()
	{
	}

	public bool HasKey(string key)
	{
		return HasKeyInLocalStorage(key) == 1;
	}

	public string GetString(string key)
	{
		return LoadFromLocalStorage(key);
	}

	public void SetString(string key, string value)
	{
		SaveToLocalStorage(key, value);
	}

	public void PrintJSLine(string str)
	{
		//Debug.Log(str);
		Print(str);
	}
	

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
}
#endif
