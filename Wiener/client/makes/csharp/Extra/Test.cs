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
	/// Testのデータ本体
	/// </summary>
	public partial class TestData
	{
		public int Id { get; private set; }
		public string StringValue { get; private set; }

		
		public static TestData[] Create(string path, TestData[] value)
		{
			var buffer = File.ReadAllBytes(path);
			var reader = new WienerDataReader(buffer);
			return Create(reader, value);
		}

		public static TestData[] Create(WienerDataReader reader, TestData[] value)
		{
			var size = reader.ReadInt32();
			if (value == null || value.Length != size)
			{
				value = new TestData[size];
			}
			for (var i = 0; i < value.Length; ++i)
			{
				value[i] = new TestData();
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
