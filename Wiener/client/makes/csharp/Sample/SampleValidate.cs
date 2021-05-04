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
	/// SampleValidateのデータ本体
	/// </summary>
	public partial class SampleValidateData
	{
		public int Id { get; private set; }
		public int ExistsValue { get; private set; }
		public GenderType EnumValue { get; private set; }
		public int IntValue { get; private set; }
		public long LongValue { get; private set; }
		public float FloatValue { get; private set; }
		public string StringValue { get; private set; }

		
		public static SampleValidateData[] Create(string path, SampleValidateData[] value)
		{
			var buffer = File.ReadAllBytes(path);
			var reader = new WienerDataReader(buffer);
			return Create(reader, value);
		}

		public static SampleValidateData[] Create(WienerDataReader reader, SampleValidateData[] value)
		{
			var size = reader.ReadInt32();
			if (value == null || value.Length != size)
			{
				value = new SampleValidateData[size];
			}
			for (var i = 0; i < value.Length; ++i)
			{
				value[i] = new SampleValidateData();
				value[i].Load(reader);
			}
			return value;
		}

		void Load(WienerDataReader reader)
		{
			Id = reader.ReadInt32();
			ExistsValue = reader.ReadInt32();
			EnumValue = (GenderType)reader.ReadInt32();
			IntValue = reader.ReadInt32();
			LongValue = reader.ReadInt64();
			FloatValue = reader.ReadSingle();
			StringValue = reader.ReadString();
		}
	}
}
