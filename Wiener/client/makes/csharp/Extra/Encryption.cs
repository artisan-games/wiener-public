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
	/// Encryptionのデータ本体
	/// </summary>
	public partial class EncryptionData
	{
		static readonly string ByteEncryptionEncryptionError = "Wiener.EncryptionData.ByteEncryption alteration was detected.";
		static readonly string ShortEncryptionEncryptionError = "Wiener.EncryptionData.ShortEncryption alteration was detected.";
		static readonly string UShortEncryptionEncryptionError = "Wiener.EncryptionData.UShortEncryption alteration was detected.";
		static readonly string IntEncryptionEncryptionError = "Wiener.EncryptionData.IntEncryption alteration was detected.";
		static readonly string UIntEncryptionEncryptionError = "Wiener.EncryptionData.UIntEncryption alteration was detected.";
		static readonly string LongEncryptionEncryptionError = "Wiener.EncryptionData.LongEncryption alteration was detected.";
		static readonly string ULongEncryptionEncryptionError = "Wiener.EncryptionData.ULongEncryption alteration was detected.";
		static readonly string FloatEncryptionEncryptionError = "Wiener.EncryptionData.FloatEncryption alteration was detected.";
		static readonly string DoubleEncryptionEncryptionError = "Wiener.EncryptionData.DoubleEncryption alteration was detected.";
		static readonly int ByteEncryptionEncryptionKey = 164565;
		static readonly int ShortEncryptionEncryptionKey = 697565;
		static readonly int UShortEncryptionEncryptionKey = 697164;
		static readonly int IntEncryptionEncryptionKey = 697164565;
		static readonly int UIntEncryptionEncryptionKey = 69164565;
		static readonly int LongEncryptionEncryptionKey = 798774678;
		static readonly int ULongEncryptionEncryptionKey = 7987748;
		static readonly int FloatEncryptionEncryptionKey = 17134823;
		static readonly int DoubleEncryptionEncryptionKey = 8979789;
		int ByteEncryptionVariable;
		int ShortEncryptionVariable;
		int UShortEncryptionVariable;
		int IntEncryptionVariable;
		uint UIntEncryptionVariable;
		long LongEncryptionVariable;
		ulong ULongEncryptionVariable;
		int FloatEncryptionVariable;
		long DoubleEncryptionVariable;
		int ByteEncryptionHash;
		int ShortEncryptionHash;
		int UShortEncryptionHash;
		int IntEncryptionHash;
		int UIntEncryptionHash;
		int LongEncryptionHash;
		int ULongEncryptionHash;
		int FloatEncryptionHash;
		int DoubleEncryptionHash;
		
		public byte ByteEncryption => WienerManager.DecodeByte(ByteEncryptionVariable, ByteEncryptionHash, ByteEncryptionEncryptionKey, ByteEncryptionEncryptionError);
		public short ShortEncryption => WienerManager.DecodeShort(ShortEncryptionVariable, ShortEncryptionHash, ShortEncryptionEncryptionKey, ShortEncryptionEncryptionError);
		public ushort UShortEncryption => WienerManager.DecodeUShort(UShortEncryptionVariable, UShortEncryptionHash, UShortEncryptionEncryptionKey, UShortEncryptionEncryptionError);
		public int IntEncryption => WienerManager.DecodeInt(IntEncryptionVariable, IntEncryptionHash, IntEncryptionEncryptionKey, IntEncryptionEncryptionError);
		public uint UIntEncryption => WienerManager.DecodeUInt(UIntEncryptionVariable, UIntEncryptionHash, UIntEncryptionEncryptionKey, UIntEncryptionEncryptionError);
		public long LongEncryption => WienerManager.DecodeLong(LongEncryptionVariable, LongEncryptionHash, LongEncryptionEncryptionKey, LongEncryptionEncryptionError);
		public ulong ULongEncryption => WienerManager.DecodeULong(ULongEncryptionVariable, ULongEncryptionHash, ULongEncryptionEncryptionKey, ULongEncryptionEncryptionError);
		public float FloatEncryption => WienerManager.DecodeFloat(FloatEncryptionVariable, FloatEncryptionHash, FloatEncryptionEncryptionKey, FloatEncryptionEncryptionError);
		public double DoubleEncryption => WienerManager.DecodeDouble(DoubleEncryptionVariable, DoubleEncryptionHash, DoubleEncryptionEncryptionKey, DoubleEncryptionEncryptionError);

		
		public static EncryptionData[] Create(string path, EncryptionData[] value)
		{
			var buffer = File.ReadAllBytes(path);
			var reader = new WienerDataReader(buffer);
			return Create(reader, value);
		}

		public static EncryptionData[] Create(WienerDataReader reader, EncryptionData[] value)
		{
			var size = reader.ReadInt32();
			if (value == null || value.Length != size)
			{
				value = new EncryptionData[size];
			}
			for (var i = 0; i < value.Length; ++i)
			{
				value[i] = new EncryptionData();
				value[i].Load(reader);
			}
			return value;
		}

		void Load(WienerDataReader reader)
		{
			ByteEncryptionVariable = reader.ReadInt32();
			ShortEncryptionVariable = reader.ReadInt32();
			UShortEncryptionVariable = reader.ReadInt32();
			IntEncryptionVariable = reader.ReadInt32();
			UIntEncryptionVariable = reader.ReadUInt32();
			LongEncryptionVariable = reader.ReadInt64();
			ULongEncryptionVariable = reader.ReadUInt64();
			FloatEncryptionVariable = reader.ReadInt32();
			DoubleEncryptionVariable = reader.ReadInt64();
			ByteEncryptionHash = reader.ReadInt32();
			ShortEncryptionHash = reader.ReadInt32();
			UShortEncryptionHash = reader.ReadInt32();
			IntEncryptionHash = reader.ReadInt32();
			UIntEncryptionHash = reader.ReadInt32();
			LongEncryptionHash = reader.ReadInt32();
			ULongEncryptionHash = reader.ReadInt32();
			FloatEncryptionHash = reader.ReadInt32();
			DoubleEncryptionHash = reader.ReadInt32();
		}
	}
}
