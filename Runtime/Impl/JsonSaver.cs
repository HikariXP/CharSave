/*
 * Author: CharSui
 * Created On: 2025.09.29
 * Description: 基于Json的持久化实现
 * 使用前需要注册到ModuleManager
 */

using System.Collections.Generic;
using System.IO;
using CharFramework;
using UnityEngine;

public class JsonSaver : CharFramework.CharSave
{
	private string saveFilePath = Application.persistentDataPath + "/CharSaver.json";
	
	public override void Initialize()
	{
		intDict = new Dictionary<string, int>(256);
		floatDict = new Dictionary<string, float>(256);
		stringDict = new Dictionary<string, string>(256);
	}

	public override void Save()
	{
		// 确保目录存在
		string directory = Path.GetDirectoryName(saveFilePath);
		if (!Directory.Exists(directory))
		{
			Directory.CreateDirectory(directory);
		}
		
		// 存储到可序列化的对象中
		var saveData = new SaveData()
		{
			intDict = intDict,
			floatDict = floatDict,
			stringDict = stringDict,
		};
		
		// 序列化为Json并写入文件
		var jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(saveData);
		File.WriteAllText(saveFilePath, jsonString);
		
		CharLogger.Log($"Data saved to {saveFilePath}");
	}
	
	/// <summary>
	/// 注意，加载前会清空所有Runtime数据
	/// </summary>
	public override void Load()
	{
		// 检查文件是否存在
		if (!File.Exists(saveFilePath))
		{
			Debug.LogWarning($"保存文件不存在，将使用新数据: {saveFilePath}");
			Initialize(); // 使用新的空字典
			return;
		}
            
		// 读取文件内容
		string json = File.ReadAllText(saveFilePath);
            
		// 反序列化为对象
		var saveData = Newtonsoft.Json.JsonConvert.DeserializeObject<SaveData>(json);
		
		// 恢复数据到字典
		
		
		
		intDict = saveData.intDict;
		floatDict = saveData.floatDict;
		stringDict = saveData.stringDict;
            
		Debug.Log($"数据加载成功: {saveFilePath}");
	}
}
