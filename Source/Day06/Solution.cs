using System;
using System.Linq;

namespace AdventOfCode.Day06
{
    public class Solution : BaseSolution
    {
        public Solution() : base(6, "Custom Customs")
        {
        }

        public override string GetPart1Answer() => GetResourceString()
                .Split(Environment.NewLine + Environment.NewLine)
                .Select(x => x.Where(char.IsLetterOrDigit)
                            .Distinct()
                            .Count())
                .Sum()
                .ToString();

        public override string GetPart2Answer() => GetResourceString()
                .Split(Environment.NewLine + Environment.NewLine)
                .Select(x => x.Where(char.IsLetterOrDigit)
                            .GroupBy(y => y)
                            .Where(y => y.Count() >= x.Split(Environment.NewLine).Length)
                            .Count())
                .Sum()
                .ToString();
    }
}
