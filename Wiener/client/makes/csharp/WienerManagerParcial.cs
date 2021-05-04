/// <summary>
/// このファイルは自動生成されたファイルです。
/// </summary>
using System;

namespace Wiener
{
	public partial class WienerManager
	{
		static Action<string> onFalsifyDelegate;
		static readonly string YamlHash = "77bed1d5c9e0f9a951053494251e263b";

		public static byte DecodeByte(int value, int hash, int key, string log)
		{
			var temp = value ^ key;
			if (!CheckSum(temp, hash))
			{
				onFalsifyDelegate?.Invoke(log);
			}
			return (byte)~temp;
		}

		public static short DecodeShort(int value, int hash, int key, string log)
		{
			var temp = value ^ key;
			if (!CheckSum(temp, hash))
			{
				onFalsifyDelegate?.Invoke(log);
			}
			return (short)~temp;
		}

		public static ushort DecodeUShort(int value, int hash, int key, string log)
		{
			var temp = value ^ (uint)key;
			if (!CheckSum(temp, hash))
			{
				onFalsifyDelegate?.Invoke(log);
			}
			return (ushort)~temp;
		}

		public static int DecodeInt(int value, int hash, int key, string log)
		{
			var temp = value ^ key;
			if (!CheckSum(temp, hash))
			{
				onFalsifyDelegate?.Invoke(log);
			}
			return ~temp;
		}

		public static uint DecodeUInt(uint value, int hash, int key, string log)
		{
			var temp = value ^ (uint)key;
			if (!CheckSum(temp, hash))
			{
				onFalsifyDelegate?.Invoke(log);
			}
			return ~temp;
		}

		public static long DecodeLong(long value, int hash, int key, string log)
		{
			var temp = value ^ key;
			if (!CheckSum(temp, hash))
			{
				onFalsifyDelegate?.Invoke(log);
			}
			return ~temp;
		}

		public static ulong DecodeULong(ulong value, int hash, int key, string log)
		{
			var temp = value ^ (uint)key;
			if (!CheckSum(temp, hash))
			{
				onFalsifyDelegate?.Invoke(log);
			}
			return ~temp;
		}

		public static float DecodeFloat(int value, int hash, int key, string log)
		{
			var temp = value ^ key;
			if (!CheckSum(temp, hash))
			{
				onFalsifyDelegate?.Invoke(log);
			}
			return Int32BitsToSingle(~temp);
		}

		public static double DecodeDouble(long value, int hash, int key, string log)
		{
			var temp = value ^ key;
			if (!CheckSum(temp, hash))
			{
				onFalsifyDelegate?.Invoke(log);
			}
			return Int64BitsToDouble(~temp);
		}

		static bool CheckSum(int value, int hash)
		{
			var temp = (int)(value >> 0  & 0xff)
					 + (int)(value >> 8  & 0xff)
					 + (int)(value >> 16 & 0xff)
					 + (int)(value >> 24 & 0xff);
			return temp == hash;
		}

		static bool CheckSum(uint value, int hash)
		{
			var temp = (int)(value >> 0  & 0xff)
					 + (int)(value >> 8  & 0xff)
					 + (int)(value >> 16 & 0xff)
					 + (int)(value >> 24 & 0xff);
			return temp == hash;
		}

		static bool CheckSum(long value, int hash)
		{
			var temp = (int)(value >> 0  & 0xff)
					 + (int)(value >> 8  & 0xff)
					 + (int)(value >> 16 & 0xff)
					 + (int)(value >> 24 & 0xff)
					 + (int)(value >> 32 & 0xff)
					 + (int)(value >> 40 & 0xff)
					 + (int)(value >> 48 & 0xff)
					 + (int)(value >> 56 & 0xff);
			return temp == hash;
		}

		static bool CheckSum(ulong value, int hash)
		{
			var temp = (int)(value >> 0  & 0xff)
					 + (int)(value >> 8  & 0xff)
					 + (int)(value >> 16 & 0xff)
					 + (int)(value >> 24 & 0xff)
					 + (int)(value >> 32 & 0xff)
					 + (int)(value >> 40 & 0xff)
					 + (int)(value >> 48 & 0xff)
					 + (int)(value >> 56 & 0xff);
			return temp == hash;
		}

		static unsafe float Int32BitsToSingle(int value)
		{
			return *(float*)(&value);
		}

		static unsafe double Int64BitsToDouble(long value)
		{
			return *(double*)(&value);
		}
	}
}
