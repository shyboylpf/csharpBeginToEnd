using System;
using System.Collections.Generic;

namespace 谷歌翻译
{
    class Program
    {
        static void Main(string[] args)
        {
			var result = new Program().SelfDividingNumbers(1,100);
			foreach(var item in result)
            {
                Console.WriteLine(item.ToString());
            }
        }

		public List<int> SelfDividingNumbers(int left, int right)
		{
			List<int> result = new List<int>();
			for (int i = left; i <= right; i++)
			{
				string istr = i.ToString();
				if (istr.Contains("0"))
				{
					continue;
				}

				bool isDivided = true;
				var cstr = istr.ToCharArray();
				foreach (var item in cstr)
				{
					int digit = int.Parse(item.ToString());
					if (i % digit != 0)
					{
						isDivided = false;
						break;
					}
				}
				if (isDivided)
				{
					result.Add(i);
				}
			}

			return result;
		}
	}
}
