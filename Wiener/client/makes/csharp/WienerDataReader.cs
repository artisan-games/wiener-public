/// <summary>
/// このファイルは自動生成されたファイルです。
/// </summary>
using System;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;

namespace Wiener
{
	public class WienerDataReader
	{
		public enum SeekType
		{
			Begin,
			Current,
			End,
		}

		byte[] buffer;

		public int Position { get; private set; }
		public bool End => (buffer == null) ? true : Position == buffer.Length;

		public WienerDataReader(string path, string key, string yamlHash)
		{
			using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read))
			{
				this.buffer = CreateBuffer(fs, key, yamlHash);
			}
		}
		public WienerDataReader(byte[] buffer, string key, string yamlHash)
		{
			using (var ms = new MemoryStream(buffer))
			{
				this.buffer = CreateBuffer(ms, key, yamlHash);
			}
		}
		public WienerDataReader(byte[] buffer)
		{
			this.buffer = buffer;
		}
		public void Seek(int offset, SeekType type)
		{
			switch (type)
			{
				case SeekType.Begin:
					Position = offset;
					break;
				case SeekType.Current:
					Position += offset;
					break;
				case SeekType.End:
					Position = buffer.Length - 1 + offset;
					break;
			}
		}

		public bool ReadBoolean()
		{
			Position += sizeof(bool);
			return BitConverter.ToBoolean(buffer, Position - sizeof(bool));
		}

		public byte ReadByte()
		{
			Position += sizeof(byte);
			return buffer[Position - sizeof(byte)];
		}

		public Int16 ReadInt16()
		{
			Position += sizeof(Int16);
			return BitConverter.ToInt16(buffer, Position - sizeof(Int16));
		}

		public UInt16 ReadUInt16()
		{
			Position += sizeof(UInt16);
			return BitConverter.ToUInt16(buffer, Position - sizeof(UInt16));
		}

		public Int32 ReadInt32()
		{
			Position += sizeof(Int32);
			return BitConverter.ToInt32(buffer, Position - sizeof(Int32));
		}

		public UInt32 ReadUInt32()
		{
			Position += sizeof(UInt32);
			return BitConverter.ToUInt32(buffer, Position - sizeof(UInt32));
		}

		public Int64 ReadInt64()
		{
			Position += sizeof(Int64);
			return BitConverter.ToInt64(buffer, Position - sizeof(Int64));
		}

		public UInt64 ReadUInt64()
		{
			Position += sizeof(UInt64);
			return BitConverter.ToUInt64(buffer, Position - sizeof(UInt64));
		}

		public float ReadSingle()
		{
			Position += sizeof(float);
			return BitConverter.ToSingle(buffer, Position - sizeof(float));
		}

		public double ReadDouble()
		{
			Position += sizeof(double);
			return BitConverter.ToDouble(buffer, Position - sizeof(double));
		}

		public string ReadString()
		{
			var length = ReadInt32();
			if (length == 0) return string.Empty;
			Position += length;
			return Encoding.UTF8.GetString(buffer, Position - length, length);
		}

		public DateTime? ReadDateTime()
		{
			var str = ReadString();
			if (string.IsNullOrEmpty(str)) return null;
			return DateTime.Parse(str);
		}

		public bool ReadBooleanNoSeek()
		{
			return BitConverter.ToBoolean(buffer, Position);
		}

		public byte ReadByteNoSeek()
		{
			return buffer[Position];
		}

		public Int16 ReadInt16NoSeek()
		{
			return BitConverter.ToInt16(buffer, Position);
		}

		public UInt16 ReadUInt16NoSeek()
		{
			return BitConverter.ToUInt16(buffer, Position);
		}

		public Int32 ReadInt32NoSeek()
		{
			return BitConverter.ToInt32(buffer, Position);
		}

		public UInt32 ReadUInt32NoSeek()
		{
			return BitConverter.ToUInt32(buffer, Position);
		}

		public Int64 ReadInt64NoSeek()
		{
			return BitConverter.ToInt64(buffer, Position);
		}

		public UInt64 ReadUInt64NoSeek()
		{
			return BitConverter.ToUInt64(buffer, Position);
		}

		public float ReadSingleNoSeek()
		{
			return BitConverter.ToSingle(buffer, Position);
		}

		public double ReadDoubleNoSeek()
		{
			return BitConverter.ToDouble(buffer, Position);
		}

		public string ReadStringNoSeek()
		{
			var length = ReadInt32NoSeek();
			if (length == 0) return string.Empty;
			return Encoding.UTF8.GetString(buffer, Position + sizeof(Int32), length);
		}

		static byte[] CreateBuffer(Stream stream, string key, string yamlHash)
		{
			var reader1 = new BinaryReader(stream);
			if (!IsCheckYamlHash(yamlHash, reader1.ReadBytes(16)))
			{
				throw new Exception("Failed. Hash in yaml does not match");
			}

			var dataHash = reader1.ReadBytes(16);
			if (!IsCheckMD5(dataHash, reader1.BaseStream))
			{
				throw new Exception("Failed. File corrupted");
			}
			reader1.BaseStream.Seek(32, SeekOrigin.Begin);

			var reader2 = new WienerDataReader(reader1.ReadBytes(reader1.ReadInt32()));
			var length = reader2.ReadInt32();
			for (int i = 0; i < length; ++i)
			{
				var name = reader2.ReadString();
				var offset = reader2.ReadInt32();
				var size = reader2.ReadInt32();
				if (name == key)
				{
					reader1.BaseStream.Seek(offset, SeekOrigin.Begin);
					return Decode(reader1.ReadBytes(size));
				}
			}
			throw new Exception($"Failed not find key[{key}]");
		}
		static byte[] Decode(byte[] src)
		{
			var length = BitConverter.ToInt32(src, src.Length - 4);
			var bytes = new byte[length];
			using (var ms = new MemoryStream(src))
			{
				using (var gs = new GZipStream(ms, CompressionMode.Decompress))
				{
					gs.Read(bytes, 0, bytes.Length);
				}
			}

			return bytes;
		}

		static bool IsCheckYamlHash(string hash, byte[] bytys)
		{
			var sb = new StringBuilder();
			foreach (var c in bytys)
			{
				sb.Append(c.ToString("x2"));
			}
			return hash == sb.ToString();
		}

		static bool IsCheckMD5(byte[] src, Stream stream)
		{
			var md5 = System.Security.Cryptography.MD5.Create();
			var dst = md5.ComputeHash(stream);
			return src.SequenceEqual(dst);
		}
	}
}
