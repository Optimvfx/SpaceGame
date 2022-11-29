using UnityEngine;

public class StandaloneStorage : IStorage
{
	public void Remove(string key)
	{
		PlayerPrefs.DeleteKey(key);
	}

	public void Save()
	{
		PlayerPrefs.Save();
	}

	public bool HasKey(string key)
	{
		return PlayerPrefs.HasKey(key);
	}

	public string GetString(string key)
	{
		return PlayerPrefs.GetString(key);
	}

	public void SetString(string key, string value)
	{
		PlayerPrefs.SetString(key, value);
	}

	public void PrintJSLine(string str)
	{
		Debug.Log(str);
	}
}