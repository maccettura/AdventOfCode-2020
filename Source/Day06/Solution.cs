using System;
using System.Linq;

namespace AdventOfCode.Day06
{
    public class Solution : BaseSolution
    {
        public Solution() : base(6, "Custom Customs")
        {
        }

        public override string GetPart1Answer()
        {
            var groups = GetResourceString().Split(Environment.NewLine + Environment.NewLine);

            int total = 0;
            foreach(var group in groups)
            {
                total += group.Where(c => char.IsLetter(c)).Distinct().Count();
            }

            return total.ToString();
        }

        public override string GetPart2Answer()
        {
            var groups = GetResourceString().Split(Environment.NewLine + Environment.NewLine);

            int total = 0;
            foreach (var group in groups)
            {
                var personCount = group.Split(Environment.NewLine).Length;
                total += group.Where(c => char.IsLetter(c)).GroupBy(x => x).Where(x => x.Count() >= personCount).Count();
            }

            return total.ToString();
        }
    }
}
