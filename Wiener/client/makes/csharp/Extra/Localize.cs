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
	/// Localizeのデータ本体
	/// </summary>
	public partial class LocalizeData
	{
		public string Jpn { get; private set; }
		public string Eng { get; private set; }
		public string Chi { get; private set; }

		
		public static LocalizeData[] Create(string path, LocalizeData[] value)
		{
			var buffer = File.ReadAllBytes(path);
			var reader = new WienerDataReader(buffer);
			return Create(reader, value);
		}

		public static LocalizeData[] Create(WienerDataReader reader, LocalizeData[] value)
		{
			var size = reader.ReadInt32();
			if (value == null || value.Length != size)
			{
				value = new LocalizeData[size];
			}
			for (var i = 0; i < value.Length; ++i)
			{
				value[i] = new LocalizeData();
				value[i].Load(reader);
			}
			return value;
		}

		void Load(WienerDataReader reader)
		{
			Jpn = reader.ReadString();
			Eng = reader.ReadString();
			Chi = reader.ReadString();
		}
	}
}
