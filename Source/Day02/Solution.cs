using System;
using System.Collections.Generic;
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
            return GetInputCollection().Count(x => IsValid(x)).ToString();

            static bool IsValid(string line)
            {
                var (lowerLimit, upperLimit, character, password) = ExtractInfo(line);
                int charCount = password.Count(c => c == character);
                return charCount <= upperLimit && charCount >= lowerLimit;
            }
        }

        public override string GetPart2Answer()
        {
            return GetInputCollection().Count(x => IsValid(x)).ToString();

            static bool IsValid(string line)
            {
                var (position1, position2, character, password) = ExtractInfo(line);
                return password[position1 - 1] == character ^ password[position2 - 1] == character;
            }
        }

        private IEnumerable<string> GetInputCollection()
        {
            return GetResourceString().Split(new[] { Environment.NewLine }, StringSplitOptions.None);
        }

        private static readonly Regex _lineRegex = new Regex(@"(\d+)\-(\d+)\s(\w):\s(\w+)");

        private static (int lowerLimit, int upperLimit, char character, string password) ExtractInfo(string line)
        {
            var match = _lineRegex.Match(line);

            int lowerLimit = int.Parse(match.Groups[1].Value);
            int upperLimit = int.Parse(match.Groups[2].Value);
            char character = match.Groups[3].Value.FirstOrDefault();
            string password = match.Groups[4].Value;

            return (lowerLimit, upperLimit, character, password);
        }
    }
}