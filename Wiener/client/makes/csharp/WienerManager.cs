/// <summary>
/// このファイルは自動生成されたファイルです。
/// </summary>
using System;
using System.IO;
using System.Collections.Generic;

namespace Wiener
{
	/// <summary>
	/// すべてのデータのロードを行って保持して管理するクラス
	/// </summary>
	public partial class WienerManager
	{
		public ConstData Const { get; private set; }
		public ConstJoinData ConstJoin { get; private set; }
		public Dictionary<int, BasicDictionaryData> BasicDictionary { get; private set; }
		public EncryptionData[] Encryption { get; private set; }
		public SampleValidateData[] SampleValidate { get; private set; }
		public GroupData[] Group { get; private set; }
		public Dictionary<int, BasicGroupByData[]> BasicGroupBy { get; private set; }
		public BasicListData[] BasicList { get; private set; }
		public LocalizeData[] Localize { get; private set; }
		public Dictionary<int, TemplateData> Template { get; private set; }
		public TestData[] Test { get; private set; }

		
		/// <summary>
		/// Basicのマスターデータのファイル読み込み
		/// </summary>
		public void LoadBasic(string path)
		{
			Const = ConstData.Create(Path.Combine(path, "Const/Const.bytes"), Const);
			ConstJoin = ConstJoinData.Create(Path.Combine(path, "Const/ConstJoin.bytes"), ConstJoin);
			BasicDictionary = BasicDictionaryData.Create(Path.Combine(path, "Basic/BasicDictionary.bytes"), BasicDictionary);
			Encryption = EncryptionData.Create(Path.Combine(path, "Extra/Encryption.bytes"), Encryption);
			SampleValidate = SampleValidateData.Create(Path.Combine(path, "Sample/SampleValidate.bytes"), SampleValidate);
			BasicGroupBy = BasicGroupByData.Create(Path.Combine(path, "Basic/BasicGroupBy.bytes"), BasicGroupBy);
			BasicList = BasicListData.Create(Path.Combine(path, "Basic/BasicList.bytes"), BasicList);
			Localize = LocalizeData.Create(Path.Combine(path, "Extra/Localize.bytes"), Localize);
			Template = TemplateData.Create(Path.Combine(path, "Template/Template.bytes"), Template);
			Test = TestData.Create(Path.Combine(path, "Extra/Test.bytes"), Test);
		}

		/// <summary>
		/// BasicのPack済みマスターデータのファイル読み込み
		/// </summary>
		public void LoadBasicPack(string path)
		{
			var buffer = File.ReadAllBytes(path);
			LoadBasicPack(buffer);
		}

		/// <summary>
		/// BasicのPack済みマスターデータのバイナリ読み込み
		/// </summary>
		public void LoadBasicPack(byte[] buffer)
		{
			var reader = new WienerDataReader(buffer, "basic", YamlHash);
			Const = ConstData.Create(reader, Const);
			ConstJoin = ConstJoinData.Create(reader, ConstJoin);
			BasicDictionary = BasicDictionaryData.Create(reader, BasicDictionary);
			Encryption = EncryptionData.Create(reader, Encryption);
			SampleValidate = SampleValidateData.Create(reader, SampleValidate);
			BasicGroupBy = BasicGroupByData.Create(reader, BasicGroupBy);
			BasicList = BasicListData.Create(reader, BasicList);
			Localize = LocalizeData.Create(reader, Localize);
			Template = TemplateData.Create(reader, Template);
			Test = TestData.Create(reader, Test);
		}


		/// <summary>
		/// Groupのマスターデータのファイル読み込み
		/// </summary>
		public void LoadGroup(string path)
		{
			var buffer = File.ReadAllBytes(path);
			var reader = new WienerDataReader(buffer);
			Group = GroupData.Create(reader, Group);
		}

		/// <summary>
		/// GroupのPack済みマスターデータ読み込み
		/// </summary>
		public void LoadGroupPack(string path, string excelName)
		{
			var reader = new WienerDataReader(path, excelName, YamlHash);
			Group = GroupData.Create(reader, Group);
		}

		/// <summary>
		/// データ改ざんデリゲート登録
		/// </summary>
		public static void SetFalsifyDelegate(Action<string> onFalsify)
		{
			onFalsifyDelegate = onFalsify;
		}
	}
}
