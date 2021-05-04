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
	/// Constのデータ本体
	/// </summary>
	public partial class ConstData
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

		
		public static ConstData Create(string path, ConstData value)
		{
			var buffer = File.ReadAllBytes(path);
			var reader = new WienerDataReader(buffer);
			return Create(reader, value);
		}

		public static ConstData Create(WienerDataReader reader, ConstData value)
		{
			if (value == null)
			{
				value = new ConstData();
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
		}
	}
}
