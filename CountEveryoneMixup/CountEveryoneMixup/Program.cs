using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountEveryoneMixup
{
	class Program
	{
		static void Main(string[] args)
		{
			var counter = new EveryoneMixupCounter(5);
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
				this.stack = new Stack<int>(number);
			}

			private int number;
			private Stack<int> stack;
			private int count;

			/// <summary>
			/// 全員がパソコンを取り違えるパターンの個数を数える
			/// </summary>
			/// <returns></returns>
			public int Count()
			{
				this.count = 0;
				this.stack.Clear();

				var numbers = Enumerable.Range(0, number);
				var nextIndex = 0;

				foreach (var num in numbers.Where(x => x != nextIndex))
				{
					this.stack.Push(num);
					var ext = numbers.Except(this.stack);

					this.CountInternal(ext, nextIndex + 1);

					this.stack.Pop();
				}

				return this.count;
			}

			/// <summary>
			/// 再帰処理用の内部関数
			/// </summary>
			/// <param name="numbers"></param>
			/// <param name="nextIndex"></param>
			private void CountInternal(IEnumerable<int> numbers, int nextIndex)
			{
				if (this.stack.Count == this.number)
				{
					this.count++;
					return;
				}

				foreach (var num in numbers.Where(x => x != nextIndex))
				{
					this.stack.Push(num);
					var ext = numbers.Except(this.stack);

					this.CountInternal(ext, nextIndex + 1);

					this.stack.Pop();
				}
			}
		}
	}
}
