using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Day05
{
    public class Solution : BaseSolution
    {
        public Solution() : base(5, "Binary Boarding")
        {
        }

        public override string GetPart1Answer()
        {
            return GetSeatIds(GetResourceString().Split(Environment.NewLine))
                .OrderByDescending(x => x)
                .First()
                .ToString();
        }

        public override string GetPart2Answer()
        {
            var ids = GetSeatIds(GetResourceString().Split(Environment.NewLine))
                .OrderBy(x => x);

            int index = ids.First();
            foreach(var id in ids)
            {
                if(id != index)
                {
                    return index.ToString();
                }
                index++;
            }
            return string.Empty;
        }

        private static IEnumerable<int> GetSeatIds(string[] lines)
        {
            foreach (var line in lines)
            {
                int row = Convert.ToInt32(line.Substring(0, 7).Replace('F', '0').Replace('B', '1'), 2);
                int column = Convert.ToInt32(line.Substring(7, 3).Replace('L', '0').Replace('R', '1'), 2);
                yield return row * 8 + column;
            }
        }
    }
}
