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
	/// BasicListのデータ本体
	/// </summary>
	public partial class BasicListData
	{
		public int Id { get; private set; }
		public int IntValue { get; private set; }
		public string Detail { get; private set; }

		
		public static BasicListData[] Create(string path, BasicListData[] value)
		{
			var buffer = File.ReadAllBytes(path);
			var reader = new WienerDataReader(buffer);
			return Create(reader, value);
		}

		public static BasicListData[] Create(WienerDataReader reader, BasicListData[] value)
		{
			var size = reader.ReadInt32();
			if (value == null || value.Length != size)
			{
				value = new BasicListData[size];
			}
			for (var i = 0; i < value.Length; ++i)
			{
				value[i] = new BasicListData();
				value[i].Load(reader);
			}
			return value;
		}

		void Load(WienerDataReader reader)
		{
			Id = reader.ReadInt32();
			IntValue = reader.ReadInt32();
			Detail = reader.ReadString();
		}
	}
}
