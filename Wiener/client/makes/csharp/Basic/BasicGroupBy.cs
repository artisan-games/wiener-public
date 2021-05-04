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
	/// BasicGroupByのデータ本体
	/// </summary>
	public partial class BasicGroupByData
	{
		public int Id { get; private set; }
		public int IntValue { get; private set; }

		
		public static Dictionary<int, BasicGroupByData[]> Create(string path, Dictionary<int, BasicGroupByData[]> value)
		{
			var buffer = File.ReadAllBytes(path);
			var reader = new WienerDataReader(buffer);
			return Create(reader, value);
		}

		public static Dictionary<int, BasicGroupByData[]> Create(WienerDataReader reader, Dictionary<int, BasicGroupByData[]> value)
		{
			var length = reader.ReadUInt32();
			if (value == null)
			{
				value = new Dictionary<int, BasicGroupByData[]>();
			}
			else
			{
				value.Clear();
			}
			for (var i = 0; i < length; ++i)
			{
				var key = reader.ReadInt32();
				var size = reader.ReadInt32();
				if (value.TryGetValue(key, out var val))
				{
					if (val.Length == size)
					{
						for (var j = 0; j < size; ++j)
						{
							val[j].Load(reader);
						}
					}
					else
					{
						val = new BasicGroupByData[size];
						for (var j = 0; j < size; ++j)
						{
							val[j] = new BasicGroupByData();
							val[j].Load(reader);
						}
						value[key] = val;
					}
				}
				else
				{
					val = new BasicGroupByData[size];
					for (var j = 0; j < size; ++j)
					{
						val[j] = new BasicGroupByData();
						val[j].Load(reader);
					}
					value.Add(key, val);
				}
			}
			return value;
		}

		void Load(WienerDataReader reader)
		{
			Id = reader.ReadInt32();
			IntValue = reader.ReadInt32();
		}
	}
}
