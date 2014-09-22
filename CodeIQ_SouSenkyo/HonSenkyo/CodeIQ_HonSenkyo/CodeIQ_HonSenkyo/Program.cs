using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeIQ_HonSenkyo
{
	class Program
	{
		const int MAX_ITEM = 10;

		static void Main(string[] args)
		{
			var lines = new List<string>();

			while (true)
			{
				var line = Console.ReadLine();

				if (line.Length > MAX_ITEM)
				{
					Console.WriteLine("列の最大値は{0}文字です", MAX_ITEM);
					continue;
				}

				if (lines.Count > 0)
				{
					if (string.IsNullOrEmpty(line))
					{
						Calculate(lines);
						lines.Clear();
						Console.WriteLine();
						continue;
					}
					if (!line.All(x => x == 'O' || x == 'X'))
					{
						Console.WriteLine("無効な文字が含まれています");
						continue;
					}
					if (lines.Count > 0 && lines.Any(x => x.Length != line.Length))
					{
						Console.WriteLine("長さの異なる行が存在します");
						continue;
					}
					if (lines.Count == MAX_ITEM)
					{
						Console.WriteLine("行の最大値は{0}文字です", MAX_ITEM);
						continue;
					}
				}
				else
				{
					if (string.IsNullOrEmpty(line))
					{
						Console.WriteLine("空文字は入力できません");
						continue;
					}
				}

				lines.Add(line);
			}
		}

		static void Calculate(List<string> lines)
		{
			var matrix = lines
				.Select(s => s.Select(c => c == 'O' ? true : false).ToArray())
				.ToArray();

			for (int i = 0; i < matrix.Length; i++)
			{ 
			}

			lines.ForEach(x => Console.WriteLine(x));
		}
	}
}
