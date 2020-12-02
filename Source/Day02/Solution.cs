using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode.Day02
{
    public class Solution : BaseSolution
    {
        public Solution() : base(2, "Password Philosophy")
        {
        }

        public override string GetPart1Answer()
        {
            var input = GetResourceString();
            string[] lines = input.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
            return lines.Count(x => IsValid(x)).ToString();
        }

        private static readonly Regex _lineRegex = new Regex(@"(\d+)\-(\d+)\s(\w):\s(\w+)");

        private static bool IsValid(string line)
        {
            var match = _lineRegex.Match(line);

            int lowerLimit = int.Parse(match.Groups[1].Value);
            int upperLimit = int.Parse(match.Groups[2].Value);
            char character = match.Groups[3].Value.FirstOrDefault();
            string password = match.Groups[4].Value;

            int charCount = password.Count(x => x == character);
            return charCount <= upperLimit && charCount >= lowerLimit;
        }

        public override string GetPart2Answer()
        {
            return string.Empty;
        }
    }
}