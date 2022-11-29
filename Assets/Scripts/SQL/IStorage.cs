public interface IStorage
{
	void Remove(string key);
	void Save();
	bool HasKey(string key);
	string GetString(string key);
	void SetString(string key, string value);
	void PrintJSLine(string str);
}
