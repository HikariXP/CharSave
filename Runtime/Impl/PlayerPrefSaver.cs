/*
 * Author: CharSui
 * Created On: 2025.09.29
 * Description: 接去PlayerPrefs存储数据
 */

using CharFramework;
using UnityEngine;

public class PlayerPrefSaver : CharSave
{
	public override void Initialize()
	{
		// PlayerPrefs不需要初始化
	}

	public override void Save()
	{
		PlayerPrefs.Save();
	}

	public override void Load()
	{
		// 没有逻辑，PlayerPrefs自带加载
	}

	public override void Set(string key, int value)
	{
		PlayerPrefs.SetInt(key, value);
	}

	public override void Set(string key, float value)
	{
		PlayerPrefs.SetFloat(key, value);
	}

	public override void Set(string key, string value)
	{
		PlayerPrefs.SetString(key, value);
	}

	public override void Get(string key, out int value)
	{
		value = PlayerPrefs.GetInt(key);
	}

	public override void Get(string key, out float value)
	{
		value = PlayerPrefs.GetFloat(key);
	}

	public override void Get(string key, out string value)
	{
		value = PlayerPrefs.GetString(key);
	}

	public override bool ContainsKey(string key)
	{
		return PlayerPrefs.HasKey(key);
	}

	public override void DeleteKey(string key)
	{
		PlayerPrefs.DeleteKey(key);
	}

	public override void Clear()
	{
		PlayerPrefs.DeleteAll();
	}
}
