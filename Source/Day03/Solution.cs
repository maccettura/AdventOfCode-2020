using System;
using System.Linq;

namespace AdventOfCode.Day03
{
    public class Solution : BaseSolution
    {
        public Solution() : base(3, "Toboggan Trajectory")
        {
        }

        public override string GetPart1Answer()
        {
            var lines = GetResourceString().Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            return FindTeeCount(lines, 1, 3).ToString();
        }

        public override string GetPart2Answer()
        {
            var lines = GetResourceString().Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            var slopes = new (int slopeDown, int slopeRight)[] 
            {
                (1, 1),
                (1, 3),
                (1, 5),
                (1, 7),
                (2, 1),
            };

            return slopes.Select(x => FindTeeCount(lines, x.slopeDown, x.slopeRight)).Aggregate((a, x) => a * x).ToString();
        }

        private static int FindTeeCount(string[] lines, int slopeDown, int slopeRight)
        {
            int treeCount = 0;
            int index = 0;

            for (int i = 0; i < lines.Length; i += slopeDown)
            {
                if (index == 0)
                {
                    index += slopeRight;
                    continue;
                }

                if (lines[i][index >= 31 ? index % 31 : index] == '#')
                {
                    treeCount++;
                }
                index += slopeRight;
            }
            return treeCount;
        }
    }
}