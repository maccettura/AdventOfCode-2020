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
            int seatId = 0;

            foreach(var id in ids)
            {
                if(id != index)
                {
                    seatId = index;
                    break;
                }
                index++;
            }
            return seatId.ToString();
        }

        private static IEnumerable<int> GetSeatIds(string[] lines)
        {
            foreach (var line in lines)
            {
                int row = Convert.ToInt32(new string(line.Substring(0, 7).Select(x => x == 'F' ? '0' : '1').ToArray()), 2);
                int column = Convert.ToInt32(new string(line.Substring(7, 3).Select(x => x == 'L' ? '0' : '1').ToArray()), 2);
                yield return row * 8 + column;
            }
        }
    }
}
