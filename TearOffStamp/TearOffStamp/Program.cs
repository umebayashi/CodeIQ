using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TearOffStamp
{
	class Program
	{
		static void Main(string[] args)
		{
			var path = GetDataFilePath("sample.in.txt");
			var lines = File.ReadAllLines(path);
			for (int i = 0; i < lines.Length; i++)
			{
				if (i == 0)
				{
					Console.WriteLine("データセット数：{0}", lines[i]);
				}
				else
				{
					var items = lines[i].Split(' ');
					Contract.Requires(items.Length == 3);

					var vLength = int.Parse(items[0]);
					var hLength = int.Parse(items[1]);
					var count = int.Parse(items[2]);

					var patterns = CountTearOffPatterns(vLength, hLength, count);

					Console.WriteLine("縦枚数：{0} 横枚数：{1} 切り取り枚数：{2} => パターン数：{3}",
						vLength,
						hLength,
						count,
						patterns);
				}
			}
		}

		/// <summary>
		/// テストデータのファイルパスを取得
		/// </summary>
		/// <param name="fileName"></param>
		/// <returns></returns>
		static string GetDataFilePath(string fileName)
		{
			var asm = Assembly.GetEntryAssembly();
			var path = Path.Combine(Path.GetDirectoryName(asm.Location), fileName);

			return path;
		}

		/// <summary>
		/// 切手の座標を示す構造体
		/// </summary>
		struct Coordinate
		{
			public Coordinate(int x, int y)
			{
				X = x;
				Y = y;
			}

			/// <summary>
			/// 縦位置
			/// </summary>
			public int X;

			/// <summary>
			/// 横位置
			/// </summary>
			public int Y;
		}

		/// <summary>
		/// 切手の切り取り方のパターン数を計算する
		/// </summary>
		/// <param name="vLength">切手シートの縦の枚数</param>
		/// <param name="hLength">切手シートの横の枚数</param>
		/// <param name="count">切り取る切手の枚数</param>
		/// <returns>切手の切り取り方のパターン数</returns>
		static int CountTearOffPatterns(int vLength, int hLength, int count)
		{
			for (int y = 0; y < vLength; y++)
			{
				for (int x = 0; x < hLength; x++)
				{
					var start = new Coordinate(x, y);
				}
			}
			
			return -1;
		}
	}
}
