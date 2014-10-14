using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CountEveryoneMixup
{
	class Program
	{
		static void Main(string[] args)
		{
			var counter = new EveryoneMixupCounter(9);
			var count = counter.Count();

			Console.WriteLine(count);
		}

		class EveryoneMixupCounter
		{
			/// <summary>
			/// 
			/// </summary>
			/// <param name="number">計算対象の人数</param>
			public EveryoneMixupCounter(int number)
			{
				this.number = number;
			}

			private int number;
			private int count;

			/// <summary>
			/// 全員がパソコンを取り違えるパターンの個数を数える
			/// </summary>
			/// <returns></returns>
			public int Count()
			{
				this.count = 0;

				var numbers = Enumerable.Range(0, number).ToArray();
				var nextIndex = 0;

				Parallel.ForEach(numbers.Where(x => x != nextIndex), num =>
				{
					var stack = new Stack<int>(this.number);
					stack.Push(num);
					var ext = numbers.Except(stack).ToArray();

					this.CountInternal(stack, ext, nextIndex + 1);
				});

				return this.count;
			}

			/// <summary>
			/// 再帰処理用の内部関数
			/// </summary>
			/// <param name="numbers"></param>
			/// <param name="nextIndex"></param>
			private void CountInternal(Stack<int> stack, int[] numbers, int nextIndex)
			{
				if (stack.Count == this.number)
				{
					Interlocked.Increment(ref this.count);
					return;
				}

				foreach (var num in numbers.Where(x => x != nextIndex))
				{
					stack.Push(num);
					var ext = numbers.Except(stack).ToArray();

					this.CountInternal(stack, ext, nextIndex + 1);

					stack.Pop();
				}
			}
		}
	}
}
