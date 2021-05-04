/// <summary>
/// このファイルは自動生成されたファイルです。
/// クラスを拡張したい場合は別ファイルを用意しparcial宣言して拡張してください。
/// </summary>
using System;
using System.IO;
using System.Collections.Generic;

namespace Wiener
{
	/// <summary>
	/// BasicDictionaryのデータ本体
	/// </summary>
	public partial class BasicDictionaryData
	{
		public int Id { get; private set; }
		public string Name { get; private set; }
		public int GroupId { get; private set; }

		
		public static Dictionary<int, BasicDictionaryData> Create(string path, Dictionary<int, BasicDictionaryData> value)
		{
			var buffer = File.ReadAllBytes(path);
			var reader = new WienerDataReader(buffer);
			return Create(reader, value);
		}

		public static Dictionary<int, BasicDictionaryData> Create(WienerDataReader reader, Dictionary<int, BasicDictionaryData> value)
		{
			var length = reader.ReadInt32();
			if (value == null)
			{
				value = new Dictionary<int, BasicDictionaryData>();
			}
			else
			{
				value.Clear();
			}
			for (var i = 0; i < length; ++i)
			{
				var key = reader.ReadInt32NoSeek();
				if (value.TryGetValue(key, out var val))
				{
					val.Load(reader);
				}
				else
				{
					val = new BasicDictionaryData();
					val.Load(reader);
					value.Add(key, val);
				}
			}
			return value;
		}

		void Load(WienerDataReader reader)
		{
			Id = reader.ReadInt32();
			Name = reader.ReadString();
			GroupId = reader.ReadInt32();
		}
	}
}
