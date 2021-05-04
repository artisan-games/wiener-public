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
	/// Templateのデータ本体
	/// </summary>
	public partial class TemplateData
	{
		public int Id { get; private set; }
		public string BoolValue { get; private set; }
		public byte ByteValue { get; private set; }
		public short ShortValue { get; private set; }
		public ushort UShortValue { get; private set; }
		public int IntValue { get; private set; }
		public uint UIntValue { get; private set; }
		public long LongValue { get; private set; }
		public ulong ULongValue { get; private set; }
		public float FloatValue { get; private set; }
		public double DoubleValue { get; private set; }
		public string StringValue { get; private set; }
		public DateTime? DatetimeValue { get; private set; }
		public GenderType EnumValue { get; private set; }

		
		public static Dictionary<int, TemplateData> Create(string path, Dictionary<int, TemplateData> value)
		{
			var buffer = File.ReadAllBytes(path);
			var reader = new WienerDataReader(buffer);
			return Create(reader, value);
		}

		public static Dictionary<int, TemplateData> Create(WienerDataReader reader, Dictionary<int, TemplateData> value)
		{
			var length = reader.ReadInt32();
			if (value == null)
			{
				value = new Dictionary<int, TemplateData>();
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
					val = new TemplateData();
					val.Load(reader);
					value.Add(key, val);
				}
			}
			return value;
		}

		void Load(WienerDataReader reader)
		{
			Id = reader.ReadInt32();
			BoolValue = reader.ReadString();
			ByteValue = reader.ReadByte();
			ShortValue = reader.ReadInt16();
			UShortValue = reader.ReadUInt16();
			IntValue = reader.ReadInt32();
			UIntValue = reader.ReadUInt32();
			LongValue = reader.ReadInt64();
			ULongValue = reader.ReadUInt64();
			FloatValue = reader.ReadSingle();
			DoubleValue = reader.ReadDouble();
			StringValue = reader.ReadString();
			DatetimeValue = reader.ReadDateTime();
			EnumValue = (GenderType)reader.ReadInt32();
		}
	}
}
