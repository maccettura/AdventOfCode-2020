using System;
using System.Linq;

namespace AdventOfCode.Day09
{
    public class Solution : BaseSolution
    {
        public Solution() : base(9, "Encoding Error")
        {
        }

        public override string GetPart1Answer()
        {
            var numbers = GetResourceString()
                .Split(Environment.NewLine)
                .Select(long.Parse)
                .ToArray();

            return GetEncryptionBreakingNumber(numbers)?.ToString() ?? string.Empty;
        }

        public override string GetPart2Answer()
        {
            var numbers = GetResourceString()
                .Split(Environment.NewLine)
                .Select(long.Parse)
                .ToArray();

            long breakingPoint = GetEncryptionBreakingNumber(numbers).Value;

            for(int i = 0; i < numbers.Length; i++)
            {                
                for(int o = i + 1; o < numbers.Length; o++)
                {
                    var range = new Range(i, o);
                    var subSet = numbers[range];
                    if (subSet.Sum() == breakingPoint)
                    {
                        return (subSet.Min() + subSet.Max()).ToString();
                    }
                }
            }

            return string.Empty;
        }

        private static long? GetEncryptionBreakingNumber(long[] numbers)
        {
            for (int i = 25; i < numbers.Length; i++)
            {
                var range = new Range(i - 25, i);
                var set = numbers[range].Distinct().ToHashSet();
                bool matchFound = false;

                foreach (var n in set)
                {
                    long diff = numbers[i] - n;
                    if (set.Contains(diff) &&
                        n != diff)
                    {
                        matchFound = true;
                        break;
                    }
                }

                if (!matchFound)
                {
                    return numbers[i];
                }
            }

            return null;
        }
    }
}
