/*
 * Author: CharSui
 * Created On: 2025.09.28
 * Description: 基础保存系统
 * 按理来说，会比PlayerPref多了一些自主性，开放了保存逻辑和读取时机等的自由度
 * 注意：使用Get的时候需要有一个概念，你得知道没有Key的时候，默认值是什么
 */

using System;
using System.Collections.Generic;
using CharFramework.Module;

namespace CharFramework
{
    public abstract class CharSave : IModule
	{
		protected Dictionary<string, int> intDict;
		protected Dictionary<string, float> floatDict;
		protected Dictionary<string, string> stringDict;
		
		/// <summary>
		/// 初始化
		/// </summary>
		public abstract void Initialize();
		
		/// <summary>
		/// 保存持久化数据
		/// </summary>
		public abstract void Save();

		/// <summary>
		/// 加载已有的持久化数据
		/// </summary>
		public abstract void Load();
		
		public virtual void Set(string key, int value)
		{
			intDict[key] = value;
		}

		public virtual void Set(string key, float value)
		{
			floatDict[key] = value;
		}
		
		public virtual void Set(string key, string value)
		{
			stringDict[key] = value;
		}
		
		public virtual void Get(string key, out int value)
		{
			value = intDict.TryGetValue(key, out var v) ? v : 0;
		}
		
		public virtual void Get(string key, out float value)
		{
			value = floatDict.TryGetValue(key, out var v) ? v : 0.0f;
		}
		
		public virtual void Get(string key, out string value)
		{
			value = stringDict.TryGetValue(key, out var v) ? v : string.Empty;
		}

		/// <summary>
		/// 这里的实现是避免了同key可以存储不同类型的值
		/// </summary>
		/// <param name="key"></param>
		/// <returns></returns>
		public bool ContainsKey(string key)
		{
			return intDict.ContainsKey(key) || floatDict.ContainsKey(key) || stringDict.ContainsKey(key);
		}

		public void DeleteKey(string key)
		{
			intDict.Remove(key);
			floatDict.Remove(key);
			stringDict.Remove(key);
		}
		
		public void Clear()
		{
			if (intDict == null || floatDict == null || stringDict == null)
			{
				CharLogger.Log("Clear SaveData failed, dict is null");
				return;
			}

			intDict.Clear();
			floatDict.Clear();
			stringDict.Clear();
		}
	}
    
    [Serializable]
    internal struct SaveData
	{
		public Dictionary<string, int> intDict;
		public Dictionary<string, float> floatDict;
		public Dictionary<string, string> stringDict;
	}
}


