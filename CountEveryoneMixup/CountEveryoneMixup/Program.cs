using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountEveryoneMixup
{
	class Program
	{
		static int count;

		static void Main(string[] args)
		{
			count = 0;
			var list = CountEveryoneMixup(11);

			//int num = 0;
			//foreach (var array in list)
			//{
			//	num++;
			//	Console.Write(num.ToString("(0000000000) "));
			//	for (int i = 0; i < array.Length; i++)
			//	{
			//		Console.Write(array[i]);
			//		Console.Write(' ');
			//	}
			//	Console.WriteLine();
			//}
			Console.WriteLine(count);
		}

		/// <summary>
		/// 全員が取り違える組み合わせの個数
		/// </summary>
		/// <param name="number"></param>
		/// <returns></returns>
		static List<int[]> CountEveryoneMixup(int number)
		{
			var list = new List<int[]>();
			var numbers = Enumerable.Range(0, number).ToArray();
			var stack = new Stack<int>(number);
			var nextIndex = 0;

			foreach (var num in numbers.Where(x => x != nextIndex))
			{
				stack.Push(num);
				var ext = numbers.Except(stack);

				CountInternal(number, list, stack, ext, nextIndex + 1);

				stack.Pop();
			}

			return list;
		}

		static void CountInternal(int number, List<int[]> list, Stack<int> stack, IEnumerable<int> numbers, int nextIndex)
		{
			if (stack.Count == number)
			{
				//list.Add(stack.Reverse().ToArray());
				count++;
				return;
			}

			foreach (var num in numbers.Where(x => x != nextIndex))
			{
				stack.Push(num);
				var ext = numbers.Except(stack);
				CountInternal(number, list, stack, ext, nextIndex + 1);

				stack.Pop();
			}
		}
	}
}
