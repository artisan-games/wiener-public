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
	/// ConstJoinのデータ本体
	/// </summary>
	public partial class ConstJoinData
	{
		public bool BoolValue { get; private set; }
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
		public bool BoolValue2 { get; private set; }
		public byte ByteValue2 { get; private set; }
		public short ShortValue2 { get; private set; }
		public ushort UShortValue2 { get; private set; }
		public int IntValue2 { get; private set; }
		public uint UIntValue2 { get; private set; }
		public long LongValue2 { get; private set; }
		public ulong ULongValue2 { get; private set; }
		public float FloatValue2 { get; private set; }
		public double DoubleValue2 { get; private set; }
		public string StringValue2 { get; private set; }

		
		public static ConstJoinData Create(string path, ConstJoinData value)
		{
			var buffer = File.ReadAllBytes(path);
			var reader = new WienerDataReader(buffer);
			return Create(reader, value);
		}

		public static ConstJoinData Create(WienerDataReader reader, ConstJoinData value)
		{
			if (value == null)
			{
				value = new ConstJoinData();
			}
			value.Load(reader);
			return value;
		}

		void Load(WienerDataReader reader)
		{
			BoolValue = reader.ReadBoolean();
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
			BoolValue2 = reader.ReadBoolean();
			ByteValue2 = reader.ReadByte();
			ShortValue2 = reader.ReadInt16();
			UShortValue2 = reader.ReadUInt16();
			IntValue2 = reader.ReadInt32();
			UIntValue2 = reader.ReadUInt32();
			LongValue2 = reader.ReadInt64();
			ULongValue2 = reader.ReadUInt64();
			FloatValue2 = reader.ReadSingle();
			DoubleValue2 = reader.ReadDouble();
			StringValue2 = reader.ReadString();
		}
	}
}
