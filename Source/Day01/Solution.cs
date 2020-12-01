using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Day01
{
    public class Solution : BaseSolution
    {
        public Solution() : base(1, "Report Repair")
        {
        }

        private const int _sum = 2020;

        public override string GetPart1Answer()
        {
            var expenseHashSet = GetInputHashSet();

            foreach (var num in expenseHashSet)
            {
                int result = _sum - num;
                if (expenseHashSet.Contains(result))
                {
                    return $"{num * result}";
                }
            }
            return string.Empty;
        }

        public override string GetPart2Answer()
        {
            var expenseHashSet = GetInputHashSet();

            foreach (var num1 in expenseHashSet)
            {
                foreach (var num2 in expenseHashSet)
                {
                    int result = _sum - num1 - num2;
                    if (expenseHashSet.Contains(result))
                    {
                        return $"{num1 * num2 * result}";
                    }
                }
            }
            return string.Empty;
        }

        private HashSet<int> GetInputHashSet()
        {
            var input = GetResourceString();

            return new HashSet<int>(
                input.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => int.Parse(x)));
        }
    }
}