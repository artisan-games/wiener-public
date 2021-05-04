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
	/// Groupのデータ本体
	/// </summary>
	public partial class GroupData
	{
		public int Id { get; private set; }
		public string StringValue { get; private set; }

		
		public static GroupData[] Create(string path, GroupData[] value)
		{
			var buffer = File.ReadAllBytes(path);
			var reader = new WienerDataReader(buffer);
			return Create(reader, value);
		}

		public static GroupData[] Create(WienerDataReader reader, GroupData[] value)
		{
			var size = reader.ReadInt32();
			if (value == null || value.Length != size)
			{
				value = new GroupData[size];
			}
			for (var i = 0; i < value.Length; ++i)
			{
				value[i] = new GroupData();
				value[i].Load(reader);
			}
			return value;
		}

		void Load(WienerDataReader reader)
		{
			Id = reader.ReadInt32();
			StringValue = reader.ReadString();
		}
	}
}
